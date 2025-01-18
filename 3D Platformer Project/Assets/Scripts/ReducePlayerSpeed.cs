using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReducePlayerSpeed : MonoBehaviour
{
    private ThirdPersonController player_script;
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
            player_script = other.gameObject.GetComponent<ThirdPersonController>();
            player_script.MoveSpeed /= 2;
            player_script.SprintSpeed /= 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_script = other.gameObject.GetComponent<ThirdPersonController>();
            player_script.MoveSpeed *= 2;
            player_script.SprintSpeed *= 2;
        }
    }
}
