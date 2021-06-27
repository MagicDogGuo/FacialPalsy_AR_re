using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveScoreState : IMainGameState
{
    public GiveScoreState(MainGameStateControl Controller) : base(Controller)  //Controller=GameLoop的m_SceneStateController
    {
        this.StateName = "GiveScoreState";
    }

    GameObject GiveScoreUICanvass;


    public override void StateBegin()
    {
        GameEventSystem.Instance.GiveScoreDoneBtn_MainGameBtn += OnPushGiveScoreDoneBtn_MainGameBtn;
        GiveScoreUICanvass = GameObject.Instantiate(MainGameManager.Instance.GiveScoreUICanvass);

    }

    //更新
    public override void StateUpdate()
    {

    }


    //結束
    public override void StateEnd()
    {
        GameObject.Destroy(GiveScoreUICanvass);
    }

    void OnPushGiveScoreDoneBtn_MainGameBtn()
    {
        m_Conrtoller.SetState(MainGameStateControl.GameFlowState.RunInit, m_Conrtoller);

        Debug.Log("完成==============");
        //m_Conrtoller.SetState(MainGameStateControl.GameFlowState.MasachiVideoInit, m_Conrtoller);
        GameObject.Instantiate(MainGameManager.Instance.FakeCurseUICanvas);
    }
}
