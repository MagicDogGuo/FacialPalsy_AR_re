using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentUiComp : MonoBehaviour
{
    [SerializeField]
    Image NowImage;
    [SerializeField]
    Image CorrentImage;

    [SerializeField]
    Button nowPhotoBtn;

    [SerializeField]
    Camera myCamera;

    [SerializeField]
    GameObject SHOTBLACK;

    public string deviceName;

    float delaycount = 0;


    public static Sprite NowImg_FakeUIPhoto;

    // Start is called before the first frame update
    void Start()
    {

        nowPhotoBtn.onClick.AddListener(() => {
            
            StartCoroutine(Screenshot());
            delaycount = 0;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (SHOTBLACK.GetComponent<Image>().enabled == true)
        {
            delaycount += Time.deltaTime;
            if(delaycount>=0.4f) SHOTBLACK.GetComponent<Image>().enabled = false;
        }
    }

    IEnumerator Screenshot()
    {
        //在擷取畫面之前請等到所有的Camera都Render完
        yield return new WaitForEndOfFrame();

        Texture2D texture = new Texture2D((int)myCamera.pixelWidth, (int)myCamera.pixelHeight);
        //擷取全部畫面的資訊
        texture.ReadPixels(new Rect(0, 0, (int)myCamera.pixelWidth, (int)myCamera.pixelHeight), 0, 0, false);
        texture.Apply();


        // Assign texture to a temporary quad and destroy it after 5 seconds
        //GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        //quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
        //quad.transform.forward = Camera.main.transform.forward;
        //quad.transform.localScale = new Vector3(1f, texture.height / (float)texture.width, 1f);

        //Material material = quad.GetComponent<Renderer>().material;
        //if (!material.shader.isSupported) // happens when Standard shader is not included in the build
        //    material.shader = Shader.Find("Legacy Shaders/Diffuse");

        //material.mainTexture = texture;

        yield return new WaitForSeconds(0.3f);
        //自己處理畫面資料的方法
        NowImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());//set the Rect with position and dimensions as you need
        CorrentImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());//set the Rect with position and dimensions as you need
        NowImg_FakeUIPhoto = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());

        SHOTBLACK.GetComponent<Image>().enabled = true;

        yield return new WaitForSeconds(1);
        ScrollRecoverUI.Page = 5;
    }
}
