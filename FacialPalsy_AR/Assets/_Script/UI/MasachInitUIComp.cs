using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MasachInitUIComp : MonoBehaviour
{

    [SerializeField]
    Button RotationImgTipBtn;

    [SerializeField]
    Button AnchorImgTipBtn;


    // Start is called before the first frame update
    void Start()
    {
        RotationImgTipBtn.onClick.AddListener(() => { OnPushRotationImgTipBtn(); });
        AnchorImgTipBtn.onClick.AddListener(() => { OnPushAnchorImgTipBtn(); });

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPushRotationImgTipBtn()
    {
        RotationImgTipBtn.gameObject.SetActive(false);
        AnchorImgTipBtn.gameObject.SetActive(true);
        AnchorImgTipBtn.transform.parent.gameObject.SetActive(true);


        // 螢幕翻轉為 向右倒, 話筒在右, 且不能翻轉
        Screen.orientation = ScreenOrientation.LandscapeRight;

    }

    void OnPushAnchorImgTipBtn()
    {
        GameEventSystem.Instance.MasachiInitBtn_MainGameBtn();
    }
}
