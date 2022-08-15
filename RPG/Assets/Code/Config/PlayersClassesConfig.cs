using System;
using Code.Abstract;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Config
{
    [CreateAssetMenu(menuName = "Configs/PlayerCfg")]
    public class PlayersClassesConfig:ScriptableObject
    {
        [Serializable]
        public class PlayerClass
        {
            public AssetReference Prefab;
            public PlayersClasses Class;
            public int InitialHealth;
            public int InitialDamage;
        }
        public PlayerClass[] Players;
        public GameObject VirtualCamera;
    }
}