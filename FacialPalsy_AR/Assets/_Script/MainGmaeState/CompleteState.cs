using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteState : IMainGameState
{
    public CompleteState(MainGameStateControl Controller) : base(Controller)
    {
        this.StateName = "CompleteState";
    }
    // Start is called before the first frame update
    void Start()
    { 
        //螢幕翻正
        Screen.orientation = ScreenOrientation.Portrait;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
