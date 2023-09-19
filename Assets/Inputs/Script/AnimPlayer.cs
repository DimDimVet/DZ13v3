using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class AnimPlayer : MonoBehaviour
{
    //[Inject] private IUserInput userInput;//получим данные в структуре
    //[Inject] private IRegistrator dataReg;//получим данные управления в структуре

    //private int hashGO;
    //private RegistratorConstruction dataList;
    ////anim
    //private float speed;
    //private string animSpeed;
    //private string animJamp;
    //private string animDead;

    //private Animator animator;
    //public AnimSettings AnimSettings;

    //private float refDistance = 0.01f;
    //private float2 distans;

    //void Start()
    //{
    //    hashGO=gameObject.GetHashCode();

    //    animator =gameObject.GetComponent<Animator>();

    //    speed = AnimSettings.Speed;
    //    animSpeed = AnimSettings.AnimSpeed;
    //    animJamp = AnimSettings.AnimJamp;
    //    animDead = AnimSettings.AnimDead;
    //}

    //private bool ControlGO(int hashGO)
    //{
    //    if (dataList.Hash==hashGO)//доп проверка
    //    {
    //        if (dataList.HealtObj!=null)
    //        {
    //            return dataList.HealtObj.Dead;
    //        }
    //        if (dataList.PlayerHealt!=null)
    //        {
    //            return dataList.PlayerHealt.Dead;
    //        }
    //    }
    //    return false;
    //}
    //void Update()
    //{
    //    if (animator != null)
    //    {
    //        distans.x = Mathf.Abs(userInput.InputData.Move.x);
    //        distans.y = Mathf.Abs(userInput.InputData.Move.y);

    //        if (distans.x >= refDistance | distans.y >= refDistance)
    //        {
    //            animator.SetFloat(animSpeed, speed * math.distancesq(distans.x, -distans.y));
    //        }
    //        else
    //        {
    //            animator.SetFloat(animSpeed, 0);
    //        }

    //        //pull
    //        //реакция на изменеия, запустим анимацию 
    //        if (userInput.InputData.Pull > 0f)
    //        {
    //            animator.SetBool(animJamp, true);
    //        }
    //        else
    //        {
    //            animator.SetBool(animJamp, false);
    //        }

    //        ////dead
    //        if (ControlGO(hashGO))
    //        {
    //            animator.SetBool(animDead, true);
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("Нет компонента Аниматор");
    //    }

    //}
}
