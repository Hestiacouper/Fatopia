using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    private Rigidbody2D body;
    Vector2 direction;
    [SerializeField]
    private float speed = 4;
    [SerializeField] float timeStopJump = 0.1f;
    private float timerStopJump = 0;
    private bool canJump = true;
    private int playerFatValue = 0;
    private bool bulldozer;
    [SerializeField] float jumpHeight;
    [SerializeField] float[] arrayJumpHeight;
    [SerializeField] float[] arrayfatSpeed;
    [SerializeField] Sprite[] arrayspriteChads;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {
        
        body.velocity = direction;
    }
    void Update() {
        
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        timerStopJump -= Time.deltaTime;
        
        if (Input.GetAxis("Jump") > 0.1f && canJump)
        {
            direction.y += jumpHeight;
            canJump = false;
            timerStopJump = timeStopJump;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (timerStopJump <= 0)
        {
            canJump = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        canJump = false;
    }
    public void PlayerAddFat()
    {
 
        speed = arrayfatSpeed[playerFatValue];
        jumpHeight = arrayJumpHeight[playerFatValue];
        GetComponent<SpriteRenderer>().sprite = arrayspriteChads[playerFatValue];
        
        if (playerFatValue < 4)
        {
            playerFatValue += 1;
        } 
    }
}


