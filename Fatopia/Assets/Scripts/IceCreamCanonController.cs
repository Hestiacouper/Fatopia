using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IceCreamCanonController : MonoBehaviour
{
    [SerializeField] Transform target;
    private int correctionAngle = 90;
    [SerializeField] Transform firePoint;
    [SerializeField] float detectionDistance;
    [SerializeField] GameObject iceCreamPrefab;
    private float shootTime = 2.0f;
    private float nextShoot = 0.0f;
    private AudioSource audioSource;

    void start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) < detectionDistance)
        {
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //If the correction isn't there the rotation goes off. 
            Quaternion rotation = Quaternion.AngleAxis(angle + correctionAngle, Vector3.forward);
            transform.rotation = rotation;

            if (Time.time > nextShoot )
            { 
                nextShoot = Time.time + shootTime; 
                Shoot();
            }

        }
    }

    void Shoot()
    {
        //audioSource.Play();
        Instantiate(iceCreamPrefab, firePoint.position, firePoint.rotation);
    }
  
}
