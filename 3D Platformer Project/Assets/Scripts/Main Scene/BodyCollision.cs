using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{
    [SerializeField] private ThirdPersonController _controller;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        _controller.CollisionDetected(collision);
    }
    /*private void OnTriggerEnter(Collider other)
    {
        _controller.CollisionDetected(other);
    }*/
}

