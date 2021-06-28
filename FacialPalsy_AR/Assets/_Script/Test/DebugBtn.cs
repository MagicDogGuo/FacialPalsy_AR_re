using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DlibFaceLandmarkDetectorExample;

public class DebugBtn : MonoBehaviour
{

    [SerializeField]
    GameObject[] debugBtn;

    Button _btn;

   public static bool isDebug = false;

    // Start is called before the first frame update
    void Start()
    {
        _btn = this.GetComponent<Button>();
        _btn.onClick.AddListener(OnPushBtn);
    }

    // Update is called once per frame
    void Update()
    {
        //測適用
        if (Input.GetMouseButtonDown(0 ) && isDebug)
        {
            WebCamTextureToMatHelperExampleMine.TOTAL += 1;
        }
    }

    void OnPushBtn()
    {
        isDebug = !isDebug;
        foreach (var btn in debugBtn)
        {
            btn.SetActive(!btn.active);
        }
    }
}
