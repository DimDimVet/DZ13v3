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

    [SerializeField] private ParticleSystem gunExitParticle;//������� ������

    //������� � ���� �������� �������

    private float shootDelay;
    private float shootTime = float.MinValue;

    private void Start()
    {

        //���� ����������
        hashGO=gameObject.GetHashCode();
        dataReg = new RegistratorExecutor();//������ � �����
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

        if (rezultListInput.UserInput.InputData.Shoot != 0)//������� �������
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
