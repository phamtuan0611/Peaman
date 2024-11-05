using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float minX = 0, maxX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 pst = transform.position;
            pst.x = player.position.x;
            if (pst.x < minX) pst.x = minX;
            if (pst.x > maxX) pst.x = maxX;
        
            pst.y = player.position.y;
            if (pst.y < minX) pst.y = minX;
            transform.position = pst;
        }
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
