using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugBtn : MonoBehaviour
{

    [SerializeField]
    GameObject[] debugBtn;

    Button _btn;


    // Start is called before the first frame update
    void Start()
    {
        _btn = this.GetComponent<Button>();
        _btn.onClick.AddListener(OnPushBtn);
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    void OnPushBtn()
    {
        foreach(var btn in debugBtn)
        {
            btn.SetActive(!btn.active);
        }
    }
}
