using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance;

    Rigidbody2D rb;

    public float jumpSpeed;
    public float sideSpeed;

    bool isAlive;

	void Awake () {
        if(instance == null)
        {
            instance = this;
        }
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
	}
	
	
	void Update () {
        if (!isAlive) return;

        if (Input.GetMouseButtonDown(0))
        {
            if(rb.velocity.x > 0)
                rb.velocity = new Vector2(sideSpeed, jumpSpeed);
            else
                rb.velocity = new Vector2(-sideSpeed, jumpSpeed);
        }
	}

    public void resetPosition()
    {
        isAlive = true;
        gameObject.transform.position = new Vector3(0, 2.5f, 0);
        rb.isKinematic = false;
        gameObject.SetActive(true);
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            EffectManager.instance.CreateHitWallAnimation(transform.position);
        }
        else if (collision.gameObject.CompareTag("Spike"))
        {
            EffectManager.instance.CreateDeadAnimation(transform.position);

            isAlive = false;
            rb.isKinematic = true;
            rb.velocity = new Vector2(0, 0);
            gameObject.SetActive(false);

            EffectManager.instance.CameraShakeAnimation();

            GameManager.instance.endGame();
        }
    }

    
}
