using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailCactusCollider : MonoBehaviour
{
    public AudioClip clipDie;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "MainHero")
        {
            AudioSource.PlayClipAtPoint(clipDie, this.transform.position);
            other.gameObject.GetComponent<Animator>().SetTrigger("fail");
        }
    }
}
