using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI_2Comp : MonoBehaviour
{
    [SerializeField]
    Button CheckImgBtn;
    [SerializeField]
    Button RedoBtn;

    // Start is called before the first frame update
    void Start()
    {
        CheckImgBtn.onClick.AddListener(() => { OnPushCheckImgBtn(); });

        RedoBtn.onClick.AddListener(() => {
            ScrollRecoverUI.Page = 1;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPushCheckImgBtn()
    {
        ScrollRecoverUI.Page = 3;

    }
}
