using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IMainGameState
{

    public RunState(MainGameStateControl Controller) : base(Controller)  //Controller=GameLoop的m_SceneStateController
    {
        this.StateName = "RunState";
    }
    GameObject detectQuads;

    bool isDone;
    float count;

    //開始
    public override void StateBegin()
    {
        MainGameManager.Instance.InstantiateInitObject();
        GameEventSystem.Instance.NextStepBtn_MainGameBtn += OnPushNextStepBtn_MainGameBtn;
        MainGameManager.Instance.NowStage = 1;
        //detectQuads= GameObject.Instantiate(MainGameManager.Instance.DetectQuads);
        MainGameManager.Instance.DetectQuads.SetActive(true);
        isDone = false;
        count = 0;
    }

    //更新
    public override void StateUpdate()
    {
        //m_Conrtoller.SetState(MainGameStateControl.GameFlowState.Toturial, m_Conrtoller);
        if(DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine.TOTAL >= 5)
        {
            isDone = true;
            count += Time.deltaTime;
        }
        else if (MainGameManager.Instance.BirdisDead)
        {
            m_Conrtoller.SetState(MainGameStateControl.GameFlowState.RunDead, m_Conrtoller);
        }

        if(isDone && count > 2)
        {
            ChangeToRunComplete();
            count = 0;
        }


    }


    //結束
    public override void StateEnd()
    {
        DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine.BlinkingEye = null;///////////
        DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine.TOTAL = 0;
        //GameObject.Destroy(detectQuads);

    }
    void OnPushNextStepBtn_MainGameBtn()
    {
        if (MainGameManager.Instance.NowStage == 2)
        {
            m_Conrtoller.SetState(MainGameStateControl.GameFlowState.Complete, m_Conrtoller);

        }
        else
        {
            m_Conrtoller.SetState(MainGameStateControl.GameFlowState.MasachiVideoState, m_Conrtoller);
        }

    }

    void ChangeToRunComplete()
    {
        m_Conrtoller.SetState(MainGameStateControl.GameFlowState.RunComplete, m_Conrtoller);

    }

}
