using UnityEngine;
using Zenject;

public class PullPlayer : MonoBehaviour
{
    //[Inject] private IUserInput userInput;//получим данные в структуре
    ////
    //public MoveSettings MoveSettings;

    //private Rigidbody rigidbodyObj;
    //private float force, height;
    //public Transform[] PointGnd;
    //private LayerMask groundLayer;

    //private float shootDelay;
    //private float shootTime = float.MinValue;
    //void Start()
    //{
    //    force = MoveSettings.Force;
    //    height = MoveSettings.Height;
    //    groundLayer = MoveSettings.GroundLayer;
    //    shootDelay= MoveSettings.ShootDelay;

    //    rigidbodyObj = gameObject.GetComponent<Rigidbody>();
    //}

    //void Update()
    //{
    //    if (userInput.InputData.Pull != 0)//получим нажатие
    //    {
    //        Jamp();
    //    }
    //}

    //public void Jamp()
    //{
    //    if (Time.time < shootTime + shootDelay)
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        shootTime = Time.time;
    //    }

    //    if (GndControl())
    //    {
    //        Vector3 tempVector = transform.forward;
    //        tempVector.y = height;
    //        tempVector.z = tempVector.z * force;
    //        tempVector.x = tempVector.x * force;

    //        rigidbodyObj.AddForce(tempVector, ForceMode.Impulse);
    //    }

    //}
    //private bool GndControl()
    //{
    //    for (int i = 0; i < PointGnd.Length; i++)//переберем все точки-датчики контакта с GND
    //    {
    //        if (Physics.CheckSphere(PointGnd[i].position, 0.1f, groundLayer, QueryTriggerInteraction.Ignore))
    //        {
    //            return true;
    //        }
    //    }
    //    return true;
    //}
}
