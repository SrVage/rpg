using System;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Presenter
{
    public class Login:MonoBehaviour
    {
        private const string TILEID = "987E1";
        private const string AUTHGUID = "authGuid";
        private const string ERRORTEXT = "Error";
        private const string SUCCESSTEXT = "Success";
        [SerializeField] private Button _loginButton;
        [SerializeField] private TextMeshProUGUI _statusText;

        private void Start() => 
            _loginButton.onClick.AddListener(Connect);

        private void Connect()
        {
            if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
                PlayFabSettings.staticSettings.TitleId = TILEID;
            bool needCreation = !PlayerPrefs.HasKey(AUTHGUID);
            var id = PlayerPrefs.GetString(AUTHGUID, Guid.NewGuid().ToString());
            var request = new LoginWithCustomIDRequest()
            {
                CustomId = id,
                CreateAccount = needCreation
            };
            PlayFabClientAPI.LoginWithCustomID(request, success=>
            {
                PlayerPrefs.SetString(AUTHGUID, id);
                OnLoginSuccess(success);
            }, 
                OnLoginFailure);
        }

        private void OnLoginFailure(PlayFabError error)
        {
            Debug.Log($"Error with parameters: {error.GenerateErrorReport()}");
            _statusText.text = ERRORTEXT;
            _statusText.color = Color.red;
        }

        private void OnLoginSuccess(LoginResult result)
        {
            Debug.Log("Success");
            _statusText.text = SUCCESSTEXT;
            _statusText.color = Color.green;
        }
    }
}