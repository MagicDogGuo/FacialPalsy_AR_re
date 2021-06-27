using UnityEngine;
using System.Collections;

public class ColumnPool : MonoBehaviour 
{
	public GameObject columnPrefab;									//The column game object.
	public int columnPoolSize = 5;									//How many columns to keep on standby.
	public float columnMin = -1f;									//Minimum y value of the column position.
	public float columnMax = 3.5f;									//Maximum y value of the column position.

	private GameObject[] columns;									//Collection of pooled columns.
	private int currentColumn = 0;									//Index of the current column in the collection.

    float oriX =-100;
    float oriY = -25;


    float planeSpace = 120;//120;


    void Start()
	{
        Vector2 initialObjectPoolPosition = new Vector2(oriX, oriY);

        //Initialize the columns collection.
        columns = new GameObject[columnPoolSize];
        //Loop through the collection... 
        for (int i = 0; i < columnPoolSize; i++)
        {
            float spawnYPosition = Random.Range(columnMin, columnMax);
            Vector2 spawnPos = initialObjectPoolPosition + new Vector2(i * planeSpace, spawnYPosition);
            //...and create the individual columns.
            columns[i] = (GameObject)Instantiate(columnPrefab, spawnPos, Quaternion.identity);
            columns[i].transform.parent = this.transform;
        }
        //第一個踏板
        columns[0].transform.position = initialObjectPoolPosition;
        DlibFaceLandmarkDetectorExample.WebCamTextureToMatHelperExampleMine.BlinkingEye += Move;
    }


    //This spawns columns as long as the game is not over.
    void Update()
	{
        if (MainGameManager.Instance.gameOver == false & MainGameManager.Instance.WasTouchedOrClicked())
        {
           Move();
        }
    }

    private void Move()
    {
        if (MainGameManager.Instance.BirdisTouchCanStand)
        {
            //Set a random y position for the column
            float spawnYPosition = Random.Range(columnMin, columnMax);

            float spawnXPosition = ((columnPoolSize) * planeSpace) + oriX;

            //...then set the current column to that position.
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            currentColumn++;

            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
       
    }
}