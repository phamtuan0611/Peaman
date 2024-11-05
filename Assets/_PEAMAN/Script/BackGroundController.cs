using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private float length, startpos, startpos2;

    public GameObject cam;

    public float speed, speedh;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        startpos2 = transform.position.y;
        length = GetComponent<SpriteRenderer>().size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - speed));
        float dist = (cam.transform.position.x * speed);
        float temph = cam.transform.position.y;

        transform.position = new Vector3(startpos + dist, startpos2 + temph, transform.position.z);

        if (temp >= startpos + length) startpos += length;
        else if (temp <= startpos - length) startpos -= length;
    }
}