using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealt : MonoBehaviour
{
    [SerializeField] private HealtSetting settingsData;

    [HideInInspector] public int HealtCount = 0;
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
            HealtContoll(Damage);
            Damage = 0;
        }
    }
    public void HealtContoll(int damage)
    {
        HealtCount -= damage;
        if (HealtCount <= 0)
        {
            Dead = true;
            Destroy(gameObject, 1);
        }
    }
}
