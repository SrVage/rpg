using Code.Abstract;
using UnityEngine;

namespace Code.Config
{
    [CreateAssetMenu(menuName = "Configs/ItemsCfg")]
    public class ItemsConfig:ScriptableObject
    {
        public Item[] Items;
    }
}