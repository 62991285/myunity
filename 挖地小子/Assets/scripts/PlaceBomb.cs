using ConstList;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceBomb : MonoBehaviour
{
    
      
        
        public GameObject bombPrefab;
        public float throwForce = 5f;
        public float explosionRadius = 3f;
        public LayerMask destructibleLayer;
        private bool islanded;
         public Sprite hollow;

    void Update()
    {
        islanded = GetComponentInParent<Player>().IsLanded;
    }

    private void Start()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F)&&collision.transform.position.y<this.transform.position.y&&islanded&&collision.tag==TAG.STONE)
        {
            StartCoroutine(Placebomb(collision.transform.position,collision));
        }
    }

    

    IEnumerator Placebomb(Vector3 position,Collider2D collider)
        {
            // 实例化炸弹
            GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
            bomb.GetComponent<SpriteRenderer>().sortingOrder = 1;
            // 3秒倒计时
            yield return new WaitForSeconds(1.9f);

            // 执行爆炸
            Explode(bomb.transform.position);

            // 销毁炸弹本体
            Destroy(bomb);
        collider.GetComponent<BoxCollider2D>().enabled = false;
        collider.GetComponent<SpriteRenderer>().sprite = hollow;
        collider.tag = TAG.HOLLOW;
        }

        void Explode(Vector3 center)
        {
            // 球形范围检测
            Collider[] hits = Physics.OverlapSphere(center, explosionRadius, destructibleLayer);

            foreach (Collider hit in hits)
            {
            // 销毁物体并清除碰撞
            Destroy(hit.gameObject);
            // 可选：如果希望保留物体但取消碰撞
            //hit.GetComponent<col>
        }

            
        }
    }


