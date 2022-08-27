using System.Linq;
using Code.Abstract.Interfaces;
using Code.Components;
using Code.UI.Presenter;
using Leopotam.Ecs;
using PlayFab;
using PlayFab.ClientModels;
using Zenject;

namespace Code.Services
{
    internal sealed class GetThingsFromChest : IGetThingsFromChest
    {
        private const string PotionID = "HealthPotion";
        private string _potionInstance;
        private int _potionCount;
        private readonly GameplayUIPresenter _gameplayUIPresenter = null;
        private readonly EcsWorld _world = null;

        [Inject]
        public GetThingsFromChest(GameplayUIPresenter gameplayUIPresenter, EcsWorld world)
        {
            _gameplayUIPresenter = gameplayUIPresenter;
            _world = world;
            _gameplayUIPresenter.SetPotionAction(UsePotion);
        }

        public void GetPotion()
        {
            MakePurchase();
        }

        public void UsePotion()
        {
            PlayFabClientAPI.ConsumeItem(new ConsumeItemRequest()
            {
                ConsumeCount = 1,
                ItemInstanceId = _potionInstance
            }, ConsumeResult, LogFailure);
        }

        private void ConsumeResult(ConsumeItemResult obj)
        {
            _world.NewEntity().Get<UsePotion>();
            GetInventory();
        }

        private void MakePurchase()
        {
            PlayFabClientAPI.PurchaseItem(new PurchaseItemRequest
            {
                CatalogVersion = "Things",
                ItemId = PotionID,
                Price = 0,
                VirtualCurrency = "GC"
            }, GetInventory, LogFailure);
        }

        private void LogFailure(PlayFabError obj)
        {

        }

        public void GetInventory(PurchaseItemResult obj = null)
        {
            PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), ResultCallback, LogFailure);
        }


        private void ResultCallback(GetUserInventoryResult obj)
        {
            var potion = obj.Inventory.FirstOrDefault(i => i.ItemId == PotionID);
            if (potion != null)
            {
                _potionInstance = potion.ItemInstanceId;            
                _gameplayUIPresenter.SetPotion(potion.RemainingUses ?? 0);
            }
            else
            {
                _gameplayUIPresenter.SetPotion(0);
            }
        }
    }
}