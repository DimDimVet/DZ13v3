using Photon.Pun;
using System.Collections;
using UnityEngine;
using Zenject;

public class ShootPlayer : MonoBehaviour
{
    //[Inject] private IUserInput userInput;//������� ������ � ���������
    //[Inject] private Bull.Factory bullFactory;//��������� ������� Bull
    //[Inject] private IRegistrator dataReg;
    ////
    //public ActionSettings ActionSettings;
    ////
    //[HideInInspector] public int CountBull;
    ////[SerializeField] private GameObject bullet;
    //[SerializeField] private Transform outBullet;

    //[SerializeField] private ParticleSystem gunExitParticle;//������� ������

    ////������� � ���� �������� �������

    //private float shootDelay;
    //private float shootTime = float.MinValue;

    //private void Start()
    //{
    //    //if (PhotonView.Get(this.gameObject).IsMine)//�������� ����� �����, ������� �� ������ ��� �������� ����������
    //    //{
    //    //    entityManager.AddComponentData(entity, new InputData());//������� � �������� ��������� �����
    //    //}

    //    dataReg.OutPos = outBullet;
    //    shootDelay =ActionSettings.ShootDelay;
    //    StartCoroutine(Example());
    //}

    //void Update()
    //{
    //    if (userInput.InputData.Shoot != 0)//������� �������
    //    {
    //        Shoot();
    //    }
    //}
    //private IEnumerator Example()
    //{
    //    int i = 0;
    //    while (i < 3)
    //    {
    //        yield return new WaitForSeconds(0.2f);
    //        i++;
    //    }
    //}

    //public void Shoot()
    //{
    //    if (Time.time < shootTime + shootDelay)
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        shootTime = Time.time;
    //    }

    //    bullFactory.Create();
    //    CountBull++;
    //    //Instantiate(bullet, outBullet.position, outBullet.rotation);
    //    gunExitParticle.Play();

    //}
}
