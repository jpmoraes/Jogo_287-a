using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class PlayerController : MonoBehaviour
{
    public Animator     Anim;
    public Rigidbody2D  PlayerRigidBody;
    public int          ForceJump;
    public bool         Jump;
    public float        Speed;

    public Transform GroundCheck;
    public bool Grounded;
    public LayerMask WhatIsGround;
    public int dir;
    public SpriteRenderer projetilsprite;
    public SpriteRenderer player;
    public const float velConst = 7f;
    public bool facing;
    private bool start;
    private float vel;
    public int life;
    public int point;
    SerialPort porta = new SerialPort("COM11", 9600);
    private int pulo;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        player = GetComponent<SpriteRenderer>();
        start = true;
        vel = velConst;
        life = 3;
        porta.Open();
        porta.ReadTimeout = 1;
        pulo = 0;
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (start == true) {
            Move();
            inputJump();
            print(point);
        }
        else
        {
            Vector3 nPosition = transform.position;
            nPosition.x = -3.17f;
            transform.position = nPosition;

            start = true;
            
        }
        if (porta.IsOpen)
        {
            try
            {                
                pulo = porta.ReadByte();
                Mover(porta.ReadByte());
               
            }
            catch (System.Exception)
            {
            }
        }

    }

    void Mover(int direcao)
    {
        print(direcao);

        
        if (direcao == 1)
        {
            transform.Translate(new Vector3(2 * vel * Time.deltaTime, 0, 0));
            player.flipX = false;
            facing = false;
            Anim.SetBool("run", true);
        }
        
        else if (direcao == 255)
        {
            transform.Translate(new Vector3(-2 * vel * Time.deltaTime, 0, 0));
            player.flipX = true;
            facing = true;
            Anim.SetBool("run", true);

        }
        else
        {
            Anim.SetBool("run", false);

        }

        dir = direcao;
    }

        void Move()
        {

            float T = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(T * vel * Time.deltaTime, 0, 0));
        
            if (T < 0)
            {
                player.flipX = true;
                facing = true;
            }
            if (T > 0)
            {
                player.flipX = false;
                facing = false;
            }


            if (Input.GetAxis("Horizontal") != 0)
            {
                Anim.SetBool("run", true);
            }
            else
            {
                Anim.SetBool("run", false);
            }

        }

    void inputJump()
    {
        
        if ((Input.GetButtonDown("Jump") && Grounded))
        {
            PlayerRigidBody.AddForce(new Vector2(0, ForceJump));
            Jump = true;
            pulo = 0;
        } else if (pulo == 2 && Grounded)
        {
            PlayerRigidBody.AddForce(new Vector2(0, 130));
            Jump = true;
            pulo = 0;

        }


        Grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, WhatIsGround);

        Anim.SetBool("jump", !Grounded);
        

    }

          
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Enime")
        {
            start = false;
            life -= 1;
        }

              
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        Point p = GameObject.FindWithTag("placa_error").GetComponent<Point>();

        if (collison.gameObject.tag == "LimitAtt" || collison.gameObject.tag == "caiu")
        {
            SceneManager.LoadScene("Fim");
        }

        if(collison.gameObject.tag == "placa_error")
        {
            
            point -= 10;

            p.DestuirPlaca();

        }

        if (collison.gameObject.tag == "placa_correct")
        {
            point += 10;
            p.DestuirPlaca();
        }


    }

    public int getLife()
    {
        return life;
    }

    public bool getFacing()
    {
        return facing;
    }

    public int getDirecao()
    {
        return dir;
    }

    public int getPoint()
    {
        return point;
    }
}
