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
        PhotonNetwork.ConnectUsingSettings();//запустим тестовый мастер-сервер
    }

    //возьмем в родителе OnConnectedToMaster() для создания тестового мастер-сервера
    public override void OnConnectedToMaster()
    {
        //создали экземпл.настроек, выбрали настройку, задали значение
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 4,
            IsVisible = false
        };
        //при старте, ищет комнату, при ее отсутсвии - создает с предуст.настройками
        PhotonNetwork.JoinOrCreateRoom("TestDZ13", roomOptions, TypedLobby.Default);
    }

    //возьмем в родителе OnJoinedRoom()
    public override void OnJoinedRoom()
    {
        id = PhotonNetwork.LocalPlayer.ActorNumber;

        //проверим на ошибку количества
        if (id > (SpawnPonts.Count + 1))
        {
            Debug.Log("Нет свободной точки");
        }
        else
        {
            GameObject tr = PhotonNetwork.Instantiate(PlayerSample.name, SpawnPonts[id - 1].position, Quaternion.identity);
            tr.name = $"Id {id}";
            //GlobalList.PhotonIdPlayer = id;
            // Debug.Log("Подключен игрок по id" + id + " " + PhotonView.Get(this.gameObject).IsMine + " " + PhotonView.Get(this.gameObject).GetHashCode() + " - с номером " + PhotonNetwork.CurrentRoom.PlayerCount);
            
            

        }
    }
    void Update()
    {

    }

    public void SayHello()//сказать фотону отправить указаный метод
    {
        //класс photonView является генератором пакета, требуется подвесить на gameobject(нейтральный) в проекте
        //важные настройки в инспекторе:синхронизации

        //имя метода вызова,укажем клиентов,укажем отправляемые параметры(к примеру взята инфа локального клиента)
        this.photonView.RPC("Hello", RpcTarget.All, (byte)PhotonNetwork.LocalPlayer.ActorNumber);
    }

    [PunRPC]//для того чтоб фотон знал о данном методе
    public void Hello(byte playerId)
    {
        Debug.Log($"Игрок ID {playerId} передал Привет");
    }

}
