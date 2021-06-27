using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunDeadState : IMainGameState
{

    public RunDeadState(MainGameStateControl Controller) : base(Controller)  //Controller=GameLoop的m_SceneStateController
    {
        this.StateName = "RunDeadState";
    }

    float counter = 0;

    //開始
    public override void StateBegin()
    {
        MainGameManager.Instance.PlayerBirds.GetComponent<SpriteRenderer>().color = Color.gray;
        
    }

    //更新
    public override void StateUpdate()
    {
        counter += Time.deltaTime;
        if (counter >3)
        {
            m_Conrtoller.SetState(MainGameStateControl.GameFlowState.Run, m_Conrtoller);
            counter = 0;
        }

    }


    //結束
    public override void StateEnd()
    {

        MainGameManager.Instance.ExitDestoryObject();
    }

}
