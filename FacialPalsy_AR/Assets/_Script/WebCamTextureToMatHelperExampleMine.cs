#if !(PLATFORM_LUMIN && !UNITY_EDITOR)

using DlibFaceLandmarkDetector;
using OpenCVForUnity.CoreModule;
using OpenCVForUnity.ImgprocModule;
using OpenCVForUnity.UnityUtils.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
namespace DlibFaceLandmarkDetectorExample
{
    /// <summary>
    /// WebCamTextureToMatHelper Example
    /// </summary>
    [RequireComponent(typeof(WebCamTextureToMatHelper))]
    public class WebCamTextureToMatHelperExampleMine : MonoBehaviour
    {
        [SerializeField]
        Text openEyeTxt;
        [SerializeField]
        Text EyeTxt;


        /// <summary>
        /// The texture.
        /// </summary>
        Texture2D texture;

        /// <summary>
        /// The webcam texture to mat helper.
        /// </summary>
        WebCamTextureToMatHelper webCamTextureToMatHelper;

        /// <summary>
        /// The face landmark detector.
        /// </summary>
        FaceLandmarkDetector faceLandmarkDetector;

        /// <summary>
        /// The FPS monitor.
        /// </summary>
        FpsMonitor fpsMonitor;

        /// <summary>
        /// The dlib shape predictor file name.
        /// </summary>
        string dlibShapePredictorFileName = "sp_human_face_68.dat";

        /// <summary>
        /// The dlib shape predictor file path.
        /// </summary>
        string dlibShapePredictorFilePath;

        //計算張眼程度參數
        float EYE_AR_THRESH = 0.15f;
        float EYE_AR_THRESH_open = 0.28f;
        float EYE_AR_CONSEC_FRAMES = 2.5f;
        public float COUNTER = 0;
        public static int TOTAL = 0;

        [HideInInspector]
        public  bool isBlink = false;
        public static UnityAction BlinkingEye;

#if UNITY_WEBGL
        IEnumerator getFilePath_Coroutine;
#endif

        private void OnGUI()
        {
            //GUIStyle scoreStyle = new GUIStyle("box");
            //scoreStyle.fontSize = 40;
            //GUI.Box(new UnityEngine.Rect(10, 2000, 500, 300), "____TOTAL Blinking: " + TOTAL, scoreStyle);
        }


        // Use this for initialization
        void Start()
        {
            TimeCloseEyeCount = 0;
            COUNTER = 0;
            fpsMonitor = GetComponent<FpsMonitor>();

            webCamTextureToMatHelper = gameObject.GetComponent<WebCamTextureToMatHelper>();

            dlibShapePredictorFileName = DlibFaceLandmarkDetectorExample.dlibShapePredictorFileName;
#if UNITY_WEBGL
            getFilePath_Coroutine = DlibFaceLandmarkDetector.UnityUtils.Utils.getFilePathAsync(dlibShapePredictorFileName, (result) =>
            {
                getFilePath_Coroutine = null;

                dlibShapePredictorFilePath = result;
                Run();
            });
            StartCoroutine(getFilePath_Coroutine);
#else
            dlibShapePredictorFilePath = DlibFaceLandmarkDetector.UnityUtils.Utils.getFilePath(dlibShapePredictorFileName);
            Run();
#endif
        }

        private void Run()
        {
            if (string.IsNullOrEmpty(dlibShapePredictorFilePath))
            {
                Debug.LogError("shape predictor file does not exist. Please copy from “DlibFaceLandmarkDetector/StreamingAssets/” to “Assets/StreamingAssets/” folder. ");
            }

            faceLandmarkDetector = new FaceLandmarkDetector(dlibShapePredictorFilePath);

            webCamTextureToMatHelper.Initialize();
        }

