using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerSample;
    public List<Transform> SpawnPonts;
    //
    //public List<GameObject> InterObject;
    //public List<Transform> InterTransformObject;

    void Start()
    {
        //PlayerSample.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();//�������� �������� ������-������
    }

    //������� � �������� OnConnectedToMaster() ��� �������� ��������� ������-�������
    public override void OnConnectedToMaster()
    {
        //������� �������.��������, ������� ���������, ������ ��������
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 4,
            IsVisible = false
        };
        //��� ������, ���� �������, ��� �� ��������� - ������� � �������.�����������
        PhotonNetwork.JoinOrCreateRoom("TestDZ13", roomOptions, TypedLobby.Default);
    }

    //������� � �������� OnJoinedRoom()
    public override void OnJoinedRoom()
    {
        int id = PhotonNetwork.LocalPlayer.ActorNumber;
        Debug.Log("��������� ����� �� id" + id + " - � ������� " + PhotonNetwork.CurrentRoom.PlayerCount);
        //�������� �� ������ ����������
        if (id > (SpawnPonts.Count+1))
        {
            Debug.Log("��� ��������� �����");
        }
        else
        {
            //for (int i = 0; i < InterTransformObject.Count; i++)
            //{
            //    PhotonNetwork.Instantiate(InterObject[i].name, InterTransformObject[i].position, Quaternion.identity);
            //}
           // PhotonNetwork.Instantiate(ObjectSample.name, Transform.position, Quaternion.identity);

            //PlayerSample.SetActive(true);
            //PlayerSample.transform.position = SpawnPonts[id - 1].position;
            //PlayerSample.transform.rotation = Quaternion.identity;
            //���� ��, �� ������� ������ � ����� ������ �� �����
            PhotonNetwork.Instantiate(PlayerSample.name, SpawnPonts[id - 1].position, Quaternion.identity);
        }
    }

    public void SayHello()//������� ������ ��������� �������� �����
    {
        //����� photonView �������� ����������� ������, ��������� ��������� �� gameobject(�����������) � �������
        //������ ��������� � ����������:�������������

        //��� ������ ������,������ ��������,������ ������������ ���������(� ������� ����� ���� ���������� �������)
        this.photonView.RPC("Hello", RpcTarget.All, (byte)PhotonNetwork.LocalPlayer.ActorNumber);
    }

    [PunRPC]//��� ���� ���� ����� ���� � ������ ������
    public void Hello(byte playerId)
    {
        Debug.Log($"����� ID {playerId} ������� ������");
    }
    void Update()
    {

    }
}
