﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;

    public float jumpSpeed;
    public float sideSpeed;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if(rb.velocity.x > 0)
                rb.velocity = new Vector2(sideSpeed, jumpSpeed);
            else
                rb.velocity = new Vector2(-sideSpeed, jumpSpeed);
        }
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Wall"))
        {
            EffectManager.instance.CreateHitWallAnimation(gameObject.transform.position);
        }
    }
}