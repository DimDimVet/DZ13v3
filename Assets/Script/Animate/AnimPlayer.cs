using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class AnimPlayer : MonoBehaviour
{
    [SerializeField] private AnimSettings animSettings;

    private int hashGO;
    private IRegistrator dataReg;
    private RegistratorConstruction rezultListInput;

    //anim
    private float speed;
    private string animSpeed;
    private string animJamp;
    private string animDead;

    private Animator animator;
    
    private float refDistance = 0.01f;
    private float2 distans;

    void Start()
    {
        hashGO=gameObject.GetHashCode();
        animator =gameObject.GetComponent<Animator>();

        //ищем управление
        dataReg = new RegistratorExecutor();//доступ к листу
        rezultListInput = dataReg.GetData(hashGO);

        speed = animSettings.Speed;
        animSpeed = animSettings.AnimSpeed;
        animJamp = animSettings.AnimJamp;
        animDead = animSettings.AnimDead;
    }

    private bool ControlGO(int hashGO)
    {
        if (rezultListInput.Hash==hashGO)//доп проверка
        {
            if (rezultListInput.HealtObj!=null)
            {
                return rezultListInput.HealtObj.Dead;
            }
            if (rezultListInput.PlayerHealt!=null)
            {
                return rezultListInput.PlayerHealt.Dead;
            }
        }
        return false;
    }
    void Update()
    {
        if (rezultListInput.UserInput == null)
        {
            rezultListInput = dataReg.GetData(hashGO);
            return;
        }

        if (animator != null)
        {
            distans.x = Mathf.Abs(rezultListInput.UserInput.InputData.Move.x);
            distans.y = Mathf.Abs(rezultListInput.UserInput.InputData.Move.y);

            if (distans.x >= refDistance | distans.y >= refDistance)
            {
                animator.SetFloat(animSpeed, speed * math.distancesq(distans.x, -distans.y));
            }
            else
            {
                animator.SetFloat(animSpeed, 0);
            }

            //pull
            //реакция на изменеия, запустим анимацию 
            if (rezultListInput.UserInput.InputData.Pull > 0f)
            {
                animator.SetBool(animJamp, true);
            }
            else
            {
                animator.SetBool(animJamp, false);
            }

            ////dead
            if (ControlGO(hashGO))
            {
                animator.SetBool(animDead, true);
            }
        }
        else
        {
            Debug.LogError("Нет компонента Аниматор");
        }

    }
}
