using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaDiet : MonoBehaviour
{
    private AudioSource audioSource;
    private SpriteRenderer renderer;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play(0);
            other.GetComponent<PlayerController>().PlayerAddFat();
            renderer.enabled = false;
            Destroy(gameObject, audioSource.clip.length);
        }
    }
    
}
