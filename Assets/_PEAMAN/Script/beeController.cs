using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeController : MonsterControler
{
    // Start is called before the first frame update

    [SerializeField] private bool moveDown = true;

    protected override void ChangeDirection()
    {
        // Đảo ngược hướng di chuyển
        moveDown = !moveDown;
    }

    protected override IEnumerator move()
    {
        while (true)
        {
            if (moveDown)
            {
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
                anim.Play("fly");
            }
            else
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
                anim.Play("fly");
            }

            float ts = mf.transform.position.y;
            if (transform.position.y >= (ts + moveDistance) && !moveDown)
            {
                yield return new WaitForSeconds(1.0f);
                ChangeDirection();
            }
            else if (transform.position.y <= (ts - moveDistance) && moveDown)
            {
                yield return new WaitForSeconds(1.0f);
                ChangeDirection();
            }

            yield return null;
        }
    }
}