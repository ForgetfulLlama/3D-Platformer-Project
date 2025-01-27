using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampSectionManager : MonoBehaviour
{
    private ThirdPersonController player_script;
    [SerializeField] private RampCannonController cannon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Reduce player speed
            player_script = other.gameObject.GetComponent<ThirdPersonController>();
            player_script.MoveSpeed /= 2;
            player_script.SprintSpeed /= 2;

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
            player_script.MoveSpeed *= 2;
            player_script.SprintSpeed *= 2;

            //Deactivate cannon
            cannon.is_active = false;
        }
        else if (other.CompareTag("Projectile"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