        /// <summary>
        /// Raises the web cam texture to mat helper initialized event.
        /// </summary>
        public void OnWebCamTextureToMatHelperInitialized()
        {
            Debug.Log("OnWebCamTextureToMatHelperInitialized");

            Mat webCamTextureMat = webCamTextureToMatHelper.GetMat();

            texture = new Texture2D(webCamTextureMat.cols(), webCamTextureMat.rows(), TextureFormat.RGBA32, false);
            OpenCVForUnity.UnityUtils.Utils.fastMatToTexture2D(webCamTextureMat, texture);

            gameObject.GetComponent<Renderer>().material.mainTexture = texture;

            gameObject.transform.localScale = new Vector3(webCamTextureMat.cols(), webCamTextureMat.rows(), 1);
            Debug.Log("Screen.width " + Screen.width + " Screen.height " + Screen.height + " Screen.orientation " + Screen.orientation);

            if (fpsMonitor != null)
            {
                fpsMonitor.Add("dlib shape predictor", dlibShapePredictorFileName);
                fpsMonitor.Add("width", webCamTextureToMatHelper.GetWidth().ToString());
                fpsMonitor.Add("height", webCamTextureToMatHelper.GetHeight().ToString());
                fpsMonitor.Add("orientation", Screen.orientation.ToString());
            }


            float width = webCamTextureMat.width();
            float height = webCamTextureMat.height();

            float widthScale = 1; //(float)Screen.width / width;
            float heightScale = 1;//(float)Screen.height / height;//////////////////////////////////////////
            if (widthScale < heightScale)
            {
                Camera.main.orthographicSize = (width * (float)Screen.height / (float)Screen.width) / 2;
            }
            else
            {
                Camera.main.orthographicSize = height / 2;
            }
        }

        /// <summary>
        /// Raises the web cam texture to mat helper disposed event.
        /// </summary>
        public void OnWebCamTextureToMatHelperDisposed()
        {
            Debug.Log("OnWebCamTextureToMatHelperDisposed");

            if (texture != null)
            {
                Texture2D.Destroy(texture);
                texture = null;
            }
        }
        [HideInInspector]
        public static float TimeCloseEyeCount = 0;
        float _countNoDetextFace = 0;

        /// <summary>
        /// Raises the web cam texture to mat helper error occurred event.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        public void OnWebCamTextureToMatHelperErrorOccurred(WebCamTextureToMatHelper.ErrorCode errorCode)
        {
            Debug.Log("OnWebCamTextureToMatHelperErrorOccurred " + errorCode);

            if (fpsMonitor != null)
            {
                fpsMonitor.consoleText = "ErrorCode: " + errorCode;
            }
        }
    
        // Update is called once per frame
        void Update()
        {
            //測適用
            if (Input.GetMouseButtonDown(0))
            {
                TOTAL += 1;
            }



            if (webCamTextureToMatHelper.IsPlaying() && webCamTextureToMatHelper.DidUpdateThisFrame())
            {

                Mat rgbaMat = webCamTextureToMatHelper.GetMat();

                OpenCVForUnityUtils.SetImage(faceLandmarkDetector, rgbaMat);

                //detect face rects
                List<UnityEngine.Rect> detectResult = faceLandmarkDetector.Detect();

                //有無偵測到人臉
                if (detectResult != null)
                {
                    //沒偵測到人臉
                    if (detectResult.Count < 1)
                    {
                        Debug.Log("沒有人臉");

                        //人臉沒測到0.8以上
                        _countNoDetextFace += Time.deltaTime;
                        if (_countNoDetextFace > 0.8f)
                        {
                            COUNTER = 0;
                        }
                    }
                }
                isBlink = false;

                foreach (var rect in detectResult)
                {
                    //detect landmark points
                    List<Vector2> points = faceLandmarkDetector.DetectLandmark(rect);

                    //draw landmark points
                    OpenCVForUnityUtils.DrawFaceLandmark(rgbaMat, points, new Scalar(0, 255, 0, 255), 1, true);


                    //draw face rect
                    OpenCVForUnityUtils.DrawFaceRect(rgbaMat, rect, new Scalar(255, 0, 0, 255), 1);

                    //EyeOpenAmount，blinking dectection
                    float leftEye = LeftEyeOpenAmount(rect);
                    float righttEye = RightEyeOpenAmount(rect);

                    //判斷閉眼
                    if (leftEye < EYE_AR_THRESH && righttEye < EYE_AR_THRESH)
                    {
                        //計算閉眼多久
                        COUNTER += 1*Time.deltaTime;
                        //_timeOpenEyeCount = 0;

                        TimeCloseEyeCount += 1 * Time.deltaTime;
                        openEyeTxt.text = "得分: " + Math.Round(TimeCloseEyeCount, 2)  ;
                    }
                    else if(leftEye > EYE_AR_THRESH_open && righttEye > EYE_AR_THRESH_open)
                    {
                        if (COUNTER >= EYE_AR_CONSEC_FRAMES)
                        {
                            COUNTER = 0;

                            if (MainGameManager.Instance.BirdisTouchCanStand)
                            {
                                TOTAL += 1;
                                isBlink = true;
                                if (BlinkingEye != null) BlinkingEye();
                            }
     
                        }
                    }
           
                    EyeTxt.text = "leftEye" + leftEye+ "\nrighttEye" + righttEye;
                }
                //Debug.Log("___TOTAL" + TOTAL);

                //Imgproc.putText (rgbaMat, "W:" + rgbaMat.width () + " H:" + rgbaMat.height () + " SO:" + Screen.orientation, new Point (5, rgbaMat.rows () - 10), Imgproc.FONT_HERSHEY_SIMPLEX, 0.5, new Scalar (255, 255, 255, 255), 1, Imgproc.LINE_AA, false);

                OpenCVForUnity.UnityUtils.Utils.fastMatToTexture2D(rgbaMat, texture);
            }
        }


