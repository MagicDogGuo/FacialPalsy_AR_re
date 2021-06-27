using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecoveCurverUIComp : MonoBehaviour
{
    [SerializeField]
    Button OKBtn;

    [SerializeField]
    Button RedoBtn;

    // Start is called before the first frame update
    void Start()
    {
        OKBtn.onClick.AddListener(() => { GameEventSystem.Instance.OnPushOk_RecoverBtn(); });
        RedoBtn.onClick.AddListener(() => { ScrollRecoverUI.Page = 1; });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
