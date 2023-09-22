using System;
using Unity.Mathematics;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    
    [HideInInspector] public float2 AngleCamera;
    [HideInInspector] public Transform GetTransformPointCamera;
    //
    [SerializeField] private CameraSettings cameraSettings;

    private IRegistrator dataReg;
    private RegistratorConstruction rezultListInput;

    private float2 inputMouse;
    private float yRot;
    private float mouseSensor;
    private float minStopAngle;
    private float maxStopAngle;
    private Vector3 setPos;

    private Vector3 posPlayer;

    private bool isRun;
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //setPos = transform.position;
        setPos = transform.position;
        //settings
        mouseSensor = cameraSettings.MouseSensor;
        minStopAngle = cameraSettings.MinStopAngle;
        maxStopAngle = cameraSettings.MaxStopAngle;
        //
        //originRotation = transform.rotation;

        //������ ��������� ���� ���������� �������
        //dataReg = new RegistratorExecutor();//������ � �����
        //rezultListInput = dataReg.GetDataPlayer();

    }
    public void ConnectPlayer(RegistratorConstruction player)
    { //������ ��������� ���� ���������� �������
        rezultListInput=player;
    }

    void Update()
    {
        posPlayer=rezultListInput.UserInput.transform.position;


        if (isRun==false) 
        {
            //rezultListInput = dataReg.GetDataPlayer();
            var hashCamera= dataReg.GetDataCamera();
            if (hashCamera.PhotonHash== rezultListInput.PhotonHash)
            {
                Debug.Log(hashCamera.Hash +""+ hashCamera.PhotonHash);
                isRun = rezultListInput.PhotonHash;
            }
            rezultListInput = dataReg.GetDataPlayer();
        }

        if (isRun)
        {
            inputMouse = rezultListInput.UserInput.InputData.Mouse;

            AngleCamera = inputMouse * mouseSensor * Time.deltaTime;
            yRot -= AngleCamera.y;
            yRot = Math.Clamp(yRot, minStopAngle, maxStopAngle);
            transform.localRotation = Quaternion.Euler(yRot, 0, 0);

            if (GetTransformPointCamera != null)
            {
                transform.position = GetTransformPointCamera.position/*+setPos*/;//������� ������� ������� ��������
                transform.rotation = GetTransformPointCamera.rotation;
            }
        }

    }
}