        /// <summary>
        /// 眼睛張開的程度
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        float LeftEyeOpenAmount(UnityEngine.Rect rect)
        {
            float disY_37_41 = 0;
            float disY_38_40 = 0;
            float disX_36_39 = 0;
            List<Vector2> points = faceLandmarkDetector.DetectLandmark(rect);

            disY_37_41 = (Vector2.Distance(points[37], points[41]));
            disY_38_40 = (Vector2.Distance(points[38], points[40]));
            disX_36_39 = (Vector2.Distance(points[36], points[39]));

            float leftEyeOpenAmount = (disY_37_41 + disY_38_40) / (disX_36_39 * 2);
            //Debug.Log("eyeOpenAmount: " + eyeOpenAmount);

            return leftEyeOpenAmount;
        }

        /// <summary>
        /// 眼睛張開的程度
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        float RightEyeOpenAmount(UnityEngine.Rect rect)
        {
            float disY_44_46 = 0;
            float disY_43_47 = 0;
            float disX_42_45 = 0;
            List<Vector2> points = faceLandmarkDetector.DetectLandmark(rect);

            disY_44_46 = (Vector2.Distance(points[44], points[46]));
            disY_43_47 = (Vector2.Distance(points[43], points[47]));
            disX_42_45 = (Vector2.Distance(points[42], points[45]));

            float rightEyeOpenAmount = (disY_44_46 + disY_43_47) / (disX_42_45 * 2);
            //Debug.Log("eyeOpenAmount: " + eyeOpenAmount);

            return rightEyeOpenAmount;
        }


        /// <summary>
        /// Raises the destroy event.
        /// </summary>
        void OnDestroy()
        {
            if (webCamTextureToMatHelper != null)
                webCamTextureToMatHelper.Dispose();

            if (faceLandmarkDetector != null)
                faceLandmarkDetector.Dispose();

#if UNITY_WEBGL
            if (getFilePath_Coroutine != null)
            {
                StopCoroutine(getFilePath_Coroutine);
                ((IDisposable)getFilePath_Coroutine).Dispose();
            }
#endif
        }

        /// <summary>
        /// Raises the back button click event.
        /// </summary>
        public void OnBackButtonClick()
        {
            SceneManager.LoadScene("DlibFaceLandmarkDetectorExample");
        }

        /// <summary>
        /// Raises the play button click event.
        /// </summary>
        public void OnPlayButtonClick()
        {
            webCamTextureToMatHelper.Play();
        }

        /// <summary>
        /// Raises the pause button click event.
        /// </summary>
        public void OnPauseButtonCkick()
        {
            webCamTextureToMatHelper.Pause();
        }

        /// <summary>
        /// Raises the stop button click event.
        /// </summary>
        public void OnStopButtonClick()
        {
            webCamTextureToMatHelper.Stop();
        }

        /// <summary>
        /// Raises the change camera button click event.
        /// </summary>
        public void OnChangeCameraButtonClick()
        {
            webCamTextureToMatHelper.requestedIsFrontFacing = !webCamTextureToMatHelper.IsFrontFacing();
        }
    }
}

#endif