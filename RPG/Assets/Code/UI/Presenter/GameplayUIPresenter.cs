using Code.Abstract.Interfaces;
using Code.UI.View;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Code.UI.Presenter
{
    public class GameplayUIPresenter:MonoBehaviour
    {
        [SerializeField] private GameplayUIView _gameplayUIView;
        [Inject] private GamePauseMenuPresenter _gamePauseMenuPresenter;
        [Inject] private IGameplayCommandUIService _gameplayCommandUIService;
        [Inject] private PlayerCharacteristicsPresenter _playerCharacteristicsPresenter;

        [Inject]
        public void Init()
        {
            transform.SetParent(FindObjectOfType<Canvas>().transform);
            var rect = GetComponent<RectTransform>();
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            _gameplayUIView.Menu.onClick.AddListener(()=>_gamePauseMenuPresenter.gameObject.SetActive(true));
            _gameplayUIView.CameraLock.onClick.AddListener(()=>_gameplayCommandUIService.ChangeRotateCamera());
            _gameplayUIView.Characteristics.onClick.AddListener(() => _playerCharacteristicsPresenter.Switch());
        }
        public void ChangeHealth(float percent) => 
            _gameplayUIView.Health.fillAmount = percent;

        public void ChangeExperience(float percent) => 
            _gameplayUIView.Experience.fillAmount = percent;

        public void ChangeLevel(int level)
        {
            DOTween.Sequence().Append(_gameplayUIView.ExperienceTransform.DOScale(1.2f, 1f))
                .AppendInterval(0.5f)
                .Append(_gameplayUIView.ExperienceTransform.DOScale(1f, 1f))
                .OnComplete(() => _gameplayUIView.Level = level.ToString());
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}