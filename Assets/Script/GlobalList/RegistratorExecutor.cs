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
            if (GlobalList.DataObject[i].Hash==hash)
            {
                return GlobalList.DataObject[i];
            }
            
        }
        return new RegistratorConstruction();
    }

    public RegistratorConstruction GetDataCamera()
    {
        for (int i = 0; i < GlobalList.DataObject.Count; i++)
        {
            if (GlobalList.DataObject[i].CameraMove is CameraMove)
            {
                return GlobalList.DataObject[i];
            }
        }
        return new RegistratorConstruction();
    }

    public RegistratorConstruction GetDataUserInput()
    {
        for (int i = 0; i < GlobalList.DataObject.Count; i++)
        {
            if (GlobalList.DataObject[i].UserInput is UserInput)
            {
                return GlobalList.DataObject[i];
            }
        }
        return new RegistratorConstruction();
    }
}
