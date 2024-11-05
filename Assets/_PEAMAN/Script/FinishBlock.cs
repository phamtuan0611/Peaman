using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class FinishBlock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Debug.Log("2222222");
            PoolingManager.Instance.GetObject(NamePrefabPool.Fire, position: transform.position);
            // other.gameObject.SetActive(false);
        }
    }
}
