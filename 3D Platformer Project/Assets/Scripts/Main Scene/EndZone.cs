using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    [SerializeField] private float launch_delay;
    public GameManager manager;
    private CannonController cannon;
    // Start is called before the first frame update
    void Start()
    {
        cannon = GameObject.Find("End Cannon Controller").gameObject.GetComponent<CannonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && manager.count_time)
        {
            StartCoroutine(LaunchCountdown());
            manager.StopTimer();
        }
    }

    private IEnumerator LaunchCountdown()
    {
        yield return new WaitForSeconds(launch_delay);
        cannon.is_active = true;
        cannon.SpawnProjectile();
        cannon.is_active = false;
    }
}
