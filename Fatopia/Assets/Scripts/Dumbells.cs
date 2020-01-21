using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Dumbells : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().PickUpDumbells();
        }
    }
}
