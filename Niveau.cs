using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveau : MonoBehaviour
{

    public string NomDeScene;
    public void AllerNiveauSuivant()
    {
        SceneManager.LoadScene(NomDeScene);
    }

    public void OnTriggerEnter(Collider other) 
    {
        AllerNiveauSuivant();
    }

}

