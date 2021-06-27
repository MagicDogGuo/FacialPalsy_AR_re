using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour 
{

    [SerializeField]
    float moveDistance=120;//與踏板間距相同

    float changeXpos;

    void Start () 
	{
        changeXpos = this.transform.position.x;
        DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine.BlinkingEye += ChangePos;

    }

    void Update()
	{
 
        if (MainGameManager.Instance.WasTouchedOrClicked())
        {
            ChangePos();
        }
        Vector2 newPos = new Vector2(changeXpos, this.transform.position.y);
        this.transform.position = Vector2.Lerp(this.transform.position, newPos,0.1f);
	}

    void ChangePos()
    {
        if (MainGameManager.Instance.BirdisTouchCanStand)
        {
            changeXpos = this.transform.position.x - moveDistance;
        }
    }
}
