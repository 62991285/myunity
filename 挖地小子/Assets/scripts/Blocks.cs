using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if(Input.GetKey(KeyCode.S) )Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.D)) Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.A)) Destroy(gameObject);
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
