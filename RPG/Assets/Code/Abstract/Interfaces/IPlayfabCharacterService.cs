using System;
using PlayFab.ClientModels;

namespace Code.Abstract.Interfaces
{
    public interface IPlayfabCharacterService
    {
        void UpdateCharacterStatistics();
        void GetCharacters();
        void SelectCharacter(int id);
        void CreateCharacter(string name, int health, int damage, int selectClass, Action end);
        void UpdateNewCharacterStatistics(string characterId);
    }
}