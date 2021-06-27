using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveScoreUIComp : MonoBehaviour
{
    [SerializeField]
    GameObject BG01;
    [SerializeField]
    GameObject BG02;
    [SerializeField]
    GameObject BG03;

    [SerializeField]
    Button confirmBtn01;
    [SerializeField]
    Button confirmBtn02;
    [SerializeField]
    Button confirmBtn03;

    [SerializeField]
    Button tooEasyBtn;
    [SerializeField]
    Button normolBtn;
    [SerializeField]
    Button tooHardBtn;

    [SerializeField]
    Text TitleTxt02;
    [SerializeField]
    Text TitleTxt03;

    [SerializeField]
    Toggle toggle01;
    [SerializeField]
    Toggle toggle02;
    [SerializeField]
    Text toggle01_txt;
    [SerializeField]
    Text toggle02_txt;

    [SerializeField]
    Button backBtn;

    string _title02_TooHard = "強度要適合自己才是最好的！\n要降低多少呢?";
    string _title02_TooHard_L01 = "降低強度";
    string _title02_TooHard_L02 = "稍微降低一點就好";
    string _title02_TooEasy = "強度要適合自己才是最好的！\n要增強多少呢?";
    string _title02_TooEasy_L01 = "增強強度";
    string _title02_TooEasy_L02 = "稍微增強一點就好";


    string _title03_TooHard = "那就把<color=#2A2AC0>復健難度</color>降低";
    string _title03_TooEasy = "那就把<color=#2A2AC0>復健難度</color>增強";
    string _title03_normal = "那就繼續保持加油吧！";

    enum FeelType
    {
        nulls,
        tooEasy,
        normol,
        tooHard
    }

    FeelType feelType = FeelType.nulls;

    void Start()
    {
        feelType = FeelType.nulls;
        tooEasyBtn.onClick.AddListener(OnPushTooEasy);
        normolBtn.onClick.AddListener(OnPushNormal);
        tooHardBtn.onClick.AddListener(OnPushTooHard);
        backBtn.onClick.AddListener(OnPushBackBtn);


        confirmBtn01.onClick.AddListener(delegate { OnPushComfirmBtn(1); });
        confirmBtn02.onClick.AddListener(delegate { OnPushComfirmBtn(2); });
        confirmBtn03.onClick.AddListener(delegate { OnPushComfirmBtn(3); });
    }
    void Update()
    {
       

    }

    void OnPushBackBtn()
    {
        toggle01.isOn = false;
        toggle02.isOn = false;

        if (BG02.active)
        {
            BG01.SetActive(true);
            BG02.SetActive(false);
            BG03.SetActive(false);
            backBtn.gameObject.SetActive(false);
        }
        else if (BG03.active)
        {
            if (feelType != FeelType.normol)
            {
                BG01.SetActive(false);
                BG02.SetActive(true);
                BG03.SetActive(false);
            }
            else
            {
                backBtn.gameObject.SetActive(false);

                BG01.SetActive(true);
                BG02.SetActive(false);
                BG03.SetActive(false);
            }
           
        }
    }

    void OnPushTooEasy()
    {
        feelType = FeelType.tooEasy;

        tooEasyBtn.GetComponent<Image>().color = Color.gray;
        normolBtn.GetComponent<Image>().color = Color.white;
        tooHardBtn.GetComponent<Image>().color = Color.white;
    }

    void OnPushNormal()
    {
        feelType = FeelType.normol;

        tooEasyBtn.GetComponent<Image>().color = Color.white;
        normolBtn.GetComponent<Image>().color = Color.gray;
        tooHardBtn.GetComponent<Image>().color = Color.white;
    }

    void OnPushTooHard()
    {
        feelType = FeelType.tooHard;

        tooEasyBtn.GetComponent<Image>().color = Color.white;
        normolBtn.GetComponent<Image>().color = Color.white;
        tooHardBtn.GetComponent<Image>().color = Color.gray;
    }

    void OnPushComfirmBtn(int i)
    {
        if (i == 1)
        {
            backBtn.gameObject.SetActive(true);
            if (feelType == FeelType.normol)
            {
                BG01.SetActive(false);
                BG02.SetActive(false);
                BG03.SetActive(true);
                TitleTxt03.text = _title03_normal;
            }
            else if(feelType!= FeelType.nulls)
            {
                BG01.SetActive(false);
                BG02.SetActive(true);
                BG03.SetActive(false);

                switch (feelType)
                {
                    case FeelType.tooEasy:
                        TitleTxt02.text = _title02_TooEasy;
                        toggle01_txt.text = _title02_TooEasy_L01;
                        toggle02_txt.text = _title02_TooEasy_L02;
                        break;
                    case FeelType.tooHard:
                        TitleTxt02.text = _title02_TooHard;
                        toggle01_txt.text = _title02_TooHard_L01;
                        toggle02_txt.text = _title02_TooHard_L02;
                        break;
                }
            }

       
        }
        else if(i == 2)
        {
            if(toggle01.isOn != false || toggle02.isOn != false)
            {
                BG01.SetActive(false);
                BG02.SetActive(false);
                BG03.SetActive(true);

                if (toggle01.isOn)
                {
                    switch (feelType)
                    {
                        case FeelType.tooEasy:
                            TitleTxt03.text = _title03_TooEasy + "<color=#2A2AC0>2</color>吧!";
                            break;
                        case FeelType.tooHard:
                            TitleTxt03.text = _title03_TooHard + "<color=#2A2AC0>2</color>吧!";
                            break;
                    }
                }
                else if (toggle02.isOn)
                {
                    switch (feelType)
                    {
                        case FeelType.tooEasy:
                            TitleTxt03.text = _title03_TooEasy + "<color=#2A2AC0>1</color>吧!";
                            break;
                        case FeelType.tooHard:
                            TitleTxt03.text = _title03_TooHard + "<color=#2A2AC0>1</color>吧!";
                            break;
                    }
                }

            
            }
        }
        else if (i == 3)
        {
            GameEventSystem.Instance.GiveScoreDoneBtn_MainGameBtn();
        }
    }

}
