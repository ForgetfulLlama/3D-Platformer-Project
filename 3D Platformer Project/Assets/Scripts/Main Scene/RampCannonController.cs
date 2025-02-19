using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampCannonController : MonoBehaviour
{
    public bool is_active;
    [SerializeField] private List<Vector3> spawn_locations;
    private int num_spawn_locations = 7;
    [SerializeField] private float spawn_delay;
    [SerializeField] private bool spawning;
    [SerializeField] private float base_speed = 500;
    private float speed_range = 150;

    // Update is called once per frame
    void Update()
    {
        if (is_active && !spawning)
        {
            spawning = true;
            StartCoroutine(SpawnRampProjectile());
        }
    }

    private IEnumerator SpawnRampProjectile()
    {
        yield return new WaitForSeconds(spawn_delay);
        GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
        if (pooledProjectile != null)
        {
            pooledProjectile.SetActive(true);
            int rand_spawn = Random.Range(0, num_spawn_locations);
            pooledProjectile.transform.position = spawn_locations[rand_spawn];
            pooledProjectile.transform.eulerAngles = new Vector3(30,0,0);
            Rigidbody proj = pooledProjectile.GetComponent<Rigidbody>();
            proj.velocity = Vector3.zero;
            proj.angularVelocity = Vector3.zero;
            Vector3 launch_angle = new Vector3(Random.Range(-.8f,.8f), -1f, 1f);
            float proj_speed = Random.Range(base_speed - speed_range, base_speed + speed_range);
            proj.AddForce(launch_angle * proj_speed, ForceMode.Impulse);
        }
        spawning = false;
    }
}
