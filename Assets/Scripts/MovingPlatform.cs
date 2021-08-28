using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform navStartPoint;
    public Transform navEndPoint;
    public float speed;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 currentPlatformPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = navStartPoint.position;
        endPoint = navEndPoint.position;
        Destroy(navStartPoint.gameObject);
        Destroy(navEndPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        currentPlatformPosition =  Vector2.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
        transform.position = currentPlatformPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = gameObject.transform;
            other.attachedRigidbody.Sleep();
        }    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
