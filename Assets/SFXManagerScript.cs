using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManagerScript : MonoBehaviour
{
    public static AudioClip shotgunShot, minigunShot, zombieDeath, playerDeath;
    public static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        shotgunShot = Resources.Load<AudioClip>("shotgunSound");
        minigunShot = Resources.Load<AudioClip>("MinigunSound");
        zombieDeath = Resources.Load<AudioClip>("MonsterExplosion");
        
        // playerDeath =  Resources.Load<AudioClip>("PlayerDeath");
        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip){
        switch (clip){
            case "zombieDeath":
                audioSrc.PlayOneShot(zombieDeath);
                break;
            case "shotgunSound":
                audioSrc.PlayOneShot(shotgunShot);
                break;
            case "MinigunSound":
                audioSrc.PlayOneShot(minigunShot);
                break;
            // case "zombieGrowl":
            //     audioSrc.PlayOneShot(zombieGrowl);
            //     break;
            // case "zombieBite":
            //     audioSrc.PlayOneShot(zombieBite);
            //     break;
            // case "playerDeath":
            //     audioSrc.PlayOneShot(playerDeath);
            //     break;
            }
    }
}
