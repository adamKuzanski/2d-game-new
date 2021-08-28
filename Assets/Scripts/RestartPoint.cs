using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPoint : MonoBehaviour
{
    RestartPointsManager restartPointsManager;
    SpriteRenderer spriteRenderer;
    public AudioClip clipRestart;

    // Start is called before the first frame update
    void Start()
    {
        restartPointsManager = GameObject.Find("Manager").GetComponent<RestartPointsManager>();
        if(restartPointsManager == null)
        {
            Debug.LogError("RestartsPointManager not found");
        }

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(clipRestart, this.transform.position, 1f);
            restartPointsManager.UpdateStartPoint(this.gameObject.transform);
            spriteRenderer.color = new Color(0.3f, 0.6f, 0.6f);
        }

    }
}
