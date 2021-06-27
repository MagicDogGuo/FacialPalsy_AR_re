using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeNumber : MonoBehaviour
{
    [SerializeField]
    Text togetherText;

    int togetherPeoples = 300;
    float randomTime = 2;
    float countTime;
    // Start is called before the first frame update
    void Start()
    {
        togetherText.text = "有"+togetherPeoples + "人\n正一起復健!";

    }

    void Update()
    {
        countTime += Time.deltaTime;
        if(countTime > randomTime)
        {
            int randomPeople = togetherPeoples + Random.Range(1, 16);
            togetherText.text="有"+ randomPeople+"人\n正一起復健!";
            randomTime = Random.Range(1, 6);
            countTime = 0;


        }
    }
}
