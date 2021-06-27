using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasachiCompleteUIComp : MonoBehaviour
{
    [SerializeField]
    Button nextStepBtn;

    // Start is called before the first frame update
    void Start()
    {
        nextStepBtn.onClick.AddListener(() => { GameEventSystem.Instance.MasachiCompleteBtn_MainGameBtn(); });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
