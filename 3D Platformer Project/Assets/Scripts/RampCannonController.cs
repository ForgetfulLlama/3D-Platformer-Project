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
    [SerializeField] private float proj_speed = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

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
            Vector3 launch_angle = new Vector3(0, -1, 1);
            proj.AddForce(launch_angle * proj_speed, ForceMode.Impulse);
        }
        spawning = false;
    }
}
