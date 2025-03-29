using ConstList;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    
    public float speed=2;
    private Animator _anim;

    
    void Update()
    {
        this.transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
         
         if(collision.CompareTag(TAG.PLAYER) ){collision.GetComponent<Player>().Health-=10; collision.GetComponent<Animator>().SetTrigger("gettinghurt");}//‘Ï≥……À∫¶
        speed = -speed;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }





}
