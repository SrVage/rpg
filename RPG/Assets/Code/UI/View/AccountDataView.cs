using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.View
{
    public class AccountDataView:MonoBehaviour
    {
        [SerializeField] private InputField _usernameInputField;
        [SerializeField] private InputField _passwordInputField;
        [SerializeField] private TextMeshProUGUI _loadingText;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _doneButton;
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Button BackButton => _backButton;
        public Button DoneButton => _doneButton;

        [Inject]
        public void Init()
        {
            AddListeners();
        }

        private void AddListeners()
        {
            _usernameInputField.onValueChanged.AddListener(UsernameChanged);
            _passwordInputField.onValueChanged.AddListener(PasswordChanged);
        }

        private void PasswordChanged(string password) => 
            Password = password;

        private void UsernameChanged(string username) => 
            Username = username;
    }
}