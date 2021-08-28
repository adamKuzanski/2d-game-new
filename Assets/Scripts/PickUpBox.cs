using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{
    public AudioClip clipCollect;

    private CounterController counterController;


    // Start is called before the first frame update
    void Start()
    {
        counterController = GameObject.Find("Manager").GetComponent<CounterController>();
        if (counterController == null)
        {
            Debug.LogError("CounterController not found");
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.name == "MainHero")
        {
            AudioSource.PlayClipAtPoint(clipCollect, transform.position);
            counterController.IncrementCounter();
            Destroy(this.gameObject);
        }

    }
}
