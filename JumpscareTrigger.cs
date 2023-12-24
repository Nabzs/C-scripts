using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
  //Animation of jumpscare
  public Animation JumpscareAnimation;

  //Jumpscare audio
  public AudioSource JumpscareAudio;
  
  //quand le joueur regarde le trigger
    public void OnMouseOver()

    {
        JumpscareAnimation.Play();

        if (JumpscareAudio!=null)
        {
                JumpscareAudio.Play();
        }

        this.gameObject.SetActive(false);
    }

}
