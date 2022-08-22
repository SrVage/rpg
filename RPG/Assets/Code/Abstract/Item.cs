using System;
using Code.Abstract.Enums;
using UnityEngine;

namespace Code.Abstract
{
    [Serializable]
    public class Item
    {
        public ItemClass ItemClass;
        public int Damage;
        public int Shields;
        public Sprite Sprite;
        public string ItemID;
    }
}