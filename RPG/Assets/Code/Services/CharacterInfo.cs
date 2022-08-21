using UnityEngine;

namespace PlayfabProject
{
    public enum CharacterClass
    {
        Warrior = 0,
        Magic = 1,
        Thief = 2
    }
    public class CharacterInfo
    {
        public CharacterClass Class;
        public string PlayerName;
        public int Level;
        public int XP;
        public int Health;
        public int Damage;
        public Sprite Avatar;
    }
}