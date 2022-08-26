using TMPro;
using UnityEngine;

namespace Code.UI.View
{
    public class PlayerCharacteristicsView:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playerName; 
        [SerializeField] private TextMeshProUGUI _playerClass;
        [SerializeField] private TextMeshProUGUI _health;
        [SerializeField] private TextMeshProUGUI _damage;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _xp;
        [SerializeField] private TextMeshProUGUI _battlesWin;
        [SerializeField] private CanvasGroup _currentCanvas;

        public string PlayerName
        {
            set => _playerName.text = value;
        }
        public string PlayerClass
        {
            set => _playerClass.text = value;
        }
        public string Health
        {
            set => _health.text = value;
        }
        public string Damage
        {
            set => _damage.text = value;
        }
        public string Level
        {
            set => _level.text = value;
        }
        public string XP
        {
            set => _xp.text = value;
        }
        public string BattlesWin
        {
            set => _battlesWin.text = value;
        }

        public CanvasGroup CurrentCanvas => _currentCanvas;
    }
}