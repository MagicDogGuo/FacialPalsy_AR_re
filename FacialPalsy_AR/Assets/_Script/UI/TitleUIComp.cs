using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUIComp : MonoBehaviour
{
    [SerializeField]
    Button LogInBtn;

    [SerializeField]
    Image titleImg;

    [SerializeField]
    Sprite[] tiltleSprite = new Sprite[8];

    [SerializeField]
    Text txtLoad;

    int page=0;
    // Start is called before the first frame update
    void Start()
    {
        titleImg.sprite = tiltleSprite[page];
        LogInBtn.GetComponent<Image>().enabled = false;
        LogInBtn.onClick.AddListener(() => { });

        txtLoad.text = "Loading...";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            txtLoad.enabled = true;

            //if(page < tiltleSprite.Length-1)page++;
            //titleImg.sprite = tiltleSprite[page];
            //if(page >= tiltleSprite.Length-1) LogInBtn.GetComponent<Image>().enabled = true;
            if (GameEventSystem.Instance.OnPushLogInBtn != null) GameEventSystem.Instance.OnPushLogInBtn();
        }
    }

}
