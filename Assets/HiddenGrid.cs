using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;

public class HiddenGrid : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    private void OnTriggerEnter2D(Collider2D other)
    {
        tilemap.Fade(0, 0.75f);
        Debug.Log("12345677");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        tilemap.Fade(1, 0.75f);
    }
    // IEnumerator fade()
    // {
    //     var cl = tilemap.color.a;
    //     while (true)
    //     {
    //         cl -= Time.deltaTime;
    //         tilemap.color = new Color(1, 1, 1, cl);
    //         yield return null;
    //     }
    // }
}