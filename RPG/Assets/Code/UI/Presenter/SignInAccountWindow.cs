using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Presenter
{
    public class SignInAccountWindow:AccountDataWindowBase
    {
        [SerializeField] private Button _signInButton;

        protected override void AddListenerOnUIElements()
        {
            base.AddListenerOnUIElements();
            _signInButton.onClick.AddListener(SignInAccount);
        }

        private void SignInAccount()
        {
            StartLoading("Entering");
            PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest()
            {
                Username = _username,
                Password = _password
            },
                result =>
                {
                    Success($"{_username} was entered!");
                    Debug.Log($"{_username} was entered!");
                },
                error =>
                { 
                    Error(error.ErrorMessage);
                    Debug.Log(error.ErrorMessage);
                });
        }
    }
}