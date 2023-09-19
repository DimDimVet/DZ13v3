using UnityEngine;
using Zenject;

public class Registrator : MonoBehaviour
{
    private IRegistrator dataReg;
    private void Awake()
    {
        dataReg = new RegistratorExecutor();  
        RegistratorConstruction registrator = new RegistratorConstruction
        {
            Hash=gameObject.GetHashCode(),
            HealtObj=GetComponent<Healt>(),
            PlayerHealt=GetComponent<PlayerHealt>(),
            ShootPlayer=GetComponent<ShootPlayer>(),
            CameraMove=GetComponent<CameraMove>(),
            UserInput=GetComponent<UserInput>(),
            
        };

        dataReg.SetData(registrator);
    }
}
