using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool activated;
    public GameManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (transform.parent.name == "Checkpoint 2")
            {
                manager.ToggleCannons(true);
            }
            else if (transform.parent.name == "Checkpoint 3")
            {
                manager.ToggleCannons(false);
                manager.TogglePlatforms(true);
            }
            else if (transform.parent.name == "Checkpoint 5")
            {
                manager.TogglePlatforms(false);
            }
        }
    }
}
