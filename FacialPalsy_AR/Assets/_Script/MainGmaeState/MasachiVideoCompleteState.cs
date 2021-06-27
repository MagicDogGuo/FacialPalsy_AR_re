using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MasachiVideoCompleteState : IMainGameState
{

    public MasachiVideoCompleteState(MainGameStateControl Controller) : base(Controller)  //Controller=GameLoop的m_SceneStateController
    {
        this.StateName = "MasachiVideoCompleteState";
    }
    GameObject masachiCompleteUICanvass;
    //開始
    public override void StateBegin()
    {
        GameEventSystem.Instance.MasachiCompleteBtn_MainGameBtn += OnPushMasachiBtn_MainGameBtn;
        masachiCompleteUICanvass = GameObject.Instantiate(MainGameManager.Instance.MasachiCompleteUICanvass);

    }

    //更新
    public override void StateUpdate()
    {
       
    }


    //結束
    public override void StateEnd()
    {
        GameObject.Destroy(masachiCompleteUICanvass);
    }

    void OnPushMasachiBtn_MainGameBtn()
    {
        m_Conrtoller.SetState(MainGameStateControl.GameFlowState.GiveScoreState, m_Conrtoller);

    }
}
