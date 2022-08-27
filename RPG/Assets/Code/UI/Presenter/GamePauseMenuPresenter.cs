using Code.Abstract.Interfaces;
using Code.UI.View;
using UnityEngine;
using Zenject;

namespace Code.UI.Presenter
{
    public class GamePauseMenuPresenter:MonoBehaviour
    {
        [SerializeField] private GamePauseMenuView _gamePauseMenuView;
        [Inject] private IPlayerSaveService _playerSaveService;

        [Inject]
        public void Init()
        {
            transform.SetParent(FindObjectOfType<Canvas>().transform);
            var rect = GetComponent<RectTransform>();
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            _gamePauseMenuView.SaveGameButton.onClick.AddListener(_playerSaveService.Save);
            _gamePauseMenuView.ResumeGameButton.onClick.AddListener(CloseWindow);
            _gamePauseMenuView.ExitGameButton.onClick.AddListener(() => Application.Quit());
        }

        private void CloseWindow()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public void OnEnable() => 
            Time.timeScale = 0;
    }
}