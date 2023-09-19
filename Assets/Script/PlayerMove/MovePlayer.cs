using Unity.Mathematics;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //Класс движения персонажем, получаем из UserInput, цепляем на персонаж
    private UserInput userInput;

    [SerializeField] private MoveSettings moveSettings;
    [SerializeField] private Transform cameraPoint;

    private IRegistrator dataReg;
    private RegistratorConstruction rezultList;

    private float speedMove;
    private Transform transformCamera;
    private float2 angleCamera;

    void Start()
    {
        userInput = GetComponent<UserInput>();
        speedMove = moveSettings.SpeedMove;
        //ищем камеру
        dataReg = new RegistratorExecutor();//доступ к листу
        rezultList = dataReg.GetDataCamera();

    }

    void Update()
    {
        if (rezultList.CameraMove == null)
        {
            rezultList = dataReg.GetDataCamera();
            return;
        }

        rezultList.CameraMove.GetTransformPointCamera= transformCamera;
        angleCamera = rezultList.CameraMove.AngleCamera;

        transform.Rotate(Vector3.up, angleCamera.x);//поворот мышью
        transformCamera=cameraPoint;

        if (userInput.InputData.Move.y > 0)
        {
            Vector3 currentPosition = transform.position;
            currentPosition += transform.forward / speedMove;
            transform.position = currentPosition;
        }
        if (userInput.InputData.Move.y < 0)
        {
            Vector3 currentPosition = transform.position;
            currentPosition -= transform.forward / speedMove;
            transform.position = currentPosition;
        }

        if (userInput.InputData.Move.x > 0)
        {
            Vector3 currentPosition = transform.position;
            currentPosition += transform.right / speedMove;
            transform.position = currentPosition;
        }
        if (userInput.InputData.Move.x < 0)
        {
            Vector3 currentPosition = transform.position;
            currentPosition -= transform.right / speedMove;
            transform.position = currentPosition;
        }

    }
}

