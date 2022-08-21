using Code.Abstract;
using UnityEngine;

namespace Code.Config
{
    [CreateAssetMenu(menuName = "Configs/PlayerCfg")]
    public class PlayersClassesConfig:ScriptableObject
    {
        public PlayerClass[] Players;
        public GameObject VirtualCamera;
    }
}