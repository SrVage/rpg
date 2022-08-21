using System.Collections.Generic;
using Code.Config;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Presenter
{
    public class CreateCharacterView:MonoBehaviour
    {
        private const string ItemID = "SteelSword";
        [SerializeField] private TMP_Dropdown _selectClass;
        [SerializeField] private TMP_InputField _characterNameInputField;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _damageText;
        [SerializeField] private Image _avatar;
        [SerializeField] private Button _createButton;
        [SerializeField] private Button _closeButton;
        [Inject] private PlayersClassesConfig _classConfig;
        private int _health;
        private int _damage;
        private string _characterName;

        private void Start()
        {
            _characterNameInputField.onValueChanged.AddListener(OnNameChanged);
            _selectClass.onValueChanged.AddListener(OnClassChanged);
            _createButton.onClick.AddListener(MakePurchase);
            _closeButton.onClick.AddListener(() => gameObject.SetActive(false));
            OnClassChanged(0);
        }

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
        
        void MakePurchase() {
            PlayFabClientAPI.PurchaseItem(new PurchaseItemRequest {
                // In your game, this should just be a constant matching your primary catalog
                CatalogVersion = "Things",
                ItemId = ItemID,
                Price = 0,
                VirtualCurrency = "GC"
            }, LogSuccess, LogFailure);
        }

        private void LogFailure(PlayFabError obj)
        {
            throw new System.NotImplementedException();
        }

        private void LogSuccess(PurchaseItemResult obj)
        {
            CreateCharacterWithItemId();
        }

        public void CreateCharacterWithItemId()
        {
            
            PlayFabClientAPI.GrantCharacterToUser(new GrantCharacterToUserRequest
            {
                CharacterName = _characterName,
                ItemId = ItemID
            }, result =>
            {
                UpdateCharacterStatistics(result.CharacterId);
            }, Debug.LogError);
        }
        private void UpdateCharacterStatistics(string characterId)
        {
            PlayFabClientAPI.UpdateCharacterStatistics(new UpdateCharacterStatisticsRequest
                {
                    CharacterId = characterId,
                    CharacterStatistics = new Dictionary<string, int>
                    {
                        {"Class", _selectClass.value},
                        {"Level", 0},
                        {"XP", 0},
                        {"Damage", _damage},
                        {"Health", _health},
                    }
                }, result =>
                {
                    Debug.Log($"Initial stats set, telling client to update character list");
                    gameObject.SetActive(false);
                },
                Debug.LogError);
        }
    }
}