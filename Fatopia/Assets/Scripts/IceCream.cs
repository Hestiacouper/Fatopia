using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCream : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    
    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<PlayerController>().PlayerAddFat();
        Destroy(gameObject);
    }
}
