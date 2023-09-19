using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;


[CreateAssetMenu(fileName = "SetInstaller", menuName = "Installers/SetInstaller")]
public class SetInstaller : ScriptableObjectInstaller<SetInstaller>
{
    public SetPrifab setPrifab;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SetPrifab>().FromInstance(setPrifab).AsSingle();
    }
}
