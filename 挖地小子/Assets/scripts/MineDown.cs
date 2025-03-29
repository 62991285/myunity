using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ConstList;

public class MineDown : MonoBehaviour
{ public Sprite hollow;
    public Sprite[] block;
    public Transform player;
    public GameObject bomb_obj;
    private bool isminedown;
    public bool IsMineDown{ get { return isminedown; } set { isminedown = value; } }
    private Animator _anim;

    private void Start()
    {
        player = this.transform.parent;
        _anim = GetComponentInParent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        player.GetComponent<Player>().IsLanded = true;

        if (Input.GetKey(KeyCode.S) && (collision.transform.position.y < this.transform.position.y))
        {
            isminedown = true;
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
        else isminedown = false;
    }



    private void Update()
    {
        IsMineDown = isminedown;
        _anim.SetBool("isminedown", IsMineDown);
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        player.GetComponent<Player>().IsLanded = false; 
        //Debug.Log("fly");
    }


   

  



    private void clear(Collider2D collision)
    { collision.GetComponent<SpriteRenderer>().sprite = hollow;
        collision.tag = TAG.HOLLOW; 
        collision.GetComponent<Collider2D>().enabled = false;
    }


   

}
