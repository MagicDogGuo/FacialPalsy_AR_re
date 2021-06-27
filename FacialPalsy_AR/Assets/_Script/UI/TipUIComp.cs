using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipUIComp : MonoBehaviour
{
    [SerializeField]
    Button startBtn;
    // Start is called before the first frame update
    void Start()
    {
        startBtn.onClick.AddListener(() => { GameEventSystem.Instance.OnPushStartBtn_TipUICompBtn(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
