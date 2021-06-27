using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : ISceneState
{
    public MainMenuState(SceneStateControler Controler) : base(Controler)
    {
        this.StateName = "MainMenuState";
    }

    public override void StateBegin()
    {
        MainMenuManager.Instance.InstantiateInitObject();
        GameEventSystem.Instance.OnPushGameSceneBtn += PushGameSceneBtn;

    }

    public override void StateUpdate()
    {
    }

    public override void StateEnd()
    {
        GameEventSystem.Instance.DisRegistEvents_MainMenu();
    }

    void PushGameSceneBtn(int level)
    {
        m_Controler.SetState(new MainGameState(m_Controler), "MainGameState");
    }

    void PushRecoverCurveBtn()
    {
        m_Controler.SetState(new RecoverCurveState(m_Controler), "RecoverCurveState");
    }

    void PushMasachiBtn()
    {
        m_Controler.SetState(new MasachiState(m_Controler), "MasachiState");
    }

}
