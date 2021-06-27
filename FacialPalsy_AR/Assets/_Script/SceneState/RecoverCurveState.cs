using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverCurveState : ISceneState
{
    public RecoverCurveState(SceneStateControler controler) : base(controler)
    {
        this.StateName = "RecoverCurveState";
    }

    public override void StateBegin()
    {
        GameEventSystem.Instance.OnPushOk_RecoverBtn += PushBackSceneBtn;
    }

    public override void StateUpdate()
    {
    }

    public override void StateEnd()
    {
        GameEventSystem.Instance.DisRegistEvents_Recover();
        ScrollRecoverUI.Page = 1;
    }

    void PushBackSceneBtn()
    {
        m_Controler.SetState(new MainMenuState(m_Controler), "MainMenuState");
    }
}
