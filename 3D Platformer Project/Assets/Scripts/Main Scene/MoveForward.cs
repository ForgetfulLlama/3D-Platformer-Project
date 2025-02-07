using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyForce();
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void ApplyForce()
    {
        Rigidbody car = transform.GetComponent<Rigidbody>();
        car.velocity = Vector3.zero;
        car.angularVelocity = Vector3.zero;
        //Vector3 launch_angle = new Vector3(0, 0, 1);
        car.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }
}
