using Code.UI.View;
using UnityEngine;
using Zenject;

namespace Code.UI.Presenter
{
    public class UIInstaller:MonoInstaller
    {
        [SerializeField] private GameplayUIPresenter _gameplayUIPresenter;
        [SerializeField] private PlayfabCharacterPresenter _playfabCharacterPresenter;
        [SerializeField] private GamePauseMenuPresenter _gamePauseMenuPresenter;
        [SerializeField] private PlayerCharacteristicsPresenter _playerCharacteristicsPresenter;
        [SerializeField] private ConnectStatusView _connectStatusView;

        public override void InstallBindings()
        {
            Container.Bind<GameplayUIPresenter>().FromComponentInNewPrefab(_gameplayUIPresenter).AsSingle();
            Container.Bind<PlayfabCharacterPresenter>().FromComponentInNewPrefab(_playfabCharacterPresenter).AsSingle().NonLazy();
            Container.Bind<GamePauseMenuPresenter>().FromComponentInNewPrefab(_gamePauseMenuPresenter).AsSingle();
            Container.Bind<PlayerCharacteristicsPresenter>().FromComponentInNewPrefab(_playerCharacteristicsPresenter).AsSingle();
            Container.Bind<ConnectStatusView>().FromComponentInNewPrefab(_connectStatusView).AsSingle();
        }
    }
}