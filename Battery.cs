using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{

[Header("Options")]

[Tooltip("The battery that the player gains when they collect this.")] [SerializeField] int batteryWeight;

[Tooltip("Key that needs to be pressed to collect this battery.")] [SerializeField] KeyCode CollectKey= KeyCode.E;

[Header("References")]
[Tooltip("The objects that is shown when the player hovers.")] [SerializeField] GameObject[] HoverObject;
 

public void OnMouseOver()
{
    foreach (GameObject obj in HoverObject) obj.SetActive(true);

    if (Input.GetKeyDown(CollectKey))
    {
        FindObjectOfType<FlashlightManager>().GainBattery(batteryWeight);
    
        Destroy(this.gameObject);
    }
}

public void OnMouseExit()
    {
        foreach(GameObject obj in HoverObject) obj.SetActive(false);
    }

}
