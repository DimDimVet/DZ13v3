using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RegistratorExecutor executor = new RegistratorExecutor();
        var tt = executor.GetDataList();

        for (int i = 0; i < tt.Count; i++)
        {
            //Debug.Log(tt[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
