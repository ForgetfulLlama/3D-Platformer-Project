using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{
    [SerializeField] private ThirdPersonController _controller;

    private void OnTriggerEnter(Collider collision)
    {
        _controller.CollisionDetected(collision);
    }

}

