using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI.View
{
    public class ConnectStatusView:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _status;
        public string Status
        {
            set => _status.text = value;
        }

        [Inject]
        public void Init()
        {
            transform.SetParent(FindObjectOfType<Canvas>().transform);
            var rect = GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(0, 50);
        }
    }
}