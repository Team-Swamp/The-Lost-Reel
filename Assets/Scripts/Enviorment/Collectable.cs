using UnityEngine;
using UnityEngine.Events;

public sealed class Collectable : MonoBehaviour, IPickupCollectable
{
    [SerializeField] private UnityEvent onCollectibleCollected = new UnityEvent();

    public void Pickup()
    {
        onCollectibleCollected?.Invoke();
        Destroy(gameObject);
    }
}