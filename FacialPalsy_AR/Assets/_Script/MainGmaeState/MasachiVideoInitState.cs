using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasachiVideoInitState : IMainGameState
{

    public MasachiVideoInitState(MainGameStateControl Controller) : base(Controller)  //Controller=GameLoop的m_SceneStateController
    {
        this.StateName = "MasachiVideoInitState";
    }

    //開始
    public override void StateBegin()
    {
       
        GameEventSystem.Instance.MasachiInitBtn_MainGameBtn += OnPushMasachiInitBtn_MainGameBtn;
        masachiInitUICanvass = GameObject.Instantiate(MainGameManager.Instance.MasachiInitUICanvass);
    }
    GameObject masachiInitUICanvass;

    //更新
    public override void StateUpdate()
    {

    }


    //結束
    public override void StateEnd()
    {
        GameObject.Destroy(masachiInitUICanvass);
    }

    void OnPushMasachiInitBtn_MainGameBtn()
    {
        m_Conrtoller.SetState(MainGameStateControl.GameFlowState.MasachiVideoState, m_Conrtoller);

    }
}
