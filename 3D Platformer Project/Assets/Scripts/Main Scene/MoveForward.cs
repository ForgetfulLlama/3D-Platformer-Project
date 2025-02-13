using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        ApplyForce();
    }

    private void ApplyForce()
    {
        Rigidbody car = transform.GetComponent<Rigidbody>();
        car.velocity = Vector3.zero;
        car.angularVelocity = Vector3.zero;
        car.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }
}
