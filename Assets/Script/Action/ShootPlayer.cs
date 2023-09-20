using System.Collections;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    //
    [SerializeField] private ActionSettings actionSettings;
    //
    private int hashGO;
    private IRegistrator dataReg;
    private RegistratorConstruction rezultListInput;

    [HideInInspector] public int CountBull;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform outBullet;

    [SerializeField] private ParticleSystem gunExitParticle;//система частиц

    //соберем в лист стороние скрипты

    private float shootDelay;
    private float shootTime = float.MinValue;

    private void Start()
    {

        //ищем управление
        hashGO=gameObject.GetHashCode();
        dataReg = new RegistratorExecutor();//доступ к листу
        rezultListInput = dataReg.GetData(hashGO);

        dataReg.OutPos = outBullet;
        shootDelay =actionSettings.ShootDelay;
        StartCoroutine(Example());
    }

    void Update()
    {
        if (rezultListInput.UserInput == null)
        {
            rezultListInput = dataReg.GetData(hashGO);
            return;
        }

        if (rezultListInput.UserInput.InputData.Shoot != 0)//получим нажатие
        {
            Shoot();
        }
    }
    private IEnumerator Example()
    {
        int i = 0;
        while (i < 3)
        {
            yield return new WaitForSeconds(0.2f);
            i++;
        }
    }

    public void Shoot()
    {
        if (Time.time < shootTime + shootDelay)
        {
            return;
        }
        else
        {
            shootTime = Time.time;
        }

        //bullFactory.Create();
        CountBull++;
        Instantiate(bullet, outBullet.position, outBullet.rotation);
        gunExitParticle.Play();

    }
}
