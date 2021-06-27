using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIComp : MonoBehaviour
{
    [SerializeField]
    Image oldImage;

    [SerializeField]
    Image oldCheckImage;

    [SerializeField]
    Text StateTxt;

    [SerializeField]
    Button UploadBtn;


    public static Sprite OldImg_FakeUIPhoto;

    // Start is called before the first frame update
    void Start()
    {
        UploadBtn.onClick.AddListener(() => { StartCoroutine(PickImages(512)); });
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (Input.mousePosition.x < Screen.width * 2 / 3)
        //    {
        //        // Pick a PNG image from Gallery/Photos
        //        // If the selected image's width and/or height is greater than 512px, down-scale the image
        //        PickImage(512);
        //    }
        //}
    }

    IEnumerator PickImages(int maxSize)
    {
        yield return new WaitForEndOfFrame();
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                oldImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());//set the Rect with position and dimensions as you need
                oldCheckImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());
                OldImg_FakeUIPhoto = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());

                StateTxt.text = "OK";
            }
            else
            {
                StateTxt.text = "上傳失敗";
            }
        }, "Select a PNG image", "image/png");

        Debug.Log("Permission result: " + permission);

        yield return new WaitForSeconds(0.5f);

        if (StateTxt.text == "OK")
        {
            yield return new WaitForSeconds(1f);
            ScrollRecoverUI.Page = 2;
        }
    }
/*
    private void PickImage(int maxSize)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                oldImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());//set the Rect with position and dimensions as you need
                oldCheckImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());//set 

                StateTxt.text = "OK";
                ScrollRecoverUI.Page = 2;
 
            }
            else
            {
                StateTxt.text = "上傳失敗";
            }
        }, "Select a PNG image", "image/png");

        Debug.Log("Permission result: " + permission);
    }
*/
}
