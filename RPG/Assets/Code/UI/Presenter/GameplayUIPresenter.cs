using Code.UI.View;
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
        
    }
}