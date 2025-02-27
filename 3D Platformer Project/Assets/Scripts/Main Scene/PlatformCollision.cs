using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    [SerializeField] Transform platform;
    [SerializeField] string playerTag = "Player";
    private Transform originalParent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            originalParent = other.gameObject.transform.parent;
            other.gameObject.transform.parent = platform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            other.gameObject.transform.parent = originalParent;
        }
    }
}
