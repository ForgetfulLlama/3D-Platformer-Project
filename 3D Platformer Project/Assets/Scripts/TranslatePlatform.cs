using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslatePlatform : MonoBehaviour
{
    [SerializeField] private float moveRange;
    [SerializeField] private float speed;
    public string movementAxis;
    public float wait_time = 0;
    private float startPoint;
    private bool platform_paused;
    // Start is called before the first frame update
    void Start()
    {
        switch (movementAxis)
        {
            case "x":
                startPoint = transform.position.x;
                break;
            case "y":
                startPoint = transform.position.y;
                break;
            case "z":
                startPoint = transform.position.z;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!platform_paused)
        {
            switch (movementAxis)
            {
                case "x":
                    TranslatePlatformX();
                    break;
                case "y":
                    TranslatePlatformY();
                    break;
                case "z":
                    TranslatePlatformZ();
                    break;
            }
        }
    }

    private void TranslatePlatformX()
    {
        if (transform.position.x > startPoint + moveRange)
        {
            transform.position = new Vector3(startPoint+moveRange, transform.position.y, transform.position.z);
            FlipDirection();
        }
        else if (transform.position.x < startPoint - moveRange)
        {
            transform.position = new Vector3(startPoint-moveRange, transform.position.y, transform.position.z);
            FlipDirection();
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void TranslatePlatformY()
    {
        if (transform.position.y > startPoint + moveRange)
        {
            transform.position = new Vector3(transform.position.x, startPoint + moveRange, transform.position.z);
            FlipDirection();
        }
        else if (transform.position.y < startPoint - moveRange)
        {
            transform.position = new Vector3(transform.position.x, startPoint - moveRange, transform.position.z);
            FlipDirection();
        }

        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void TranslatePlatformZ()
    {
        if (transform.position.z > startPoint + moveRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, startPoint + moveRange);
            FlipDirection();
        }
        else if(transform.position.z < startPoint - moveRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, startPoint - moveRange);
            FlipDirection();
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void FlipDirection()
    {
        speed *= -1;
        if (wait_time != 0)
        {
            StartCoroutine(DelayPlatform());
        }
    }

    private IEnumerator DelayPlatform()
    {
        platform_paused = true;
        float og_speed = speed;
        speed = 0;
        yield return new WaitForSeconds(wait_time);
        speed = og_speed;
        platform_paused = false;
    }

}
