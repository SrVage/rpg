using UnityEngine;
using Zenject;

namespace Code.UI.Presenter
{
    public class UIInstaller:MonoInstaller
    {
        [SerializeField] private GameplayUIPresenter _gameplayUIPresenter;

        public override void InstallBindings()
        {
            Container.Bind<GameplayUIPresenter>().FromComponentInNewPrefab(_gameplayUIPresenter).AsSingle();
        }
    }
}