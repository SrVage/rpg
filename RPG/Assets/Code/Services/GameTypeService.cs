using Code.Abstract.Interfaces;

namespace Code.Services
{
    internal sealed class GameTypeService:IGameTypeService
    {
        public bool IsOnline { get; set; } = false;
    }
}