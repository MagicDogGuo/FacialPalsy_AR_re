using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunInitState : IMainGameState
{
   
    public RunInitState(MainGameStateControl Controller) : base(Controller)  //Controller=GameLoop的m_SceneStateController
    {
        this.StateName = "InitState";
    }

    GameObject tipUICanvas;

    //開始
    public override void StateBegin()
    {
        //螢幕翻正
        Screen.orientation = ScreenOrientation.Portrait;

        tipUICanvas = GameObject.Instantiate( MainGameManager.Instance.TipUICanvass);
        GameEventSystem.Instance.OnPushRestartBtn += RestartState;
        GameEventSystem.Instance.OnPushBackMainMenu_MainGameBtn += RestartState;
        GameEventSystem.Instance.OnPushStartBtn_TipUICompBtn += OnPushStartBtn_TipUICompBtn;
    }

    //更新
    public override void StateUpdate() {
    
    }


    //結束
    public override void StateEnd() {
        GameObject.Destroy(tipUICanvas);
    }


    void SetBGM(int level)
    {
     
    }

    /// <summary>
    /// 重新開始 0619 改成回選單，方法名我就先不改了
    /// </summary>
    void RestartState()
    {
        m_Conrtoller.SetState(MainGameStateControl.GameFlowState.RunInit, m_Conrtoller);

    }

    void NextLevel()
    {
        //MainGameManager.NowLevel++;
    }
    void OnPushStartBtn_TipUICompBtn()
    {
        m_Conrtoller.SetState(MainGameStateControl.GameFlowState.Run, m_Conrtoller);

    }


}
