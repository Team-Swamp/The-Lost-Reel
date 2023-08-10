using UnityEngine;

public sealed class CeilingRayCastDetection : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField, Range(0, 10)] private float raycastLength = 2f;
    [SerializeField] private LayerMask ceilingLayer;
    

    private bool isTouchingCeiling;

    public bool IsTouchingCeiling => isTouchingCeiling;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, raycastLength, ceilingLayer))
        {
            isTouchingCeiling = true;
        }
        else
        {
            isTouchingCeiling = false;
        }
    }
}
