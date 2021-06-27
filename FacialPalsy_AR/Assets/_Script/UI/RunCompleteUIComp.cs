using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunCompleteUIComp : MonoBehaviour
{
    [SerializeField]
    Button nextStepBtn;

    [SerializeField]
    Text TimeTxt;

    // Start is called before the first frame update
    void Start()
    {
        nextStepBtn.onClick.AddListener(()=> { GameEventSystem.Instance.RunCompleteBtn_MainGameBtn();});
        float time = DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine.TimeCloseEyeCount;
        TimeTxt.text = "總得分：<color=blue><size=100>" + System.Math.Round(time,2) + "</size>分</color>";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
