using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    //[SerializeField] private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player") && other.contacts[0].normal.y > 0)
        {
            Destroy(gameObject);
            PoolingManager.Instance.GetObject(NamePrefabPool.Coin, position: transform.position);
            //PoolingManager.Instance.GetObject(NamePrefabPool.Coin, position: transform.position * Vector2.up * speed);
            // Check();
        }
    }
    
    /*
    private virtual void Check()
    {
        
    }
     */
    /*
     private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player") && other.contacts[0].normal.y > 0)
        {
            Destroy(gameObject);
            VitriLucDau = transform.position;
            KhoiNayLen();
        }
    }
    void KhoiNayLen()
    {
        if (DuocNay)
        {
            StartCoroutine(KhoiNay());
            DuocNay = false;
        }
    }
    IEnumerator KhoiNay()
    {
        while(true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + ToDoNay * Time.deltaTime);
            if (transform.localPosition.y >= ViTriLucDau.y + DoNayCuaKhoi) break;
            yield return null;
        }
        while(true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - ToDoNay * Time.deltaTime);
            if (transform.localPosition.y <= ViTriLucDau.y) break;
            Destroy(gameObject);
            GameObject KhoiRong = (GameObject)Instantiate(Resources.Load("Prefabs/KhoiTrong"));
            KhoiRong.transform.position = ViTriLucDau;
            yield return null;
        }
    }
     */
}
