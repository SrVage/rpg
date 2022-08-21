using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Presenter
{
    public class StartWindow:MonoBehaviour
    {
        [SerializeField] private Button _openSignInButton;
        [SerializeField] private Button _openCreateAccountButton;
        [SerializeField] private Canvas _startWindowCanvas;
        [SerializeField] private Canvas _signInCanvas;
        [SerializeField] private Canvas _createAccountCanvas;

        private void Start()
        {
            _openSignInButton.onClick.AddListener(OpenSignIn);
            _openCreateAccountButton.onClick.AddListener(OpenCreateAccount);
        }

        private void OnDestroy()
        {
            _openSignInButton.onClick.RemoveAllListeners();
            _openCreateAccountButton.onClick.RemoveAllListeners();
        }

        private void OpenCreateAccount()
        {
            _startWindowCanvas.enabled = false;
            _createAccountCanvas.enabled = true;
            _createAccountCanvas.GetComponent<AccountDataWindowBase>().Init(CloseCreateAccount);
        }

        private void OpenSignIn()
        {
            _startWindowCanvas.enabled = false;
            _signInCanvas.enabled = true;
            _signInCanvas.GetComponent<AccountDataWindowBase>().Init(CloseSignIn);
        }

        private void CloseCreateAccount()
        {
            _startWindowCanvas.enabled = true;
            _createAccountCanvas.enabled = false;
        }
        
        private void CloseSignIn()
        {
            _startWindowCanvas.enabled = true;
            _signInCanvas.enabled = false;
        }
    }
}