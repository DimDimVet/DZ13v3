using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Healt : MonoBehaviour
{
    public HealtSetting SettingsData;
    //[Inject] private IRegistrator dataReg;//получим данные управления в структуре
    /*[HideInInspector]*/ public int HealtCount = 0;
    [HideInInspector] public int Damage;
    [HideInInspector] public bool Dead = false;
    public string dataTest;
    void Start()
    {
        HealtCount=SettingsData.Healt;
    }

    void Update()
    {
        if (Damage!=0)
        {
            HealtContoll(Damage);
            Damage=0;
        }
    }
    public void HealtContoll(int damage)
    {
        HealtCount -= damage;
        if (HealtCount<=0)
        {
            Dead = true;
            Destroy(gameObject, 1);
        }
    }
}
