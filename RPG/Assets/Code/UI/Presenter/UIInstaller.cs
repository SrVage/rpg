using UnityEngine;
using Zenject;

namespace Code.UI.Presenter
{
    public class UIInstaller:MonoInstaller
    {
        [SerializeField] private GameplayUIPresenter _gameplayUIPresenter;
        [SerializeField] private PlayfabCharacterPresenter _playfabCharacterPresenter;
        [SerializeField] private GamePauseMenuPresenter _gamePauseMenuPresenter;

        public override void InstallBindings()
        {
            Container.Bind<GameplayUIPresenter>().FromComponentInNewPrefab(_gameplayUIPresenter).AsSingle();
            Container.Bind<PlayfabCharacterPresenter>().FromComponentInNewPrefab(_playfabCharacterPresenter).AsSingle().NonLazy();
            Container.Bind<GamePauseMenuPresenter>().FromComponentInNewPrefab(_gamePauseMenuPresenter).AsSingle();
        }
    }
}