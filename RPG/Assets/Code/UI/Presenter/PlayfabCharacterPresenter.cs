using System.Collections.Generic;
using Code.Abstract;
using Code.Abstract.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Presenter
{
    public class PlayfabCharacterPresenter:MonoBehaviour
    {
        [SerializeField] private SelectPlayerView[] _playerSlots;
        [SerializeField] private CreateCharacterView _createCharacterView;
        [SerializeField] private Button _startGame;
        [SerializeField] private Button _startOnlineGame;
        [SerializeField] private PUNConnect _punConnect;
        private IPlayfabCharacterService _playfabCharacterService = null;
        [Inject] private DiContainer _container;
        private int? _currentPlayer;
        
        [Inject]
        private void Init()
        {
            transform.SetParent(FindObjectOfType<Canvas>().transform);
            var rect = GetComponent<RectTransform>();
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            for (int i = 0; i < _playerSlots.Length; i++)
            {
                _playerSlots[i].Id = i;
                _playerSlots[i].CreateNewCharacter += CreateNewCharacter;
                _playerSlots[i].SelectCharacter += SelectCharacter;
            }
            _startGame.onClick.AddListener(StartGame);
            _startOnlineGame.onClick.AddListener(StartOnlineGame);
        }

        private void StartOnlineGame()
        {
            _punConnect.Connect(StartGame);
        }

        public void GetService(IPlayfabCharacterService playfabCharacterService)
        {
            _createCharacterView.GetService(playfabCharacterService);
            _playfabCharacterService = playfabCharacterService;
            _playfabCharacterService.GetCharacters();
        }

        private void StartGame()
        {
            _container.ResolveId<IInitializable>("Startup").Initialize();
            gameObject.SetActive(false);
        }

        private void SelectCharacter(int currentID)
        {
            if (_currentPlayer == currentID) 
                _currentPlayer = null;
            else
                _currentPlayer = currentID;
            ChangeSelect();
            _playfabCharacterService.SelectCharacter(currentID);
        }


        private void ChangeSelect()
        {
            for (int i = 0; i < _playerSlots.Length; i++)
            {
                _playerSlots[i].Select(_currentPlayer == i);
            }
        }

        private void CreateNewCharacter(int id)
        {
            _createCharacterView.Active();
        }

        public void ShowCharacters(List<PlayerClass> characters)
        {
            for (int i = 0; i < _playerSlots.Length; i++)
            {
                if (i + 1 <= characters.Count)
                {
                    _playerSlots[i].ShowPlayerInfo();
                    _playerSlots[i].SetPlayerStatistic(characters[i].Avatar, characters[i].PlayerName, characters[i].Level, characters[i].XP, characters[i].Health, characters[i].Damage);
                }
                else
                    _playerSlots[i].CreateCharacter();
            }
        }
    }
}