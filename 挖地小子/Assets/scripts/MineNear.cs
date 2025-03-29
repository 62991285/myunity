using ConstList;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MineNear : MonoBehaviour
{
    public Sprite hollow;
    public Sprite[] block;
    private bool ismineleft;
    private bool ismineright;
    private Animator _anim;

    public Transform Parent;
    private bool islanded;

    private void Start()
    {
        _anim = GetComponentInParent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {


        if ((Input.GetKey(KeyCode.D) && (collision.transform.position.x > this.transform.position.x)) && islanded ||
            (Input.GetKey(KeyCode.A) && (collision.transform.position.x < this.transform.position.x) && islanded))
        {
            switch (collision.tag)
            {
                case TAG.BLOCK: { collision.GetComponent<SpriteRenderer>().sprite = block[0]; collision.tag = TAG.BREAK0; break; }
                case TAG.BREAK0: { collision.GetComponent<SpriteRenderer>().sprite = block[1]; collision.tag = TAG.BREAK1; break; }
                case TAG.BREAK1: { collision.GetComponent<SpriteRenderer>().sprite = block[2]; collision.tag = TAG.BREAK2; break; }
                case TAG.BREAK2: { collision.GetComponent<SpriteRenderer>().sprite = block[3]; collision.tag = TAG.BREAK3; break; }
                case TAG.BREAK3: { collision.GetComponent<SpriteRenderer>().sprite = block[4]; collision.tag = TAG.BREAK4; break; }
                case TAG.BREAK4: { collision.GetComponent<SpriteRenderer>().sprite = block[5]; collision.tag = TAG.BREAK5; break; }
                case TAG.BREAK5: { collision.GetComponent<SpriteRenderer>().sprite = block[6]; collision.tag = TAG.BREAK6; break; }
                case TAG.BREAK6: { collision.GetComponent<SpriteRenderer>().sprite = hollow; collision.tag = TAG.HOLLOW; collision.GetComponent<Collider2D>().enabled = false; break; }
                case TAG.COAL: { this.transform.parent.gameObject.GetComponent<Player>().coal++; clear(collision); Debug.Log("coal+1"); break; }
                case TAG.COPPER: { this.transform.parent.gameObject.GetComponent<Player>().copper++; clear(collision); break; }
                case TAG.IRON: { this.transform.parent.gameObject.GetComponent<Player>().iron++; clear(collision); break; }
                case TAG.GOLD: { this.transform.parent.gameObject.GetComponent<Player>().gold++; clear(collision); break; }
                case TAG.CRYSTAL: { this.transform.parent.gameObject.GetComponent<Player>().crystal++; clear(collision); break; }
                case TAG.GREEN_GEM: { this.transform.parent.gameObject.GetComponent<Player>().green_gem++; clear(collision); break; }
                case TAG.ORENGE_GEM: { this.transform.parent.gameObject.GetComponent<Player>().orenge_gem++; clear(collision); break; }
                case TAG.PURPLE_GEM: { this.transform.parent.gameObject.GetComponent<Player>().purple_gem++; clear(collision); break; }
                case TAG.DIAMOND: { this.transform.parent.gameObject.GetComponent<Player>().diamond++; clear(collision); break; }
                default: break;
            }
        }

        if (Input.GetKey(KeyCode.A)) { ismineleft = true; } 
        if (Input.GetKey(KeyCode.D)) { ismineright = true; } 

    }

    private void Update()
    {
        islanded = GetComponentInParent<Player>().IsLanded;
        _anim.SetBool("ismineright", ismineright);
        _anim.SetBool("ismineleft", ismineleft);
        if (Input.GetKeyUp(KeyCode.A)) ismineleft = false;
        if (Input.GetKeyUp(KeyCode.D)) ismineright = false;

    }
    private void clear(Collider2D collision)
    {
        collision.GetComponent<SpriteRenderer>().sprite = hollow;
        collision.tag = TAG.HOLLOW;
        collision.GetComponent<Collider2D>().enabled = false;
    }


}
