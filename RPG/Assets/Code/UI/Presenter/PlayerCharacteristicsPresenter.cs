using Code.Abstract.Interfaces;
using Code.UI.View;
using UnityEngine;
using Zenject;

namespace Code.UI.Presenter
{
    public class PlayerCharacteristicsPresenter:MonoBehaviour
    {
        [SerializeField] private PlayerCharacteristicsView _playerCharacteristicsView;
        private IChoosePlayerService _choosePlayerService;

        [Inject]
        public void Init(IChoosePlayerService choosePlayerService)
        {
            _choosePlayerService = choosePlayerService;
            transform.SetParent(FindObjectOfType<Canvas>().transform);
            var rect = GetComponent<RectTransform>();
            rect.anchoredPosition = Vector2.zero;
        }

        public void Switch()
        {
            if (_playerCharacteristicsView.CurrentCanvas.alpha>0.5) 
                Hide();
            else
                Show();
        }
        
        private void Show()
        {
            var player = _choosePlayerService.GetPlayer;
            _playerCharacteristicsView.PlayerName = $"Player name: {player.PlayerName}";
            _playerCharacteristicsView.PlayerClass = $"Player class: {player.Class}";
            _playerCharacteristicsView.Health = $"Player health: {player.Health}";
            _playerCharacteristicsView.Damage = $"Player damage: {player.Damage}";
            _playerCharacteristicsView.Level = $"Player level: {player.Level}";
            _playerCharacteristicsView.XP = $"Player XP: {player.XP}";
            _playerCharacteristicsView.BattlesWin = $"Kill other players: {player.BattlesWin}";
            _playerCharacteristicsView.CurrentCanvas.alpha = 1;
            _playerCharacteristicsView.CurrentCanvas.blocksRaycasts = true;
        }

        private void Hide()
        {
            _playerCharacteristicsView.CurrentCanvas.alpha = 0;
            _playerCharacteristicsView.CurrentCanvas.blocksRaycasts = false;
        }
    }
}