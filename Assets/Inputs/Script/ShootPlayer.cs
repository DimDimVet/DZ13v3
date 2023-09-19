using Photon.Pun;
using System.Collections;
using UnityEngine;
using Zenject;

public class ShootPlayer : MonoBehaviour
{
    //[Inject] private IUserInput userInput;//получим данные в структуре
    //[Inject] private Bull.Factory bullFactory;//подключим фабрику Bull
    //[Inject] private IRegistrator dataReg;
    ////
    //public ActionSettings ActionSettings;
    ////
    //[HideInInspector] public int CountBull;
    ////[SerializeField] private GameObject bullet;
    //[SerializeField] private Transform outBullet;

    //[SerializeField] private ParticleSystem gunExitParticle;//система частиц

    ////соберем в лист стороние скрипты

    //private float shootDelay;
    //private float shootTime = float.MinValue;

    //private void Start()
    //{
    //    //if (PhotonView.Get(this.gameObject).IsMine)//проверим через фотон, текущий ли объект при передачи управления
    //    //{
    //    //    entityManager.AddComponentData(entity, new InputData());//добавим в сущность стурктуру ввода
    //    //}

    //    dataReg.OutPos = outBullet;
    //    shootDelay =ActionSettings.ShootDelay;
    //    StartCoroutine(Example());
    //}

    //void Update()
    //{
    //    if (userInput.InputData.Shoot != 0)//получим нажатие
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
