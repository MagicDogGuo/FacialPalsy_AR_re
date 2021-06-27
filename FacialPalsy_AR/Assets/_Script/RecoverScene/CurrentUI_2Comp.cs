using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentUI_2Comp : MonoBehaviour
{
    [SerializeField]
    Button checkBtn;

    [SerializeField]
    Button RedoBtn;

    void Start()
    {
        checkBtn.onClick.AddListener(() => {
            ScrollRecoverUI.Page = 6;
        });

        RedoBtn.onClick.AddListener(() => {
            ScrollRecoverUI.Page = 4;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
