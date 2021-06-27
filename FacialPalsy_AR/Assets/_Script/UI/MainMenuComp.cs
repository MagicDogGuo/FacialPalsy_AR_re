using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuComp : MonoBehaviour
{
    [SerializeField]
    Button EyeBtn;

    [SerializeField]
    Button MouseBtn;

    [SerializeField]
    Button FaceBtn;

    [SerializeField]
    Button RecommandBtn;
    [SerializeField]
    Button CustomBtn;
    [SerializeField]
    Button SocialBtn;

    [SerializeField]
    Button BackBtn_Page02;
    [SerializeField]
    Button BackBtn_Page03;
    [SerializeField]
    Button BackBtn_Page04;

    [SerializeField]
    GameObject Page01;

    [SerializeField]
    GameObject Page02;

    [SerializeField]
    GameObject Page03;

    [SerializeField]
    GameObject Page04;

    // Start is called before the first frame update
    void Start()
    {
        Page01.SetActive(true);
        Page02.SetActive(false);
        Page03.SetActive(false);
        Page04.SetActive(false);

        EyeBtn.onClick.AddListener(() => { if (GameEventSystem.Instance.OnPushGameSceneBtn != null) GameEventSystem.Instance.OnPushGameSceneBtn(0); });
        MouseBtn.onClick.AddListener(()=> { if (GameEventSystem.Instance.OnPushGameSceneBtn != null) GameEventSystem.Instance.OnPushGameSceneBtn(1); });
        FaceBtn.onClick.AddListener(() => { if (GameEventSystem.Instance.OnPushGameSceneBtn != null) GameEventSystem.Instance.OnPushGameSceneBtn(2); });

        RecommandBtn.onClick.AddListener(() => { OnPushRecommandBtn(); });
        BackBtn_Page02.onClick.AddListener(() => { OnPushBackBtn_Page02(); });
        CustomBtn.onClick.AddListener(() => { OnPushPage03Btn(); });
        BackBtn_Page03.onClick.AddListener(() => { OnPushBackBtn_Page03(); });
        SocialBtn.onClick.AddListener(() => { OnPushPage04Btn(); });
        BackBtn_Page04.onClick.AddListener(() => { OnPushBackBtn_Page04(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPushRecommandBtn()
    {
        Page01.SetActive(false);
        Page02.SetActive(true);
        Page03.SetActive(false);
        Page04.SetActive(false);
    }

    void OnPushBackBtn_Page02()
    {
        Page01.SetActive(true);
        Page02.SetActive(false);
        Page03.SetActive(false);
        Page04.SetActive(false);
    }

    void OnPushPage03Btn()
    {
        Page01.SetActive(false);
        Page02.SetActive(false);
        Page03.SetActive(true);
        Page04.SetActive(false);
    }

    void OnPushBackBtn_Page03()
    {
        Page01.SetActive(true);
        Page02.SetActive(false);
        Page03.SetActive(false);
        Page04.SetActive(false);
    }


    void OnPushPage04Btn()
    {
        Page01.SetActive(false);
        Page02.SetActive(false);
        Page03.SetActive(false);
        Page04.SetActive(true);
    }

    void OnPushBackBtn_Page04()
    {
        Page01.SetActive(true);
        Page02.SetActive(false);
        Page03.SetActive(false);
        Page04.SetActive(false);
    }

}
