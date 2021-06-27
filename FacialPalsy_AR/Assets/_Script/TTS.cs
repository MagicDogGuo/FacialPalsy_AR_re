using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTS : MonoBehaviour
{

    string TimeS ;
    string say;

    bool isSP00 = true;
    bool isSP01 = false;
    bool isSP02 = false;
    bool isSP03 = false;
    bool isSP04 = false;
    bool isSP05 = false;

    DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine webs;
    
    // Start is called before the first frame update
    void Start()
    {
        EasyTTSUtil.Initialize(EasyTTSUtil.Taiwan);
        webs = GetComponent<DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine>();
    }


    // Update is called once per frame
    void Update()
    {
        if ((int)webs.COUNTER == 0)
        {
            isSP00 = false;
            isSP01 = false;
            isSP02 = false;
            isSP03 = false;
            isSP04 = false;
            isSP05 = false;
        }


        TimeS = "" + ((int)webs.COUNTER);

        if(webs.COUNTER > 0.5f && webs.COUNTER <= 0.5f && isSP00==false)
        {
            say = "已閉眼0.5秒";
            EasyTTSUtil.SpeechAdd(say);
            isSP00 = true;
        }

        switch ((int)webs.COUNTER)
        {
            case 1:
                if (!isSP01)
                {
                    say = "已閉眼" + TimeS + "秒正在蓄力";
                    EasyTTSUtil.SpeechAdd(say);
                    isSP01 = true;
                    Debug.Log("--------------------------------------"+say);
                }
                break;
            case 2:
                if (!isSP02)
                {
                    say = "已閉眼" + TimeS + "秒";
                    EasyTTSUtil.SpeechAdd(say);
                    isSP02 = true;
                }
                break;
            case 3:
                if (!isSP03)
                {
                    say = "已閉眼" + TimeS + "秒蓄力完成請張眼";
                    EasyTTSUtil.SpeechAdd(say);
                    isSP03 = true;
                }
                break;
            //case 4:
            //    if (!isSP04)
            //    {
            //        say = "已閉眼" + TimeS + "秒";
            //        EasyTTSUtil.SpeechAdd(say);
            //        isSP04 = true;
            //    }
            //    break;
            //case 5:
            //    if (!isSP05)
            //    {
            //        say = "已閉眼" + TimeS + "秒，厲害";
            //        EasyTTSUtil.SpeechAdd(say);
            //        isSP05 = true;
            //    }
            //    break;
        }
    }
    void OnApplicationQuit()
    {
        EasyTTSUtil.Stop();
    }
}
