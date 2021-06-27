using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRecoverUI : MonoBehaviour
{
    [SerializeField]
    GameObject DetectQuadObj;

    public static int Page = 1;


    enum PagePos
    {
        page01 = 7000,
        page02 = 5500,
        page03 = 4000,
        page04 = 2800,
        page05 = 1450,
        page06 = 0
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (Page)
        {
            case 1:
                this.GetComponent<RectTransform>().anchoredPosition = new Vector3((float)PagePos.page01, GetComponent<RectTransform>().anchoredPosition.y);
                  break;
            case 2:
                this.GetComponent<RectTransform>().anchoredPosition = new Vector3((float)PagePos.page02, GetComponent<RectTransform>().anchoredPosition.y);
                break;
            case 3:
                this.GetComponent<RectTransform>().anchoredPosition = new Vector3((float)PagePos.page03, GetComponent<RectTransform>().anchoredPosition.y);
                break;
            case 4:
                this.GetComponent<RectTransform>().anchoredPosition = new Vector3((float)PagePos.page04, GetComponent<RectTransform>().anchoredPosition.y);
                DetectQuadObj.transform.position = Vector3.zero;

                break;
            case 5:
                this.GetComponent<RectTransform>().anchoredPosition = new Vector3((float)PagePos.page05, GetComponent<RectTransform>().anchoredPosition.y);
                DetectQuadObj.transform.position = new Vector3(5000, 0, 0);

                break;
            case 6:
                this.GetComponent<RectTransform>().anchoredPosition = new Vector3((float)PagePos.page06, GetComponent<RectTransform>().anchoredPosition.y);
                break;

        }

    }
}
