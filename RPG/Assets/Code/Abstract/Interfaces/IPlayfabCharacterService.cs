using PlayFab.ClientModels;

namespace Code.Abstract.Interfaces
{
    public interface IPlayfabCharacterService
    {
        void UpdateCharacterStatistics(int player);
        void GetCharacters();
        void SelectCharacter(int id);
    }
}