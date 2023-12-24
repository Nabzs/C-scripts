using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlashlightState{

    Off, // Eteinte
    On, // Allumée
    Dead // Morte
}

[RequireComponent(typeof(AudioSource))]

public class FlashlightManager : MonoBehaviour
{

[Header("Options")]

[Tooltip("vitesse de perte de batterie")] [Range(0.0f, 10f)][SerializeField] float batteryLossTick = 9f;

[Tooltip("Niveau de batterie avec le quel le joueur commence")] [SerializeField]int startBattery = 100 ; 

[Tooltip("Niveau de batterie que le joueur à actuelement")]public int currentBattery;

[Tooltip("Etat de la flashlight")]public FlashlightState state;

[Tooltip("Lampe on ?")]private bool flashlightIsOn;

[Tooltip("Touche pour activer la lampe ")][SerializeField] KeyCode ToggleKey = KeyCode.F;

[Header("References")]

[Tooltip("Lumiere qui est afficher quand la lampe est on")] [SerializeField] GameObject FlashlightLight;

[Tooltip("sons quand la lampe est activee on et off ")] [SerializeField] AudioClip FlashlightOn_FX,FlashlightOff_FX;

private void Start(){

    currentBattery=startBattery;

    InvokeRepeating(nameof(LoseBattery), 0,batteryLossTick);
}

private void Update()
{
if (Input.GetKeyDown(ToggleKey)) ToggleFlashlight();

if(state == FlashlightState.Off) FlashlightLight.SetActive(false);
else if (state == FlashlightState.Dead) FlashlightLight.SetActive(false);
else if (state == FlashlightState.On) FlashlightLight.SetActive(true);



if (currentBattery <= 0) 
{
currentBattery=0;
state = FlashlightState.Dead;
flashlightIsOn=false; // met le flash off
}

}


public void GainBattery(int amount) //Handle the gain of battery
{ 

 if(currentBattery == 0)
 {
    state = FlashlightState.On;
    flashlightIsOn= true;

 }

if(currentBattery + amount > startBattery)
    currentBattery=startBattery; //bloque la batterie max a cent
else
currentBattery+= amount;

}



private void LoseBattery(){

if(state== FlashlightState.On) currentBattery--; // enleve 1 si batterie est on

}


private void ToggleFlashlight()
{

flashlightIsOn=!flashlightIsOn;

if(state == FlashlightState.Dead) flashlightIsOn = false;



if (flashlightIsOn) 
{
    if (FlashlightOn_FX != null) GetComponent<AudioSource>().PlayOneShot(FlashlightOn_FX); // joue le son quand On
    state = FlashlightState.On; // tourne le flash on
}

else // tourne le flash off
{
    if (FlashlightOff_FX != null) GetComponent<AudioSource>().PlayOneShot(FlashlightOff_FX); // joue le son quand Off
    state = FlashlightState.Off;
} 

}

}
