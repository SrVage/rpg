using Code.Abstract.Interfaces;
using Code.Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Presenter
{
    public class CreateCharacterView:MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _selectClass;
        [SerializeField] private TMP_InputField _characterNameInputField;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _damageText;
        [SerializeField] private Image _avatar;
        [SerializeField] private Button _createButton;
        [SerializeField] private Button _closeButton;
        [Inject] private PlayersClassesConfig _classConfig;
        private IPlayfabCharacterService _playfabCharacterService;
        private int _health;
        private int _damage;
        private string _characterName;

        private void Start()
        {
            _characterNameInputField.onValueChanged.AddListener(OnNameChanged);
            _selectClass.onValueChanged.AddListener(OnClassChanged);
            _createButton.onClick.AddListener(() =>
            {
                _playfabCharacterService.CreateCharacter(_characterName, _health, _damage, _selectClass.value, Hide);
            });
            _closeButton.onClick.AddListener(() => gameObject.SetActive(false));
            OnClassChanged(0);
        }
        
        public void GetService(IPlayfabCharacterService playfabCharacterService) => 
            _playfabCharacterService = playfabCharacterService;

        private void Hide() => 
            gameObject.SetActive(false);

        private void OnClassChanged(int characterClass)
        {
            _damage = _classConfig.Players[characterClass].Damage;
            _health = _classConfig.Players[characterClass].Health;
            _healthText.text = $"Health: {_health.ToString()}";
            _damageText.text = $"Damage: {_damage.ToString()}";
            _avatar.sprite = _classConfig.Players[characterClass].Avatar;
        }

        private void OnNameChanged(string name) => 
            _characterName = name;

        public void Active() => 
            gameObject.SetActive(true);
        

    }
}