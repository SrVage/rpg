using System;
using UnityEngine;

namespace Code.Abstract
{
    [Serializable]
    public class PlayerClass
    {
        public GameObject Prefab;
        public PlayersClasses Class;
        public int Health;
        public int Damage;
        public Sprite Avatar;
        [HideInInspector] public string PlayerName;
        [HideInInspector] public int Level;
        [HideInInspector] public int XP;
        [HideInInspector] public string CharacterID;
        [HideInInspector] public int BattlesWin;
        [HideInInspector] public int BattlesLose;
        
    }
}