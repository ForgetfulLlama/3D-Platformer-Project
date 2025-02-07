using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TranslatePlatform : MonoBehaviour
{
    private float startPoint;
    private Vector3 og_pos;
    private Vector3 end_pos;
    [SerializeField] private float moveRange;
    [SerializeField] private float speed;
    private float endpoint;
    public string axis;
    public float wait_time = 0;
    
    private bool platform_paused;
    // Start is called before the first frame update
    void Start()
    {
        og_pos = transform.position;
        end_pos = og_pos;
        switch (axis)
        {
            case "x":
                startPoint = transform.position.x;
                end_pos.x += moveRange;
                break;
            case "y":
                startPoint = transform.position.y;
                end_pos.y += moveRange;
                break;
            case "z":
                startPoint = transform.position.z;
                end_pos.z += moveRange;
                break;
            case "xy":
                startPoint = transform.position.x;
                end_pos.x += moveRange;
                end_pos.y += moveRange;
                break;
            case "yz":
                startPoint = transform.position.y;
                end_pos.y += moveRange;
                end_pos.z += moveRange;
                break;
            case "xz":
                startPoint = transform.position.z;
                end_pos.x += moveRange;
                end_pos.z += moveRange;
                break;
            default:
                break;
        }
        endpoint = startPoint + moveRange;
        if (startPoint > endpoint)
        {
            endpoint = startPoint;
            startPoint = endpoint + moveRange;
            Vector3 tmp = og_pos;
            og_pos = end_pos;
            end_pos = tmp;
            speed *= -1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!platform_paused)
        {
            MovePlatform();
        }
    }
   
    
    private void MovePlatform()
    {
        Vector3 direction = Vector3.zero;
        float currPos = 0f;
        switch (axis)
        {
            case "x":
                direction = Vector3.right;
                currPos = transform.position.x;
                break;
            case "y":
                direction = Vector3.up;
                currPos = transform.position.y;
                break;
            case "z":
                direction = Vector3.forward;
                currPos = transform.position.z;
                break;
            case "xy":
                direction = new Vector3(1f, 1f, 0f);
                currPos = transform.position.x;
                break;
            case "yz":
                direction = new Vector3(0f, 1f, 1f);
                currPos = transform.position.y;
                break;
            case "xz":
                direction = new Vector3(1f, 0f, 1f);
                currPos = transform.position.z;
                break;
            default:
                break;
        }
        if (currPos > endpoint)
        {
            transform.position = end_pos;
            //transform.position = CorrectPosition(axis, endpoint);
            FlipDirection();
        }
        else if (currPos < startPoint)
        {
            transform.position = og_pos;
            //transform.position = CorrectPosition(axis, startPoint);
            FlipDirection();
        }
        transform.Translate(direction * speed * Time.deltaTime);
    }
    
    private Vector3 CorrectPosition(string axis, float fixedPos)
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        float zPos = transform.position.z;
        switch (axis)
        {
            case "x":
                return new Vector3(fixedPos, yPos, zPos);
            case "y":
                return new Vector3(xPos, fixedPos, zPos);
            case "z":
                return new Vector3(xPos, yPos, fixedPos);
            case "xy":
                return new Vector3(fixedPos, yPos, zPos);
            case "yz":
                return new Vector3(xPos, fixedPos, zPos);
            case "xz":
                return new Vector3(xPos, yPos, fixedPos);
            default:
                return Vector3.zero;
        }
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
