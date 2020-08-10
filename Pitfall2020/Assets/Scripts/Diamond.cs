using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
        void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            collider.gameObject.SendMessage("DiamondPickup");
            Destroy(gameObject);

        }
    }
}
