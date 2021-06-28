using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DlibFaceLandmarkDetectorExample;
using FaceTrackerExample;

public class MainGameManager : MonoBehaviour
{

    static MainGameManager m_Instance;
    public static MainGameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType(typeof(MainGameManager)) as MainGameManager;

                if (m_Instance == null)
                {
                    var gameObject = new GameObject(typeof(MainGameManager).Name);
                    m_Instance = gameObject.AddComponent(typeof(MainGameManager)) as MainGameManager;
                }
            }
            return m_Instance;
        }
    }

    [SerializeField]
    GameObject MainGameUICanvas;

    [SerializeField]
    GameObject PlayerBird;

    [SerializeField]
    GameObject EnemyPool;

    [SerializeField]
    GameObject ColumnPool;

    [SerializeField]
    GameObject DetectQuad;
    [SerializeField]
    GameObject DetectQuadMasachi;

    [SerializeField]
    GameObject MasachiVideoPlay;

    [SerializeField]
    GameObject TipUICanvas;

    [SerializeField]
    GameObject RunCompleteUICanvas;

    [SerializeField]
    GameObject SceneBackGround;


    [SerializeField]
    GameObject MasachiInitUICanvas;

    [SerializeField]
    GameObject MasachiCompleteUICanvas;

    [SerializeField]
    GameObject GiveScoreUICanvas;

    [SerializeField]
    public GameObject FakeCurseUICanvas;

    [SerializeField]
    GameObject ReDetectFaceCanvas;


    public bool gameOver = false;
    
    public float scrollSpeed;

    GameObject mainMenuUICanvases;
    public GameObject MainMenuUICanvases
    {
        get { return mainMenuUICanvases; }
        set { mainMenuUICanvases = value; }
    }

    GameObject playerBirds;
    public GameObject PlayerBirds
    {
        get { return playerBirds; }
        set { playerBirds = value; }
    }

    GameObject columnPools;
    public GameObject ColumnPools
    {
        get { return columnPools; }
        set { columnPools = value; }
    }

    GameObject enemyPools;
    public GameObject EnemyPools
    {
        get { return enemyPools; }
        set { enemyPools = value; }
    }


    bool birdisTouchCanStand;
    public bool BirdisTouchCanStand
    {
        get { return playerBirds.GetComponent<Bird>().IsTouchCanStand; }
    }

    bool birdisDaed;
    public bool BirdisDead
    {
        get { return playerBirds.GetComponent<Bird>().IsDead; }
    }

    int nowStage;
    public int NowStage
    {
        get { return nowStage; }
        set { nowStage = value; }
    }

    GameObject detectQuad;
    public GameObject DetectQuads
    {
        get { return detectQuad; }
        set { detectQuad = value; }
    }

    GameObject detectQuadsMasachi;
    public GameObject DetectQuadsMasachis
    {
        get { return detectQuadsMasachi; }
        set { detectQuadsMasachi = value; }
    }

    GameObject masachiVideoPlay;
    public GameObject MasachiVideoPlays
    {
        get { return masachiVideoPlay; }
        set { masachiVideoPlay = value; }
    }

    GameObject tipUICanvas;
    public GameObject TipUICanvass
    {
        get { return tipUICanvas; }
        set { tipUICanvas = value; }
    }

    GameObject runCompleteUICanvas;
    public GameObject RunCompleteUICanvass
    {
        get { return runCompleteUICanvas; }
        set { runCompleteUICanvas = value; }
    }

    GameObject sceneBackGround;
    public GameObject SceneBackGrounds
    {
        get { return sceneBackGround; }
        set { sceneBackGround = value; }
    }

    GameObject masachiInitUICanvas;
    public GameObject MasachiInitUICanvass
    {
        get { return masachiInitUICanvas; }
        set { masachiInitUICanvas = value; }
    }

    GameObject masachiCompleteUICanvas;
    public GameObject MasachiCompleteUICanvass
    {
        get { return masachiCompleteUICanvas; }
        set { masachiCompleteUICanvas = value; }
    }

    GameObject giveScoreUICanvass;
    public GameObject GiveScoreUICanvass
    {
        get { return giveScoreUICanvass; }
        set { giveScoreUICanvass = value; }
    }

    GameObject reDetectFaceCanvas;
    public GameObject ReDetectFaceCanvass
    {
        get { return reDetectFaceCanvas; }
    }

    bool isDetectFace;
    public bool IsDetectFace
    {
        get { return isDetectFace; }
    }

    // 場景狀態
    MainGameStateControl m_MainGameStateController = new MainGameStateControl();
    // 獲取當前的狀態
    public MainGameStateControl.GameFlowState CurrentState
    {
        get { return m_MainGameStateController.GameState; }
    }

    WebCamTextureToMatHelperExampleMine webCamTextureToMatHelperExampleMine = null;
    FaceTrackerARExample FaceTrackerARExample = null;


    public void MainGameBegin()
    {
        // 設定起始State
        //m_MainGameStateController.SetState(MainGameStateControl.GameFlowState.MasachiVideoInit, m_MainGameStateController);

        m_MainGameStateController.SetState(MainGameStateControl.GameFlowState.RunInit, m_MainGameStateController);
        masachiVideoPlay = MasachiVideoPlay;
        tipUICanvas = TipUICanvas;
        runCompleteUICanvas = RunCompleteUICanvas;
        detectQuadsMasachi = DetectQuadMasachi;
        masachiCompleteUICanvas = MasachiCompleteUICanvas;
        masachiInitUICanvas = MasachiInitUICanvas;
        giveScoreUICanvass = GiveScoreUICanvas;
        reDetectFaceCanvas = ReDetectFaceCanvas;

     
    }

    public void MainGameUpdate()
    {
        m_MainGameStateController.StateUpdate();
        if (DetectQuads != null && webCamTextureToMatHelperExampleMine == null) webCamTextureToMatHelperExampleMine = DetectQuads.GetComponent<WebCamTextureToMatHelperExampleMine>();
        if (DetectQuadsMasachis != null && FaceTrackerARExample == null) FaceTrackerARExample = DetectQuadsMasachis.GetComponent<FaceTrackerExample.FaceTrackerARExample>();

        if (DetectQuads != null) isDetectFace = webCamTextureToMatHelperExampleMine.IsDetectFace;
    }


    /// <summary>
    /// 生成主選單初始物件
    /// </summary>
   public void InstantiateInitObject()
   {
        //mainMenuUICanvases = Instantiate(MainGameUICanvas);
        playerBirds = Instantiate(PlayerBird);
        columnPools = Instantiate(ColumnPool);
        enemyPools = Instantiate(EnemyPool);
        sceneBackGround = Instantiate(SceneBackGround);
        birdisDaed = playerBirds.GetComponent<Bird>().IsDead;
        detectQuad = Instantiate(DetectQuad);

    }

    public void ExitDestoryObject()
    {
        Destroy(playerBirds);
        Destroy(columnPools);
        Destroy(enemyPools);
        Destroy(sceneBackGround);
        Destroy(detectQuad);
    }

    /// <summary>
    /// 跳
    /// </summary>
    /// <returns></returns>
    public bool WasTouchedOrClicked()
    {
        if (DebugBtn.isDebug == false)
        {
            return false;
        }
        if (Input.GetMouseButtonDown(0)  ||
           (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended))//DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine.isBlink
        {
                return true;
        }
        else
        {
            return false;
        }
    }

    public bool isManualPause = false;

    public void PauseGame()
    {
        if (!isManualPause)
        {
            MasachiVideoPlays.GetComponent<VideoPlayer>().Pause();
            Time.timeScale = 0;
        }
          
    }

    public void PlayGame()
    {
        //WebCamTextureToMatHelperExampleMine webCamTextureToMatHelperExampleMine = null;
        //FaceTrackerARExample FaceTrackerARExample = null;
        //if (DetectQuads != null)
        //{
        //    webCamTextureToMatHelperExampleMine = DetectQuads.GetComponent<DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine>();
        //}
        //if (DetectQuadsMasachis != null)
        //{
        //    FaceTrackerARExample = DetectQuadsMasachis.GetComponent<FaceTrackerExample.FaceTrackerARExample>();
        //}

        //if (webCamTextureToMatHelperExampleMine != null) webCamTextureToMatHelperExampleMine.OnPlayButtonClick();
        //if (FaceTrackerARExample != null) FaceTrackerARExample.OnPlayButton();
        if (!isManualPause)
        {
            MasachiVideoPlays.GetComponent<VideoPlayer>().Play();
            Time.timeScale = 1;
        }
         
    }
}
