using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedCoins : MonoBehaviour
{
    public int points;
    public AudioClip audioClip;
    void Start()
    {
        points = 0;
    }

    void CoinPickup(){
        points += 100;
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }
}
