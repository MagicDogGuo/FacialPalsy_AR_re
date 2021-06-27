using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]
    AudioClip jumpSound;
    [SerializeField]
    AudioClip deadSound;

    AudioSource ads;

    [SerializeField]
    float VelocityPerJump = 100;


    [SerializeField]
    Sprite[] birdsprite =new Sprite[3];

    public bool IsTouchCanStand=false;
    public bool fallingCheck = false;
    public bool JumpingCheck = false;
    public bool IsDead;


    bool startDelayCount = false;
    float delayCount = 0;
    float delayTime = 0.5f;

    public float FallingSpeed;
    public float jumpforce;


    Rigidbody2D rigidbody2D;
    SpriteRenderer thisSprite;


    // Start is called before the first frame update
    void Start()
    {
        DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine.BlinkingEye += BoostOnYAxis;

        IsTouchCanStand = false;
        IsDead = false;

        rigidbody2D = this.GetComponent<Rigidbody2D>();
        thisSprite = this.GetComponent<SpriteRenderer>();

        ads = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //跳鳥
        if (MainGameManager.Instance.WasTouchedOrClicked())
        {
            BoostOnYAxis();
            // DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine.isBlink = false;
       
        }
        FallingFunction();
        JumpingFunction();

        if (fallingCheck)
        {
            thisSprite.sprite = birdsprite[2];
        }
        else if(IsTouchCanStand)
        {
            thisSprite.sprite = birdsprite[0];
        }
        else if (JumpingCheck)
        {
            thisSprite.sprite = birdsprite[1];

        }
    }

    void BoostOnYAxis()
    {
        if(IsTouchCanStand == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, VelocityPerJump);

            ads.clip = jumpSound;
            ads.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "CanStand")
        {
            IsTouchCanStand = true;
            fallingCheck = false;
        }
        if (collision.gameObject.tag == "CannotTouch")
        {
            IsDead = true;
            ads.clip = deadSound;
            ads.Play();
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CanStand")
        {
            IsTouchCanStand = false;

        }
    }


    //void JumpToFall()
    //{
    //    FallingSpeed = rigidbody2D.velocity.y;
    //    //Debug.Log (rigidbody2D.velocity.y);
    //    if (FallingSpeed <= 1 && IsTouchCanStand == false)
    //    {
    //        jumptofallcheck = true;
    //        //Debug.Log("jumptofall!!");

    //    }
    //}

    void FallingFunction()
    {
        FallingSpeed = rigidbody2D.velocity.y;
        if (FallingSpeed < 0 && IsTouchCanStand == false)
        {
            fallingCheck = true;
            JumpingCheck = false;
        }

    }

    void JumpingFunction()
    {
        FallingSpeed = rigidbody2D.velocity.y;
        if (FallingSpeed > 0 && IsTouchCanStand == false)
        {
            JumpingCheck = true;
        }

    }
}
