using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.UI.Presenter
{
    public class ItemView:MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _itemName;
        [SerializeField] private TextMeshProUGUI _description;
        private string _itemID;
        public event Action<string> Click;

        public void SetItem(string itemID, Sprite sprite, string name, string description)
        {
            _itemID = itemID;
            _image.sprite = sprite;
            _itemName.text = name;
            _description.text = description;
            _description.gameObject.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData) => 
            _description.gameObject.SetActive(true);

        public void OnPointerExit(PointerEventData eventData) => 
            _description.gameObject.SetActive(false);


        public void OnPointerClick(PointerEventData eventData)
        {
            Click?.Invoke(_itemID);
            Debug.Log(_itemID);
        }
    }
}