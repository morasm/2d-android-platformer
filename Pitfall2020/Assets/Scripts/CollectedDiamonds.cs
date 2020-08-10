using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedDiamonds : MonoBehaviour
{
    public int diamonds;
    public AudioClip audioClip;
    void Start()
    {
        diamonds = 0;
    }

    void DiamondPickup(){
        diamonds += 1;
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        Debug.Log("Scores: " + diamonds);
    }
}
