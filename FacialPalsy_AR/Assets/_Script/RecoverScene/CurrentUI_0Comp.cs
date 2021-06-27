using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentUI_0Comp : MonoBehaviour
{
    [SerializeField]
    Button NextStepBtn;
    // Start is called before the first frame update
    void Start()
    {
        NextStepBtn.onClick.AddListener(() => { OnPushNextStepBtn(); });

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPushNextStepBtn()
    {
        ScrollRecoverUI.Page = 4;

    }
}
