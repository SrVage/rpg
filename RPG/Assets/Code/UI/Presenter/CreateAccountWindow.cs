using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Presenter
{
    public class CreateAccountWindow:AccountDataWindowBase
    {
        [SerializeField] private InputField _emailInputField;
        [SerializeField] private Button _createAccountButton;
        private string _email;

        protected override void AddListenerOnUIElements()
        {
            base.AddListenerOnUIElements();
            _emailInputField.onValueChanged.AddListener(EmailChanged);
            _createAccountButton.onClick.AddListener(CreateAccount);
        }

        private void CreateAccount()
        {
            StartLoading("Creating");
            PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest()
            {
                Username = _username,
                Password = _password,
                Email = _email
            },
                result =>
                { 
                    Success($"{_username} was registered!");
                    Debug.Log($"{_username} was registered!");
                },
                error =>
                {
                    Error(error.ErrorMessage);
                    Debug.Log(error.ErrorMessage);
                });
        }

        private void EmailChanged(string email) => 
            _email = email;
    }
}