using System;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.UI.Presenter
{
    public class AccountDataWindowBase:MonoBehaviour
    {
        [SerializeField] private InputField _usernameInputField;
        [SerializeField] private InputField _passwordInputField;
        [SerializeField] private TextMeshProUGUI _loadingText;
        [SerializeField] private Button _backButton;
        const string PlayerNamePrefKey = "PlayerName";
        protected string _username;
        protected string _password;
        private CancellationTokenSource _cancellationTokenSource;

        private void Start() => 
            AddListenerOnUIElements();

        public void Init(Action action) => 
            _backButton.onClick.AddListener(action.Invoke);

        protected virtual void AddListenerOnUIElements()
        {
            _usernameInputField.onValueChanged.AddListener(UsernameChanged);
            _passwordInputField.onValueChanged.AddListener(PasswordChanged);
        }

        private void PasswordChanged(string password) => 
            _password = password;

        private void UsernameChanged(string username) => 
            _username = username;

        protected async void StartLoading(string text)
        {
            _loadingText.enabled = true;
            _cancellationTokenSource = new CancellationTokenSource();
            string changedText = text;
            try
            {
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        changedText+= ".";
                        _loadingText.text = changedText;
                        await Task.Delay(300, _cancellationTokenSource.Token);
                        if (_cancellationTokenSource.IsCancellationRequested)
                            break;
                    }
                    changedText = text;
                }
            }
            catch (Exception e)
            {
            }
        }

        protected async void Success(string text)
        {
            EndLoading();
            _loadingText.color = Color.green;
            _loadingText.text = text;
            await Task.Delay(1000);
            _loadingText.enabled = false;
            SceneManager.LoadScene(1);
        }

        protected async void Error(string error)
        {
            EndLoading();
            _loadingText.color = Color.red;
            _loadingText.text = error;
            await Task.Delay(1000);
            _loadingText.enabled = false;
        }

        private void EndLoading()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }
}