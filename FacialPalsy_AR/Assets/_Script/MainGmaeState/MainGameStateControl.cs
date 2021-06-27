using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStateControl {

    public enum GameFlowState
    {
        RunInit,
        Run,
        RunDead,
        RunComplete,
        MasachiVideoInit,
        MasachiVideoState,
        MasachiVideoStateComplete,
        GiveScoreState,
        Complete
    }
    
    public GameFlowState GameState { get; private set; }

    IMainGameState m_State = null; //現在三個子類別 MainMenuState、LoadingState、MainGameState
    bool m_bRunBegin = false;

    public MainGameStateControl() { }

    AsyncOperation asyn;

    //設定狀態
    public void SetState(GameFlowState State, MainGameStateControl m_MainGameStateController)
    {
        GameState = State;
        m_bRunBegin = false;

        if (m_State != null)
        {
            m_State.StateEnd();
        }

        //設定State
        switch (State)
        {
            case GameFlowState.RunInit:
                m_State = new RunInitState(m_MainGameStateController);
                break;   
            case GameFlowState.Run:
                m_State = new RunState(m_MainGameStateController);
                break;
            case GameFlowState.RunDead:
                m_State = new RunDeadState(m_MainGameStateController);
                break;
            case GameFlowState.RunComplete:
                m_State = new RunCompleteState(m_MainGameStateController);
                break;
            case GameFlowState.MasachiVideoState:
                m_State = new MasachiVideoState(m_MainGameStateController);
                break;
            case GameFlowState.MasachiVideoInit:
                m_State = new MasachiVideoInitState(m_MainGameStateController);
                break;
            case GameFlowState.MasachiVideoStateComplete:
                m_State = new MasachiVideoCompleteState(m_MainGameStateController);
                break;
            case GameFlowState.GiveScoreState:
                m_State = new GiveScoreState(m_MainGameStateController);
                break;
            case GameFlowState.Complete:
                m_State = new CompleteState(m_MainGameStateController);
                break;
        }
    }

    //更新
    public void StateUpdate()
    {
        //通知新的State開始
        if (m_State != null && m_bRunBegin == false)
        {
            m_State.StateBegin();
            m_bRunBegin = true;
        }

        if (m_State != null)
        {
            m_State.StateUpdate();
        }
    }
}
