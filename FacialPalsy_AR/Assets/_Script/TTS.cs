using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTS : MonoBehaviour
{

    string TimeS ;
    string say;

    bool isSayNoFace = false;
    bool isSP00 = true;
    bool isSP01 = false;
    bool isSP02 = false;
    bool isSP03 = false;
    bool isSP04 = false;
    bool isSP05 = false;

    float countTime = 0;

    DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine webs;
    
    // Start is called before the first frame update
    void Start()
    {
        EasyTTSUtil.Initialize(EasyTTSUtil.Taiwan);
        webs = GetComponent<DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine>();
        countTime = 5;
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

        if(isSayNoFace == true)
        {
            countTime += Time.deltaTime;
        }
        if (webs.IsDetectFace == false && isSayNoFace==false && countTime >= 5)
        {
            say = "請重新偵測人臉";
            EasyTTSUtil.SpeechAdd(say);
            isSayNoFace = true;
            countTime = 0;
        }

        TimeS = "" + ((int)webs.COUNTER);

        //if(webs.COUNTER > 0.5f && webs.COUNTER <= 0.5f && isSP00==false)
        //{
        //    say = "閉眼0.5秒";
        //    EasyTTSUtil.SpeechAdd(say);
        //    isSP00 = true;
        //}

        switch ((int)webs.COUNTER)
        {
            case 1:
                if (!isSP01)
                {
                    say = "閉眼" + TimeS + "秒正在蓄力";
                    EasyTTSUtil.SpeechAdd(say);
                    isSP01 = true;
                }
                break;
            case 2:
                if (!isSP02)
                {
                    say = "閉眼" + TimeS + "秒";
                    EasyTTSUtil.SpeechAdd(say);
                    isSP02 = true;
                }
                break;
            case 3:
                if (!isSP03)
                {
                    say = "閉眼" + TimeS + "秒蓄力完成請張眼";
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
