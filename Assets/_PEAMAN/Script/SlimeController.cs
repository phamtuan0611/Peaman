using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonsterControler
{
    [SerializeField] private SpriteRenderer sr;
    protected override void Start()
    {
    }

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        float ts = mf.transform.position.x;
        if (transform.position.x >= (ts + moveDistance) && moveRight)
        {
            moveRight = !moveRight;
            sr.flipX = false;
        }
        else if (transform.position.x <= (ts - moveDistance) && !moveRight)
        {
            moveRight = !moveRight;
            sr.flipX = true;
        }
    }
}
