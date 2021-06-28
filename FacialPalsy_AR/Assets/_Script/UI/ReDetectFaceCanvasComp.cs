using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReDetectFaceCanvasComp : MonoBehaviour
{
    //一个图片一个文字
    public Transform m_Image;
    public Transform m_Text;
    //进度控制
    public int targetProcess = 100;
    private float currentAmout = 0;

    //进度条速度
    float speed = 0;

    private void Start()
    {
        speed = 0;

    }

    void Update()
    {
        if (MainGameManager.Instance.IsDetectFace == true)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
        }
        
        if (currentAmout < targetProcess)
        {
            currentAmout += speed;
            if (currentAmout > targetProcess)
                currentAmout = targetProcess;
            //m_Text.GetComponent<Text>().text = ((int)currentAmout).ToString() + "%";
            if ((int)currentAmout ==100 ){
                m_Text.GetComponent<Text>().text = "成功";
            }
            else
            {
                m_Text.GetComponent<Text>().text = "偵測中...";

            }
            m_Image.GetComponent<Image>().fillAmount = currentAmout / 100.0f;
        }
    }
}

