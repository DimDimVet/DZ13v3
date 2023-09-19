using UnityEngine;
using Zenject;

public class RegistratorInstaller : MonoInstaller
{
    [Inject] private SetPrifab setPrifab;
    public override void InstallBindings()
    {
        Container.Bind<IRegistrator>().To<RegistratorExecutor>().AsSingle().NonLazy();//инициализируем точку входа исполнителя ExecutorZenject

        Container.BindFactory<Bull, Bull.Factory>().FromComponentInNewPrefab(setPrifab.SetObject);
    }
}
