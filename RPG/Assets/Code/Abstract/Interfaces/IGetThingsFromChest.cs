using PlayFab.ClientModels;

namespace Code.Abstract.Interfaces
{
    public interface IGetThingsFromChest
    {
        void GetPotion();
        void GetInventory(PurchaseItemResult obj = null);
        void UsePotion();
    }
}