using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingRayCastDetection : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private float raycastLength = 2f;
    [SerializeField] private LayerMask ceilingLayer;
    [SerializeField] private Animator animator;

    private bool isTouchingCeiling = false;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin.position, Vector3.up, out hit, raycastLength, ceilingLayer))
        {
            isTouchingCeiling = true;
        }
        else
        {
            isTouchingCeiling = false;
        }

        animator.SetBool("IsCrawling", isTouchingCeiling);
    }
}
