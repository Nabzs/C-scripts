using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenerationManager : MonoBehaviour
{

[SerializeField] Transform WorldGrid;

[SerializeField] List<GameObject> RoomPrefabs;

[SerializeField] int mapSize = 32; // Size map

[SerializeField] Slider MapSizeSlider, EmptinessSlider;

[SerializeField] Button GenerateButton;

[SerializeField] GameObject E_Room; // Empty Room Prefab


public int mapEmptiness; // chance of empty romm to spawn

private int mapSizeSquare;

private Vector3 currentPos;

private float currentPosX, currentPosZ, currentPosTracker;

public float roomSize = 7;



private void Update()
{
    mapSize = (int)Mathf.Pow(MapSizeSlider.value, 4);
    mapSizeSquare = (int)Mathf.Sqrt(mapSize);
    mapEmptiness = (int)EmptinessSlider.value;
}


public void ReloadWorld()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reload the scene
}



public void GenerateWorld()
{

    for (int i = 0; i < mapEmptiness; i++)
    {
        RoomPrefabs.Add(E_Room); // add an empty room prefab
    }
    GenerateButton.interactable = false;
    for (int i = 0; i < mapSize; i++)
    {

        if(currentPosTracker == mapSizeSquare) 
        {
            currentPosX = 0;
            currentPosTracker = 0;
            currentPosZ += roomSize;

        }
            currentPos = new (currentPosX, 0, currentPosZ); // pass in our position
            Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Count)], currentPos, Quaternion.identity, WorldGrid); // instantiates the room type at the current position

            currentPosTracker++; // keeps track of the current position X, without using the room size
            currentPosX += roomSize; // ad more position to the current position X, wich go to the right a bit more
    }

}

}
