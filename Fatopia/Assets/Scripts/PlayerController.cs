using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] float[] arrayFatSpeed;
    [SerializeField] Sprite[] arraySpriteChads;
    [SerializeField] int arraySizes;
    private int dumbells = 0;

    [SerializeField] Canvas menuManagerCanvas;
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
            //direction.y += jumpHeight;
            direction = Vector2.up * jumpHeight;
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
   
        Debug.Log(playerFatValue);
        speed = arrayFatSpeed[playerFatValue];
        jumpHeight = arrayJumpHeight[playerFatValue];
        GetComponent<SpriteRenderer>().sprite = arraySpriteChads[playerFatValue];
  
        if (playerFatValue < arraySizes)
        {
            playerFatValue += 1;
        }
    }
    public void PickUpDumbells()
    {
        dumbells += 1;
    }
    public int getPlayerDumbells()
    {
        return dumbells;
    }
}


