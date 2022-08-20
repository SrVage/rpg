using Code.UI.View;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Code.UI.Presenter
{
    public class GameplayUIPresenter:MonoBehaviour
    {
        [SerializeField] private GameplayUIView _gameplayUIView;

        [Inject]
        public void Init()
        {
            transform.SetParent(FindObjectOfType<Canvas>().transform);
            var rect = GetComponent<RectTransform>();
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
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
    }
}