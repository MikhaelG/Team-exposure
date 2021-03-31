using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, dashSound, hitSound; //de ljud som ska spelas - Mikhael
    static AudioSource audioSrc;

    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump"); //referenser
        dashSound = Resources.Load<AudioClip>("dash");
        hitSound = Resources.Load<AudioClip>("hit");
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jumpSound); //spela ljudet en gång när man hoppar - Mikhael
                break;

            case "dash":
                audioSrc.PlayOneShot(dashSound); //spela ljudet en gång när man gör dash - Mikhael
                break;
           
            case "hit":
                audioSrc.PlayOneShot(hitSound); //spela ljudet en gång när man tar skada - Mikhael
                break;
        }
    }
}

