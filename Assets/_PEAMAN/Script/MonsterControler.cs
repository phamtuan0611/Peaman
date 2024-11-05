using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControler : MonoBehaviour
{
    [SerializeField] protected Animator anim;
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float moveDistance = 5f;
    [SerializeField] protected bool moveRight = true;

    [SerializeField] protected MonsterFather mf;
    [SerializeField] protected BoxCollider2D bc2D;
    protected virtual void Start()
    {
        StartCoroutine(move());
    }

    protected virtual void ChangeDirection()
    {
        // Đảo ngược hướng di chuyển
        moveRight = !moveRight;

        // Đảo ngược hướng đối tượng (nếu cần)!
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    protected virtual IEnumerator move()
    {
        while (true)
        {
            if (moveRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                anim.Play("walk");
            }
            else
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                anim.Play("walk");
            }

            float ts = mf.transform.position.x;
            if (transform.position.x >= (ts + moveDistance) && moveRight)
            {
                anim.Play("idle");
                yield return new WaitForSeconds(1.0f);
                ChangeDirection();
            }
            else if (transform.position.x <= (ts - moveDistance) && !moveRight)
            {
                anim.Play("idle");
                yield return new WaitForSeconds(1.0f);
                ChangeDirection();
            }

            yield return null;
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player") && other.contacts[0].normal.y < 0)
        {
            var transformPosition = gameObject.transform.position;
            transformPosition.z = 1;
            bc2D.enabled = false;
            anim.Play("death");
            gameObject.SetActive(false);
        }
    }
}