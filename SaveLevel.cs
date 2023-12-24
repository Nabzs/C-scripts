using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevel : MonoBehaviour
{
 
    public GameObject SaveGameUI; //save game

[Range(1,30)] public float timeBetweenSaves; //time between saves

    void Awake()
    {
     InvokeRepeating(nameof(SaveGame), timeBetweenSaves, timeBetweenSaves);   
    }


public void SaveGame()

    {
        SaveGameUI.SetActive(true);

    // SAVE MECHANICS ONLY
    PlayerPrefs.SetString("loaded level",SceneManager.GetActiveScene().name);

    PlayerPrefs.Save();

        Invoke(nameof(HideUI), 3);
    }

    public void HideUI()
    {
        SaveGameUI.SetActive(false);
    }

}
