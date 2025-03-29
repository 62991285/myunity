using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstList;
using Unity.VisualScripting;
public class Player : MonoBehaviour
{
    private float _horizontalSpeed;
    private float _verticalSpeed;
    public float maxHorizontalSpeed=10;
    public float maxVerticalSpeed = 40;
    public float force = 10f;
    private Animator _anim;

    private int health = 100;
    private int oxygen = 100;
    private int score = 0;
    public bool keyboard;

    public int coal = 0;
    public int gold = 0;
    public int copper = 0;
    public int iron = 0;
    public int crystal = 0;
    public int green_gem = 0;
    public int purple_gem = 0;
    public int orenge_gem = 0;
    public int diamond = 0;





    public int bomb = 10;
    public int superbomb = 10;
    public int superbomb_pro = 10;


    private bool islanded;
    private bool ismoveright;
    private bool ismoveleft;
    

    public bool IsLanded { set { islanded = value; } get => islanded; }
    
    public int Health { get => health; set => health = value; }
    public bool IsMoveRight { get => ismoveright; set => ismoveright = value; }
    public bool Ismoveleft { get => ismoveleft; set => ismoveleft = value; }
    //public int Score { get => score; set => score = value; }

    public void GetHurt(int damage)
    {
        health -= damage;
        _anim.SetTrigger("gettinghurt");
    }

    

    private void OnGUI()
    {
        GUI.TextField(new Rect(0, 50, 100, 30), "coal"+coal.ToString());
        GUI.TextField(new Rect(0, 90, 100, 30), "gold" + gold.ToString());
        GUI.TextField(new Rect(0, 130, 100, 30), "iron" + iron.ToString());
        GUI.TextField(new Rect(0, 170, 100, 30), "copper" + copper.ToString());
        GUI.TextField(new Rect(0, 210, 100, 30), "crystal" + crystal.ToString());
        GUI.TextField(new Rect(0, 250, 100, 30), "green gem" + green_gem.ToString());
        GUI.TextField(new Rect(0, 290, 100, 30), "purple gem" + purple_gem.ToString());
        GUI.TextField(new Rect(0, 330, 100, 30), "orange gem" + orenge_gem.ToString());
        GUI.TextField(new Rect(0, 370, 100, 30), "diamond" + diamond.ToString());
        GUI.TextField(new Rect(100, 0, 100, 30), "oxygen" + oxygen.ToString());
        GUI.TextField(new Rect(200, 0, 100, 30), "health" + health.ToString());

    }
    void Start()
    {
        Application.targetFrameRate = 60;
        _horizontalSpeed = 0;
        _verticalSpeed = 0;
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(keyboard) Move();
        //if(Input.GetMouseButtonDown(0))GetComponent
        if (transform.position.y < 0&&IsInvoking("consumeoxygen")==false) InvokeRepeating("consumeoxygen", 0, 3);
        else if(transform.position.y>0) CancelInvoke("consumeoxygen");
        if (health <= 0) ;
        _anim.SetBool("ismoveright", IsMoveRight);
        _anim.SetBool("ismoveleft", Ismoveleft);

        if (Health <= 0)
        {
            _anim.SetTrigger("dying");
            Invoke("Die", 2); 

        }
    }

    private void consumeoxygen() => oxygen -= 1;
    
    private void Die()
    {
        keyboard = false;
    }
    private void Move()
    {

        _anim.SetFloat("velocity", _horizontalSpeed);
        _anim.SetBool("islanded", IsLanded);



        if (Input.GetKey(KeyCode.D))
        {
            IsMoveRight = true;
            if (_horizontalSpeed < maxHorizontalSpeed) _horizontalSpeed += force * Time.deltaTime;
            this.transform.Translate(Vector3.right * _horizontalSpeed * Time.deltaTime);
        }
        else IsMoveRight = false;

        if (Input.GetKeyUp(KeyCode.D)) _horizontalSpeed = 0;

        if (Input.GetKey(KeyCode.A))
        {
            Ismoveleft = true;
            if (_horizontalSpeed > -maxHorizontalSpeed) _horizontalSpeed -= force * Time.deltaTime;
            this.transform.Translate(Vector3.right * _horizontalSpeed * Time.deltaTime);
        }
        else Ismoveleft = false;

        if (Input.GetKeyUp(KeyCode.A)) _horizontalSpeed = 0;



        if (Input.GetKey(KeyCode.W) && _verticalSpeed < maxVerticalSpeed)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            _verticalSpeed += force * Time.deltaTime;
            this.transform.Translate(Vector3.up * _verticalSpeed * Time.deltaTime, Space.World);


        }



        if (Input.GetKeyUp(KeyCode.W))
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 1;
            _verticalSpeed = 0;
        }

    }

    



}
