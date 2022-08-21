using System;
using UnityEngine;

namespace Code.UI.Presenter
{
    [CreateAssetMenu(menuName = "Config/Catalog Items")]
    public class CatalogOfItems:ScriptableObject
    {
        [Serializable]
        public class Item
        {
            public string ID;
            public Sprite Image;
        }
        public Item[] Items;
        public ItemView Prefab;
    }
}