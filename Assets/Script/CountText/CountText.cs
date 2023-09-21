using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CountText : MonoBehaviour
{
    [SerializeField] private Text textHealt;
    [SerializeField] private Text textCountBull;

    private IRegistrator dataReg;
    private RegistratorConstruction rezultListPlayer;

    void Start()
    {
        dataReg = new RegistratorExecutor();//доступ к листу
        rezultListPlayer = dataReg.GetDataPlayer();
    }

    void Update()
    {
        if (rezultListPlayer.CurrentHash)
        {
            if (rezultListPlayer.PlayerHealt == null)
            {
                rezultListPlayer = dataReg.GetDataPlayer();
                return;
            }

            if (rezultListPlayer.ShootPlayer == null)
            {
                rezultListPlayer = dataReg.GetDataPlayer();
                return;
            }

            if (rezultListPlayer.PlayerHealt != null)
            {
                textHealt.text = $"{rezultListPlayer.PlayerHealt.HealtCount}";
            }
            if (rezultListPlayer.ShootPlayer != null)
            {
                textCountBull.text = $"{rezultListPlayer.ShootPlayer.CountBull}";
            }
        }
       
    }
}
