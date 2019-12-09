using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IceCreamCanonController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform target;
    void Start()
    {
       
    }
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
        transform.rotation = rotation; // Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        //Debug.Log("Triggered");
    }
   /*private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation; // Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        Debug.Log("Triggered");
    }*/
}
