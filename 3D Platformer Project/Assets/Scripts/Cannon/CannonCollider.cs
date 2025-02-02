using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCollider : CannonController
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            if (is_active)
            {
                other.gameObject.SetActive(false);
                //StartCoroutine(StartSpawn());
            }
        }
    }
}
