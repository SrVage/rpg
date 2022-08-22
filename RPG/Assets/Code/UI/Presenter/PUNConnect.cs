using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Code.UI.Presenter
{
    public class PUNConnect:MonoBehaviourPunCallbacks
    {
        private Action _connectAction;
        private const string GAMEVERSION = "1";
        
        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }
        
        public void Connect(Action connect)
        {
            _connectAction = connect;
            if (PhotonNetwork.IsConnected)
               JoinRoom();
            else
            {
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = GAMEVERSION;
            }
        }

        private void JoinRoom()
        {
            Debug.Log("Join Room");
            PhotonNetwork.JoinRandomRoom();
        }

        private void CreateRoom()
        {
            Debug.Log("Create room");
            PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = 4});
        }

        public override void OnJoinedRoom() => 
            _connectAction.Invoke();

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            CreateRoom();
        }
        
        
        
        
    }
}