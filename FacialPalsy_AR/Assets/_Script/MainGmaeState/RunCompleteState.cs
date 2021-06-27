using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCompleteState : IMainGameState
{

    public RunCompleteState(MainGameStateControl Controller) : base(Controller)  //Controller=GameLoop的m_SceneStateController
    {
        this.StateName = "RunCompleteState";
    }
    GameObject runCompleteUICanvass;
    //開始
    public override void StateBegin()
    {
        GameEventSystem.Instance.RunCompleteBtn_MainGameBtn += OnPushNextToMasachiStateBtn_MainGameBtn;
        runCompleteUICanvass = GameObject.Instantiate(MainGameManager.Instance.RunCompleteUICanvass);
    }

    //更新
    public override void StateUpdate()
    {
        MainGameManager.Instance.ExitDestoryObject();

    }


    //結束
    public override void StateEnd()
    {
        GameObject.Destroy(runCompleteUICanvass);
    }

    void OnPushNextToMasachiStateBtn_MainGameBtn()
    {
        m_Conrtoller.SetState(MainGameStateControl.GameFlowState.MasachiVideoInit, m_Conrtoller);

    }
}
