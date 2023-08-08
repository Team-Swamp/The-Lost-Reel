using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        IPickupCollectable collectible = collision.GetComponent<IPickupCollectable>();
        if(collectible != null)
        {
            collectible.Pickup();
        }
    }
}
