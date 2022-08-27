using System;
using System.Threading.Tasks;
using Code.UI.View;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Zenject;

namespace Code.UI.Presenter
{
    public class PUNConnect:MonoBehaviourPunCallbacks
    {
        private Action _connectAction;
        private Action _newPlayerAction;
        private const string GAMEVERSION = "1";
        private int _playerNumber = 0;
        [Inject] private ConnectStatusView _connectStatusView;
        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public void InitAction(Action action)
        {
            _newPlayerAction = action;
        }
        
        public void Connect(Action connect)
        {
            _connectAction = connect;
            if (PhotonNetwork.IsConnected)
               JoinRoom();
            else
            {
                _connectStatusView.Status = "Try to connect server";
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = GAMEVERSION;
            }
        }

        private void JoinRoom()
        {
            _connectStatusView.Status = "Join room";
            PhotonNetwork.JoinRandomRoom();
        }

        private void CreateRoom()
        {
            _connectStatusView.Status = "Create room";
            PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = 4});
        }

        public override void OnJoinedRoom()
        {
            _connectStatusView.Status = "Join room done";
            _connectAction.Invoke();
            _newPlayerAction.Invoke();
            Clear();
        }

        private async void Clear()
        {
            await Task.Delay(2000);
            _connectStatusView.Status = "";
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            _connectStatusView.Status = "Join to random room failed";
            CreateRoom();
        }

        public override void OnConnectedToMaster()
        {
            _connectStatusView.Status = "Connect to master done";
            JoinRoom();
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            _connectStatusView.Status = $"{newPlayer.NickName} entered the game";
            _newPlayerAction.Invoke();
            Clear();
        }
    }
}