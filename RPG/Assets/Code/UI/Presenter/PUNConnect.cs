using System;
using Photon.Pun;
using Photon.Realtime;

namespace Code.UI.Presenter
{
    public class PUNConnect:MonoBehaviourPunCallbacks
    {
        private Action _connectAction;
        private const string GAMEVERSION = "1";
        
        public void Connect(Action connect)
        {
            _connectAction = connect;
            if (PhotonNetwork.IsConnected)
                PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions()
                {
                    IsOpen = true,
                    IsVisible = true,
                    MaxPlayers = 2
                }, TypedLobby.Default);
            else
            {
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = GAMEVERSION;
            }
        }

        public override void OnCreatedRoom() => 
            _connectAction.Invoke();

        public override void OnJoinedLobby() => 
            _connectAction.Invoke();
    }
}