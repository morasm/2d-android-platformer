using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player" && FindObjectOfType<CollectedDiamonds>().diamonds == 5){
            FindObjectOfType<GameManager>().WinningGame();
            Destroy(gameObject);

        }
    }
}
