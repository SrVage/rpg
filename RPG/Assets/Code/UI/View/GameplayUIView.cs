using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.View
{
    public class GameplayUIView:MonoBehaviour
    {
        [SerializeField] private Image _health;
        [SerializeField] private Image _experience;
        [SerializeField] private TextMeshProUGUI _level;
        public Image Health => _health;
        public Image Experience => _experience;
        public string Level
        {
            set => _level.text = value;
        }
    }
}