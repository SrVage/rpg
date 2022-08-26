using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Abstract;
using Code.Abstract.Interfaces;
using Code.Config;
using Code.UI.Presenter;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Code.Services
{
    internal sealed class PlayfabCharacterService:IPlayfabCharacterService
    {
        private const string ItemID = "SteelSword";
        private readonly PlayersClassesConfig _classesConfig = null;
        private readonly PlayfabCharacterPresenter _playfabCharacterPresenter = null;
        private readonly IChoosePlayerService _choosePlayerService = null;
        private List<CharacterResult> _characters = new();
        private List<PlayerClass> _characterInfos = new List<PlayerClass>();
        private string _characterName;
        private int _health;
        private int _damage;
        private int _selectClass;
        private Action _action;

        public PlayfabCharacterService(PlayersClassesConfig classesConfig, 
            PlayfabCharacterPresenter playfabCharacterPresenter,
            IChoosePlayerService choosePlayerService)
        {
            _classesConfig = classesConfig;
            _playfabCharacterPresenter = playfabCharacterPresenter;
            _choosePlayerService = choosePlayerService;
            _playfabCharacterPresenter.GetService(this);
        }

        public void GetCharacters()
        {
            PlayFabClientAPI.GetAllUsersCharacters(new ListUsersCharactersRequest(),
                res =>
                {
                    Debug.Log($"Characters owned: + {res.Characters.Count}");
                    if (_characters.Count > 0)
                    {
                        _characters.Clear();
                        _characterInfos.Clear();
                    }
                    foreach (var characterResult in res.Characters)
                    {
                        _characters.Add(characterResult);
                        PlayFabClientAPI.GetCharacterStatistics(new GetCharacterStatisticsRequest()
                            {
                                CharacterId = characterResult.CharacterId
                            },
                            res =>
                            {
                                var statistic = res.CharacterStatistics;
                                Debug.Log(characterResult.CharacterName);
                                _characterInfos.Add(new PlayerClass()
                                {
                                    Class = (PlayersClasses)statistic["Class"],
                                    PlayerName = characterResult.CharacterName,
                                    Level = statistic["Level"],
                                    XP = statistic["XP"],
                                    Health = statistic["Health"],
                                    Damage = statistic["Damage"],
                                    Avatar =  _classesConfig.Players[statistic["Class"]].Avatar,
                                    CharacterID = characterResult.CharacterId,
                                    BattlesWin = statistic["BattlesWin"],
                                });
                            },
                            error => Debug.Log(error.Error));
                    }
                    SendStatistic();
                }, 
                Debug.LogError);
        }

        public void CreateCharacter(string name, int health, int damage, int selectClass, Action end)
        {
            _characterName = name;
            _health = health;
            _damage = damage;
            _selectClass = selectClass;
            _action = end;
            MakePurchase();
        }

        private void MakePurchase() {
            PlayFabClientAPI.PurchaseItem(new PurchaseItemRequest {
                CatalogVersion = "Things",
                ItemId = ItemID,
                Price = 0,
                VirtualCurrency = "GC"
            }, LogSuccess, LogFailure);
        }

        private void LogFailure(PlayFabError obj)
        {
        }

        private void LogSuccess(PurchaseItemResult obj) => 
            CreateCharacterWithItemId();

        private void CreateCharacterWithItemId()
        {
            
            PlayFabClientAPI.GrantCharacterToUser(new GrantCharacterToUserRequest
            {
                CharacterName = _characterName,
                ItemId = ItemID
            }, result =>
            {
                UpdateNewCharacterStatistics(result.CharacterId);
            }, Debug.LogError);
        }

        public void UpdateCharacterStatistics()
        {
            PlayFabClientAPI.UpdateCharacterStatistics(new UpdateCharacterStatisticsRequest
                {
                    CharacterId = _choosePlayerService.GetPlayer.CharacterID,
                    CharacterStatistics = new Dictionary<string, int>
                    {
                        {"Class", (int)_choosePlayerService.GetPlayer.Class},
                        {"Level", _choosePlayerService.GetPlayer.Level},
                        {"XP", _choosePlayerService.GetPlayer.XP},
                        {"Damage", _choosePlayerService.GetPlayer.Damage},
                        {"Health", _choosePlayerService.GetPlayer.Health},
                        {"BattlesWin", _choosePlayerService.GetPlayer.BattlesWin},
                    }
                }, result =>
                {
                    Debug.Log($"Initial stats set, telling client to update character list");
                },
                Debug.LogError);
        }

        public void UpdateNewCharacterStatistics(string characterId)
        {
            PlayFabClientAPI.UpdateCharacterStatistics(new UpdateCharacterStatisticsRequest
                {
                    CharacterId = characterId,
                    CharacterStatistics = new Dictionary<string, int>
                    {
                        {"Class", _selectClass},
                        {"Level", 0},
                        {"XP", 0},
                        {"Damage", _damage},
                        {"Health", _health},
                        {"BattlesWin", 0},
                    }
                }, result =>
                {
                    _action.Invoke();
                    _action = null;
                    GetCharacters();
                },
                Debug.LogError);
        }

        public void SelectCharacter(int id) => 
            _choosePlayerService.SetPlayer(_characterInfos[id]);

        private async void SendStatistic()
        {
            await Task.Delay(1000);
            _playfabCharacterPresenter.ShowCharacters(_characterInfos);
        }
    }
}