using System;
using System.Xml.Schema;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class CameraMove : MonoBehaviour
{
    [HideInInspector] public float2 AngleCamera;
    [HideInInspector] public Transform GetTransformPointCamera;
    //
    [SerializeField] private CameraSettings cameraSettings;

    private IRegistrator dataReg;
    private RegistratorConstruction rezultList;

    private float2 inputMouse;
    private float yRot;
    private float mouseSensor;
    private float minStopAngle;
    private float maxStopAngle;
    private Vector3 setPos;



    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        setPos = transform.position;
        //settings
        mouseSensor = cameraSettings.MouseSensor;
        minStopAngle = cameraSettings.MinStopAngle;
        maxStopAngle = cameraSettings.MaxStopAngle;
        //
        //originRotation = transform.rotation;

        //Найдем источника мыши управления камерой
        dataReg = new RegistratorExecutor();//доступ к листу
        rezultList = dataReg.GetDataUserInput();

    }

    void Update()
    {
        if (rezultList.UserInput == null)
        {
            rezultList = dataReg.GetDataUserInput();
            return;
        }
        inputMouse = rezultList.UserInput.InputData.Mouse;


        AngleCamera = inputMouse * mouseSensor * Time.deltaTime;
        yRot -= AngleCamera.y;
        yRot = Math.Clamp(yRot, minStopAngle, maxStopAngle);
        transform.localRotation = Quaternion.Euler(yRot, 0, 0);

        if (GetTransformPointCamera != null)
        {
            transform.position = GetTransformPointCamera.position/*+setPos*/;//получим позицию объекта привязки
            transform.rotation = GetTransformPointCamera.rotation;
        }

    }
}
