using Unity.Mathematics;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private MoveSettings moveSettings;
    [SerializeField] private Transform cameraPoint;

    private IRegistrator dataReg;
    private RegistratorConstruction rezultListCamera;
    private RegistratorConstruction rezultListInput;

    private float speedMove;
    private Transform transformCamera;
    private float2 angleCamera;

    void Start()
    {
        speedMove = moveSettings.SpeedMove;
        //ищем камеру и управление
        dataReg = new RegistratorExecutor();//доступ к листу
        rezultListInput = dataReg.GetDataUserInput();
        rezultListCamera = dataReg.GetDataCamera();

    }

    void Update()
    {
        if (rezultListCamera.CameraMove == null)
        {
            rezultListCamera = dataReg.GetDataCamera();
            return;
        }
        if (rezultListInput.UserInput == null)
        {
            rezultListInput = dataReg.GetDataUserInput();
            return;
        }

        if (rezultListInput.CurrentHash)
        {
            rezultListCamera.CameraMove.GetTransformPointCamera= transformCamera;
            angleCamera = rezultListCamera.CameraMove.AngleCamera;

            transform.Rotate(Vector3.up, angleCamera.x);//поворот мышью
            transformCamera=cameraPoint;


            if (rezultListInput.UserInput.InputData.Move.y > 0)
            {
                Vector3 currentPosition = transform.position;
                currentPosition += transform.forward / speedMove;
                transform.position = currentPosition;
            }
            if (rezultListInput.UserInput.InputData.Move.y < 0)
            {
                Vector3 currentPosition = transform.position;
                currentPosition -= transform.forward / speedMove;
                transform.position = currentPosition;
            }

            if (rezultListInput.UserInput.InputData.Move.x > 0)
            {
                Vector3 currentPosition = transform.position;
                currentPosition += transform.right / speedMove;
                transform.position = currentPosition;
            }
            if (rezultListInput.UserInput.InputData.Move.x < 0)
            {
                Vector3 currentPosition = transform.position;
                currentPosition -= transform.right / speedMove;
                transform.position = currentPosition;
            }
        }

    }
}

