using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collectable : MonoBehaviour, IPickupCollectable
{
    public static event Action OnCollectibleCollected;

    public void Pickup()
    {
        Debug.Log("picked up collectable");
        Destroy(gameObject);
        OnCollectibleCollected?.Invoke();
    }

    
}
