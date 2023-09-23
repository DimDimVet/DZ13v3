using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerSample;
    public List<Transform> SpawnPonts;
    private int id;

    void Awake()
    {
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
        id = PhotonNetwork.LocalPlayer.ActorNumber;

        //�������� �� ������ ����������
        if (id > (SpawnPonts.Count + 1))
        {
            Debug.Log("��� ��������� �����");
        }
        else
        {
            GameObject tr = PhotonNetwork.Instantiate(PlayerSample.name, SpawnPonts[id - 1].position, Quaternion.identity);
            tr.name = $"Id {id}";
            //GlobalList.PhotonIdPlayer = id;
            // Debug.Log("��������� ����� �� id" + id + " " + PhotonView.Get(this.gameObject).IsMine + " " + PhotonView.Get(this.gameObject).GetHashCode() + " - � ������� " + PhotonNetwork.CurrentRoom.PlayerCount);
            
            

        }
    }
    void Update()
    {

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

}
