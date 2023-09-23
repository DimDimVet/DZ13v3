using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealt : MonoBehaviour
{
    [SerializeField] private HealtSetting settingsData;

    [HideInInspector] public int HealtCount;
    [HideInInspector] public int Damage;
    [HideInInspector] public bool Dead = false;
    void Start()
    {
        if (settingsData.Healt != 0)
        {
            HealtCount = settingsData.Healt;
        }
    }

    void Update()
    {

            if (Damage != 0)
            {
                //HealtContoll(Damage);
                HealtCount-=Damage;
                if (HealtCount <= 0)
                {
                    Dead = true;
                    Destroy(gameObject, 1);
                }
                Damage = 0;
            }
        Debug.Log(HealtCount);

    }
    //public void HealtContoll(int damage)
    //{
    //    HealtCount=StartHealt - damage;
    //    if (HealtCount <= 0)
    //    {
    //        Dead = true;
    //        Destroy(gameObject, 1);
    //    }
    //}
}
