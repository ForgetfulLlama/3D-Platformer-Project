using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public bool is_active;
    [SerializeField] private List<Vector3> spawn_locations;
    private int num_spawn_locations = 7;
    [SerializeField] private float spawn_delay;
    [SerializeField] private bool spawning;
    private float proj_speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(is_active && !spawning)
        {
            spawning = true;
            StartCoroutine(SpawnProjectile());
        }
    }

    private IEnumerator SpawnProjectile()
    {
        yield return new WaitForSeconds(spawn_delay);
        GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
        if (pooledProjectile != null)
        {
            pooledProjectile.SetActive(true);
            int rand_spawn = Random.Range(0, num_spawn_locations);
            pooledProjectile.transform.position = spawn_locations[rand_spawn];
            Rigidbody proj = pooledProjectile.GetComponent<Rigidbody>();
            proj.velocity = Vector3.zero;
            proj.angularVelocity = Vector3.zero;
            proj.AddForce(Vector3.forward * proj_speed, ForceMode.Impulse);
        }
        spawning = false;
    }
}
