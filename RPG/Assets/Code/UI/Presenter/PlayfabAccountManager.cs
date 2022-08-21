using System;
using System.Collections.Generic;
using System.Linq;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Presenter
{
    public class PlayfabAccountManager:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _userNameText;
        [SerializeField] private TextMeshProUGUI _timeInGame;
        [SerializeField] private Button _forgetAccount;
        [SerializeField] private CatalogOfItems _item;
        [SerializeField] private Transform _weapon;
        [SerializeField] private Transform _armor;
        private readonly Dictionary<string, CatalogItem> _catalog = new Dictionary<string, CatalogItem>();
        private void Start()
        {
            PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), Success, Error );
            _forgetAccount.onClick.AddListener(Forget);
            PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest(), OnGetCatalogSuccess, Error);
        }

        private void OnGetCatalogSuccess(GetCatalogItemsResult result)
        {
            ShowCatalog(result.Catalog);
            Debug.Log("Load catalog successful");
        }

        private void ShowCatalog(List<CatalogItem> items)
        {
            foreach (var item in items)
            {
                _catalog.Add(item.ItemId, item);
                if (item.ItemClass == "Weapons") 
                    CreateItem(item, _weapon);
                if (item.ItemClass == "Armor") 
                    CreateItem(item, _armor);
                Debug.Log($"Catalog item {item.ItemId} was added successfully!");
            }
        }

        private void CreateItem(CatalogItem item, Transform parent)
        {
            var itemView = Instantiate(_item.Prefab, parent);
            var sprite = _item.Items.First(i => i.ID == item.ItemId).Image;
            //itemView.SetItem(sprite, item.DisplayName, item.Description);
        }

        private void Forget() => 
            PlayFabClientAPI.ForgetAllCredentials();

        private void Error(PlayFabError error) => 
            Debug.Log(error.GenerateErrorReport());

        private void Success(GetAccountInfoResult success)
        {
            var accountInfo = success.AccountInfo;
            _userNameText.text = accountInfo.Username;
            _timeInGame.text = (DateTime.UtcNow - accountInfo.Created).TotalDays.ToString("N2");
        }
    }
}