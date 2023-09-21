using Photon.Pun;
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

        if (PhotonView.Get(this.gameObject) is PhotonView)
        {
            if (PhotonView.Get(this.gameObject).IsMine)
            {
                registrator.CurrentHash=true;
            }
            else
            {
                registrator.CurrentHash=false;
            }
        }
        else
        {
            registrator.CurrentHash=false;
        }

        dataReg.SetData(registrator);
    }
}
