using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class BlRewardManager : MonoBehaviour // Peaman.Scripts.Block voi block tu tao
{
    [SerializeField] private SpriteRenderer gift;

    [SerializeField] private Sprite giftEmpty;

    //[SerializeField] private float speedBlt = 5f;
    
    //[SerializeField] private List<NamePrefabPool> listBP;

    // protected void Check()
    // {
    //     gift.sprite = giftEmpty;
    // }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player") && other.contacts[0].normal.y > 0)
        {
            gift.sprite = giftEmpty;
            // for (int i = 0; i < listBP.Count; i++)
            // {
            //     var peanut =
            //         (Bullet) PoolingManager.Instance.GetObject(NamePrefabPool.listBP[i], position: transform.position);
            //     peanut.rg2D.velocity = Vector2.up * speedBlt;
            // }
            
            // var peanut =
            //     (Bullet) PoolingManager.Instance.GetObject(NamePrefabPool.Peanut, position: transform.position);
            // peanut.rg2D.velocity = Vector2.up * speedBlt;
        }
    }
}