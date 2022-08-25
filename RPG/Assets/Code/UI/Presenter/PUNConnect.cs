using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Code.UI.Presenter
{
    public class PUNConnect:MonoBehaviourPunCallbacks
    {
        private Action _connectAction;
        private Action _newPlayerAction;
        private const string GAMEVERSION = "1";
        private int _playerNumber = 0;
        
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

        public override void OnJoinedRoom()
        {
            _connectAction.Invoke();
            _newPlayerAction.Invoke();
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            CreateRoom();
        }

        public override void OnConnectedToMaster()
        {
            JoinRoom();
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            _newPlayerAction.Invoke();
        }
    }
}