using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class MasachiVideoSetting : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    public static bool isFinish=false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<VideoPlayer>().targetCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        VideoPlayer videoPlayer = this.GetComponent<VideoPlayer>();
        //Debug.Log(videoPlayer.frame + "   " + (float)videoPlayer.frameCount);
        if ((float)videoPlayer.frame >= ((float)videoPlayer.frameCount-30))
        {
            isFinish = true;
        }
        slider.value =  GetComponent<VideoPlayer>().frame/ (GetComponent<VideoPlayer>().frameCount * 1.0f);
    }
}
