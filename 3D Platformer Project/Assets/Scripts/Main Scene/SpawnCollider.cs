using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    public GameManager manager;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !manager.count_time)
        {
            manager.StartTimer();
        }
    }
}
