using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullonExplore : MonoBehaviour
{

    SpriteRenderer sss;
    public Sprite sp;

    // Start is called before the first frame update
    void Start()
    {
        sss = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            sss.sprite = sp;
        }
    }
}
