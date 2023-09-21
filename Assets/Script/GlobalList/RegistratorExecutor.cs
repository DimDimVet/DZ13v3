using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class RegistratorExecutor : IRegistrator
{
    public Transform OutPos { get; set; }

    public void SetData(RegistratorConstruction data)
    {
        GlobalList.DataObject.Add(data);
    }
    public List<RegistratorConstruction> GetDataList()
    {
        return GlobalList.DataObject;
    }

    public RegistratorConstruction GetData(int hash)
    {
        for (int i = 0; i < GlobalList.DataObject.Count; i++)
        {
            if (GlobalList.DataObject[i].Hash == hash)
            {
                return GlobalList.DataObject[i];
            }
        }
        return new RegistratorConstruction();
    }

    public void SetDataCameraReLoad(RegistratorConstruction data)
    {
        for (int i = 0; i < GlobalList.DataObject.Count; i++)
        {
            if (GlobalList.DataObject[i].Hash == data.Hash)
            {
                GlobalList.DataObject[i] = data;
            }
        }
    }
    public RegistratorConstruction GetDataCamera()
    {
        for (int i = 0; i < GlobalList.DataObject.Count; i++)
        {
            if (GlobalList.DataObject[i].CameraMove != null && GlobalList.DataObject[i].PhotonHash)
            {

                return GlobalList.DataObject[i];

            }
        }
        return new RegistratorConstruction();
    }

    public RegistratorConstruction GetDataPlayer()
    {
        for (int i = 0; i < GlobalList.DataObject.Count; i++)
        {
            if (GlobalList.DataObject[i].PhotonHash && GlobalList.DataObject[i].CameraMove == null)
            {
                return GlobalList.DataObject[i];
            }
        }
        return new RegistratorConstruction();
    }

}
