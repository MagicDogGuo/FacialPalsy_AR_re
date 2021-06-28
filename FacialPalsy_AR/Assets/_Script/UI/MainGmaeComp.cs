using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class MainGmaeComp : MonoBehaviour
{
    public Button RestartBtn;

    [SerializeField]
    Button BackMenuBtn;

    [SerializeField]
    Button StopBtn;

    [SerializeField]
    Sprite StopBtnSprit01;
    [SerializeField]
    Sprite StopBtnSprit02;

    [SerializeField]
    Button NextStepBtn;
    [SerializeField]
    Button LastStepBtn;

    [SerializeField]
    Text StageTxt;



    [SerializeField]
    Text amountTxt;


    int pauseTime = 0;

    string s;

    // Start is called before the first frame update
    void Start()
    {
        RestartBtn.onClick.AddListener(() => { GameEventSystem.Instance.OnPushRestartBtn(); });
        BackMenuBtn.onClick.AddListener(() => { GameEventSystem.Instance.OnPushBackMainMenu_MainGameBtn(); });
        StopBtn.onClick.AddListener(()=> { OnPushStopBtnn(); });
        NextStepBtn.onClick.AddListener(() => { OnPushNextStepBtn(); });
    }

    // Update is called once per frame
    void Update()
    {
        //文字狀態
        switch (MainGameManager.Instance.NowStage)
        {
            case 1:
                s= "1/6AR眼部復健";
                break;
            case 2:
                s = "2/6眼部按摩復健";
                break;
        }
        StageTxt.text = s;

        //AR
        amountTxt.text = DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine.TOTAL + "/5\"";
        //按摩
    }

    void OnPushStopBtnn()
    {
     
        pauseTime++;
   
        if (pauseTime % 2 == 1) {
            StopBtn.GetComponent<Image>().sprite = StopBtnSprit02;
            MainGameManager.Instance.PauseGame();
            MainGameManager.Instance.isManualPause = true;
        }
        else
        {
            StopBtn.GetComponent<Image>().sprite = StopBtnSprit01;
            MainGameManager.Instance.PlayGame();
            MainGameManager.Instance.isManualPause = false;

        }

    }

    void OnPushNextStepBtn()
    {
        GameEventSystem.Instance.NextStepBtn_MainGameBtn();
    }
}
