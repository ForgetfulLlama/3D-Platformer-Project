using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    protected bool is_active = true;
    [SerializeField] private GameObject proj_prefab;
    private GameObject projectile;
    [SerializeField] private GameObject cannon_body;
    [SerializeField] private float spawn_delay;
    [SerializeField] private float proj_speed = 20.0f;
    [SerializeField] private float startup_delay = 0.0f;
    private bool first_time = true;
    // Start is called before the first frame update
    void Start()
    {
        projectile = (GameObject)Instantiate(proj_prefab);
        projectile.transform.parent = transform;
        Physics.IgnoreCollision(cannon_body.GetComponent<Collider>(), 
            projectile.GetComponent<Collider>());
        projectile.GetComponent<MoveForward>().speed = proj_speed;
        projectile.SetActive(false);
        StartCoroutine(SpawnProjectile());
    }

    protected IEnumerator SpawnProjectile()
    {
        if (first_time) { yield return new WaitForSeconds(startup_delay); first_time = false; }
        else { yield return new WaitForSeconds(spawn_delay);}
        
        if (projectile != null)
        {
            projectile.SetActive(true);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.parent.transform.rotation;
            //Rigidbody proj = projectile.GetComponent<Rigidbody>();
            //proj.velocity = Vector3.zero;
            //proj.angularVelocity = Vector3.zero;
            //Vector3 launch_angle = new Vector3(0, 0, 1);
            //proj.AddRelativeForce(Vector3.forward * proj_speed, ForceMode.Impulse);
            //projectile.transform.Translate(Vector3.forward * proj_speed * Time.deltaTime);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            if (is_active)
            {
                other.gameObject.SetActive(false);
                StartCoroutine(SpawnProjectile());
            }
        }
    }
}
