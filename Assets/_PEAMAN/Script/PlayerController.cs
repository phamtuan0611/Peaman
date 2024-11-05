using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isOnGround;

    [SerializeField] private bool gameOver = false;

    [SerializeField] private bool doubleJump;

    [SerializeField] private Animator player;

    [SerializeField] private float jumpForce;

    [SerializeField] private float doubleJumpForce;

    [SerializeField] private Rigidbody2D rg2D;

    [SerializeField] private float speed = 5f;

    // [SerializeField] private float speedBullet = 5f;

    [SerializeField] private SpriteRenderer sprite;

    //[SerializeField] private CapsuleCollider2D cc2D;

    [SerializeField] private float speedUp;

    void Update()
    {
        // Di chuyen
        float moveHorizontal = Input.GetAxis("Horizontal");
        rg2D.velocity = new Vector2(moveHorizontal * speed, rg2D.velocity.y);
        //float vt = transform.position.y;        
        if (isOnGround == false)
        {
            player.Play("Jump");
        }
        else if (moveHorizontal != 0)
        {
            player.Play("Walk");
        }
        else
        {
            player.Play("Idle");
        }

        // if (rg2D.velocity.y < -0.1f)
        // {
        //     // player.Play("Fall");
        //     // Debug.Log(sprite.sprite);
        //     PoolingManager.Instance.GetObject(NamePrefabPool.SmokeJump, position: transform.position);
        // }
        if (moveHorizontal < 0)
        {
            sprite.flipX = false;
        }

        if (moveHorizontal > 0)
        {
            sprite.flipX = true;
        }

        // Nhay
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && !gameOver)
        {
            rg2D.velocity = Vector2.up * jumpForce;
            isOnGround = false;
            doubleJump = false;
            PoolingManager.Instance.GetObject(NamePrefabPool.SmokeJump, position: transform.position);
        }
        // Doan ben duoi nay la cua double jump
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !isOnGround && !doubleJump)
        {
            doubleJump = true;
            rg2D.velocity = Vector2.up * doubleJumpForce;
            PoolingManager.Instance.GetObject(NamePrefabPool.SmokeJump, position: transform.position);
        }

        // Ban Dan peanut
        // if (Input.GetKeyDown(KeyCode.Z))
        // {
        //     var bullet =
        //         (Bullet) PoolingManager.Instance.GetObject(NamePrefabPool.Bullet, position: transform.position);
        //     bullet.rg2D.velocity = Vector2.right * speedBullet;
        //     // bullet.rg2D.velocity = new Vector2(speedBullet, bullet.rg2D.velocity.y);
        //     //bullet.Disable(3f);
        //     Debug.Log("124");
        // }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            UnderGround.iOGDown();
        }
        if (other.gameObject.CompareTag($"GroundDown"))
        {
            isOnGround = true;
        }
        if (other.gameObject.CompareTag("Peanut") || other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Spring"))
        {
            UnderGround.iOGDown();
            isOnGround = true;
            rg2D.velocity = Vector2.up * speedUp;
            player.Play("Jump");
        }

        // if (other.gameObject.CompareTag("Monster") &&
        //     (other.contacts[0].normal.x > 0 || other.contacts[0].normal.x < 0))
        // {
        //     Destroy(gameObject);
        // }
        if (other.gameObject.CompareTag("Finish"))
        {
            player.Play("Roll");
            Debug.Log("11111111");
        }
        // -7, -2.0005
    }
}