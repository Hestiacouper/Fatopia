using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaDiet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<PlayerController>().PlayerAddFat();
        Destroy(gameObject);
    }
    
}
