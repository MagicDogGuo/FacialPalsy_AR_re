using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasachiState : ISceneState
{
    public MasachiState(SceneStateControler controler) : base(controler)
    {
        this.StateName = "MasachiState";
    }
    public override void StateBegin()
    {
        GameEventSystem.Instance.OnPushBackMainMenu_MasachiBtn += PushBackSceneBtn;
    }

    public override void StateUpdate()
    {
    }

    public override void StateEnd()
    {
        GameEventSystem.Instance.DisRegistEvents_Masachi();
    }

    void PushBackSceneBtn()
    {
        m_Controler.SetState(new MainMenuState(m_Controler), "MainMenuState");
    }
}
