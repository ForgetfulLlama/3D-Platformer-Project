using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampSectionManager : MonoBehaviour
{
    private ThirdPersonController player_script;
    [SerializeField] private RampCannonController cannon;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Reduce player speed
            player_script = other.gameObject.GetComponent<ThirdPersonController>();
            player_script.MoveSpeed *= 0.65f;
            player_script.SprintSpeed *= 0.65f;

            //Activate cannon
            cannon.is_active = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Restore player speed
            player_script = other.gameObject.GetComponent<ThirdPersonController>();
            player_script.MoveSpeed /= 0.65f;
            player_script.SprintSpeed /= 0.65f;

            //Deactivate cannon
            cannon.is_active = false;
        }
        else if (other.CompareTag("Projectile"))
        {
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Car"))
        {
            other.transform.parent.transform.parent.gameObject.SetActive(false);
        }
    }
}
