using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderGround : MonoBehaviour
{
    [SerializeField] private static bool isOnGroundDown = false;
    [SerializeField] private PlatformEffector2D pe2D;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && isOnGroundDown)
        {
            pe2D.rotationalOffset = 180;
        }

        if (!isOnGroundDown)
        {
            pe2D.rotationalOffset = 0;
        }
    }

    public static void iOGDown()
    {
        isOnGroundDown = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            isOnGroundDown = true;
        }
    }
}