using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Masachi_QuadSizeSet : MonoBehaviour
{
    Vector3 V;

    float count;

    // Start is called before the first frame update
    void Start()
    {
        //
        V = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if (count < 1)
        {
            this.transform.localScale = V * 1.5f;
        }
    }
}
