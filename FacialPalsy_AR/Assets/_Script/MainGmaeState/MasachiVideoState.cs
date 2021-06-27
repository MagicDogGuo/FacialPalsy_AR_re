using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MasachiVideoState : IMainGameState
{
    public MasachiVideoState(MainGameStateControl Controller) : base(Controller)  //Controller=GameLoop的m_SceneStateController
    {
        this.StateName = "MasachiVideoState";
    }

    GameObject video;
    GameObject detectQuads;
    //開始
    public override void StateBegin()
    {
    
        MainGameManager.Instance.NowStage = 2; 
        //MainGameManager.Instance.DetectQuads.SetActive(false);
        video = GameObject.Instantiate(MainGameManager.Instance.MasachiVideoPlays);
        detectQuads = GameObject.Instantiate(MainGameManager.Instance.DetectQuadsMasachis);

    }

    //更新
    public override void StateUpdate()
    {
        VideoPlayer videoPlayer = MainGameManager.Instance.MasachiVideoPlays.GetComponent<VideoPlayer>();
        if (MasachiVideoSetting.isFinish)
        {
            Debug.Log("videoOver");
            m_Conrtoller.SetState(MainGameStateControl.GameFlowState.MasachiVideoStateComplete, m_Conrtoller);
            MasachiVideoSetting.isFinish = false;
        }
    }


    //結束
    public override void StateEnd()
    {
        GameObject.Destroy(video);
        GameObject.Destroy(detectQuads);

    }
}
