using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FakeCurseUIComp : MonoBehaviour
{

    [SerializeField]
    Button BackBtn;

    [SerializeField]
    Image NowImg;

    [SerializeField]
    Image OldImg;

    // Start is called before the first frame update
    void Start()
    {
        BackBtn.onClick.AddListener(()=> {
            GameEventSystem.Instance.OnPushBackMainMenu_MainGameBtn();
        });

        NowImg.sprite = CurrentUiComp.NowImg_FakeUIPhoto;
        OldImg.sprite = UpdateUIComp.OldImg_FakeUIPhoto;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
