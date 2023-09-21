using Photon.Pun;
using UnityEngine;
using Zenject;

public class Registrator : MonoBehaviour
{
    private IRegistrator dataReg;
    RegistratorConstruction registrator;
    private void Start()
    {
        dataReg = new RegistratorExecutor();
        registrator = new RegistratorConstruction
        {
            Hash = gameObject.GetHashCode(),
            HealtObj = GetComponent<Healt>(),
            PlayerHealt = GetComponent<PlayerHealt>(),
            ShootPlayer = GetComponent<ShootPlayer>(),
            CameraMove = GetComponent<CameraMove>(),
            UserInput = GetComponent<UserInput>(),
        };

        if (PhotonView.Get(this.gameObject) is PhotonView)
        {
            registrator.PhotonHash = PhotonView.Get(this.gameObject).IsMine;
            registrator.Hash = GlobalList.PhotonIdPlayer;
        }

        if (registrator.CameraMove!=null && registrator.PhotonHash==false)
        {
            IRegistrator dataReg=new RegistratorExecutor();
            RegistratorConstruction rezultListInput = dataReg.GetDataPlayer();
            registrator.PhotonHash = rezultListInput.PhotonHash;
        }

        dataReg.SetData(registrator);
    }
    private void Update()
    {
        if (registrator.CameraMove != null && registrator.PhotonHash == false)
        {
            IRegistrator dataReg = new RegistratorExecutor();
            RegistratorConstruction rezultListInput = dataReg.GetDataPlayer();
            registrator.PhotonHash = rezultListInput.PhotonHash;
            dataReg.SetDataCameraReLoad(registrator);
        }
    }
}
