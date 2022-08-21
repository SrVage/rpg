namespace Code.Abstract.Interfaces
{
    public interface IChoosePlayerService
    {
        void SetPlayer(PlayerClass playerClass);
        PlayerClass GetPlayer { get; }
    }
}