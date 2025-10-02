using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public bool is_active = false;
    public AudioClip launch_noise;
    [Range(0f, 1f)] private float launch_volume = .2f;
    [SerializeField] private GameObject proj_prefab;
    private GameObject projectile;
    [SerializeField] private float spawn_delay;
    [SerializeField] private float proj_speed = 20.0f;
    [SerializeField] private float startup_delay = 0.0f;
    public bool first_time = true;
    // Start is called before the first frame update
    void Start()
    {
        projectile = (GameObject)Instantiate(proj_prefab);
        projectile.transform.parent = transform;
        projectile.GetComponent<MoveForward>().speed = proj_speed;
        projectile.SetActive(false);
        if (is_active)
        {
            StartCoroutine(StartSpawn());
        }
        
    }

    public void SpawnProjectile()
    {

        if (projectile != null)
        {
            projectile.SetActive(true);
            AudioSource.PlayClipAtPoint(launch_noise, transform.position, launch_volume);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.parent.transform.rotation;
        }
    }

    public IEnumerator StartSpawn()
    {
        if (first_time) { yield return new WaitForSeconds(startup_delay); first_time = false; }
        else { yield return new WaitForSeconds(spawn_delay); }
        SpawnProjectile();
    }

    public void ResetCannon()
    {
        projectile.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            projectile.SetActive(false);
            if (is_active)
            {
                StartCoroutine(StartSpawn());
            }
        }else if (other.CompareTag("Car"))
        {
            other.transform.parent.transform.parent.gameObject.SetActive(false);
            if (is_active)
            {
                StartCoroutine(StartSpawn());
            }
        }
    }
}
