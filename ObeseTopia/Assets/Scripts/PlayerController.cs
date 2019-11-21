using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D body;
    
    Vector2 direction;
    [SerializeField] private Sprite chadLessFit;
    [SerializeField] private Sprite chadDadBod;
    [SerializeField] private Sprite chadFat;
    [SerializeField]
    private float speed = 4;
    [SerializeField] float timeStopJump = 0.1f;
    float timerStopJump = 0;
    bool canJump = true;
    private int playerFatValue = 1;
    private bool bulldozer;
    [SerializeField] private float jumpHeight;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate() {
        body.velocity = direction;
    }
    
    // Update is called once per frame
    void Update() {
        
    
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        timerStopJump -= Time.deltaTime;
        if (Input.GetAxis("Jump") > 0.1f && canJump)
        {
            //Debug.Log("You try to jump");
            direction.y += jumpHeight;
            canJump = false;
            timerStopJump = timeStopJump;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (timerStopJump <= 0)
        {
           // Debug.Log("You touch ground");
            canJump = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("You leave ground");
        canJump = false;
    }

    public void PlayerAddFat()
    {
        switch (playerFatValue)
        {
            case 1:
            {
                speed = 5;
                playerFatValue += 1;
                this.GetComponent<SpriteRenderer>().sprite = chadLessFit;
                break;
            }
            case 2:
            {
                speed = 3.5f;
                playerFatValue += 1;
                this.GetComponent<SpriteRenderer>().sprite = chadDadBod;
                break;
            }
            case 3:
            {
                speed = 2;
                playerFatValue += 1;
                this.GetComponent<SpriteRenderer>().sprite = chadFat;
                break;
            }
            case 4:
            {
                speed = 1;
                playerFatValue += 1;
                break;
            }
            case 5:
            {
                speed = 0.1f;
                playerFatValue += 1;
                break;
            }
            case 6:
            {
                bulldozer = true;
                break;
            }
        }
    }
}


