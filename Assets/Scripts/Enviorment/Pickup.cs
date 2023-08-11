using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        var collectible = collision.GetComponent<IPickupCollectable>();
        collectible?.Pickup();
    }
}
