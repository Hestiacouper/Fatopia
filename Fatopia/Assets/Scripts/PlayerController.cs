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
    float timerStopJump = 0;
    bool canJump = true;
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
        if (playerFatValue <= arrayfatSpeed.Length - 1)
        {
            speed = arrayfatSpeed[playerFatValue];
        }

        if (playerFatValue <= arrayJumpHeight.Length - 1)
        {
            jumpHeight = arrayJumpHeight[playerFatValue];
        }

        if (playerFatValue <= arrayspriteChads.Length-1)
        {
            this.GetComponent<SpriteRenderer>().sprite = arrayspriteChads[playerFatValue];
        }
        
        playerFatValue += 1;
    }
}


