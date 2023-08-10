using UnityEngine;

public sealed class CeilingDetection : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float raycastLength = 2f;
    [SerializeField] private LayerMask ceilingLayer;
    [field: SerializeField] public bool IsTouchingCeiling { get; private set; }

    private void Update() => IsTouchingCeiling = Physics.Raycast(transform.position, Vector3.up, out _, raycastLength, ceilingLayer);
}
