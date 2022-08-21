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
        private readonly PlayersClassesConfig _classesConfig = null;
        private readonly PlayfabCharacterPresenter _playfabCharacterPresenter = null;
        private readonly IChoosePlayerService _choosePlayerService = null;
        private List<CharacterResult> _characters = new();
        private List<PlayerClass> _characterInfos = new List<PlayerClass>();

        public PlayfabCharacterService(PlayersClassesConfig classesConfig, 
            PlayfabCharacterPresenter playfabCharacterPresenter,
            IChoosePlayerService choosePlayerService)
        {
            _classesConfig = classesConfig;
            _playfabCharacterPresenter = playfabCharacterPresenter;
            _choosePlayerService = choosePlayerService;
        }
        public void UpdateCharacterStatistics(int player)
        {
            PlayFabClientAPI.UpdateCharacterStatistics(new UpdateCharacterStatisticsRequest
                {
                    CharacterId = _characters[player].CharacterId,
                    CharacterStatistics = new Dictionary<string, int>
                    {
                        {"Class", (int)_characterInfos[player].Class},
                        {"Level", _characterInfos[player].Level},
                        {"XP", _characterInfos[player].XP},
                        {"Damage", _characterInfos[player].Damage},
                        {"Health", _characterInfos[player].Health},
                    }
                }, result =>
                {
                    Debug.Log($"Initial stats set, telling client to update character list");
                    GetCharacters();
                },
                Debug.LogError);
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
                                    Avatar =  _classesConfig.Players[statistic["Class"]].Avatar
                                });
                            },
                            error => Debug.Log(error.Error));
                    }
                    SendStatistic();
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