using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventSystem : MonoSingleton<GameEventSystem> {
    
    //標題頁
    public UnityAction OnPushLogInBtn;
    public UnityAction OnPushExitBtn;
    public UnityAction OnPushInfoBtn;

    //主選單
    public UnityAction OnPushBackTitleBtn;
    public UnityAction<int> OnPushGameSceneBtn;



    //主遊戲
    public UnityAction OnPushStartBtn_TipUICompBtn;
    public UnityAction OnPushRestartBtn;
    public UnityAction OnPushBackMainMenu_MainGameBtn;
    public UnityAction NextStepBtn_MainGameBtn;
    public UnityAction RunCompleteBtn_MainGameBtn;
    public UnityAction MasachiInitBtn_MainGameBtn;
    public UnityAction MasachiCompleteBtn_MainGameBtn;
    public UnityAction GiveScoreDoneBtn_MainGameBtn;


    //恢復曲線
    public UnityAction OnPushOk_RecoverBtn;


    //排行
    public UnityAction OnPushBackMainMenu_RankBtn;

    //按摩
    public UnityAction OnPushBackMainMenu_MasachiBtn;

    public void DisRegistEvents_Title()
    {
        OnPushLogInBtn = null;
        OnPushExitBtn = null;
    }


    public void DisRegistEvents_MainMenu()
    {
        OnPushBackTitleBtn = null;
        OnPushGameSceneBtn = null;
    }

    public void DisRegistEvents_MainGame()
    {
        OnPushStartBtn_TipUICompBtn = null;
        OnPushRestartBtn = null;
        OnPushBackMainMenu_MainGameBtn = null;
        NextStepBtn_MainGameBtn = null;
        RunCompleteBtn_MainGameBtn = null;
        MasachiInitBtn_MainGameBtn = null;
        MasachiCompleteBtn_MainGameBtn = null;
        GiveScoreDoneBtn_MainGameBtn = null;
    }

    public void DisRegistEvents_Recover()
    {
        OnPushOk_RecoverBtn = null;
    }

    public void DisRegistEvents_Rank()
    {
        OnPushBackMainMenu_RankBtn = null;
    }
    public void DisRegistEvents_Masachi()
    {
        OnPushBackMainMenu_MasachiBtn = null;
    }
}
