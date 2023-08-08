using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Collectable : MonoBehaviour, IPickupCollectable
{
    [SerializeField] private UnityEvent OnCollectibleCollected = new UnityEvent();

    public void Pickup()
    {
        Destroy(gameObject);
        OnCollectibleCollected?.Invoke();
    }
}