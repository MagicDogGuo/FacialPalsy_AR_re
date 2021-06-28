using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamAmount : MonoBehaviour
{
    WebCamDevice[] device;
    // Start is called before the first frame update
    void Start()
    {
        device = WebCamTexture.devices;
        Debug.Log("device" + device.Length);

        foreach(var i in device)
        {
            Debug.Log(i.name);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
