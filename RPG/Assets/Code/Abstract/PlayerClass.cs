using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Abstract
{
    [Serializable]
    public class PlayerClass
    {
        public AssetReference Prefab;
        public PlayersClasses Class;
        public int Health;
        public int Damage;
        public Sprite Avatar;
        [HideInInspector] public string PlayerName;
        [HideInInspector] public int Level;
        [HideInInspector] public int XP;
        [HideInInspector] public string CharacterID;
    }
}