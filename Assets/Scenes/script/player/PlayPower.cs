using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class PlayPower : MonoBehaviour
{
    public Animator anim;
    private SpriteRenderer sprite;
    public float time = 5.0f;//tempo do temporizador
    float cTemp;
    public GameObject iniciar;
    public Transform player;
    public BoxCollider2D bc;
    public bool cond;
     
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim.SetBool("att", false);
        sprite.sortingOrder = -1;
        bc = GetComponent<BoxCollider2D>();
        cond = false;
               
    }


    void Update()
    {
        int pow = Ispow();

        if (Input.GetButtonDown("Fire1") ||  pow == 3)
        {
            bc.enabled = !cond;
            Mudar();
            //Instantiate(iniciar, new Vector2(player.position.x + 4.0f * Time.deltaTime, player.position.y), Quaternion.identity);            
            sprite.sortingOrder = 3;
            anim.SetBool("att", true);
            time = 0;
             //Invoke("DestroyObject", 1f);
             
        }
        else
        {
             
            Mudar();
            anim.SetBool("att", false);
            if (time < 0)
            {
                sprite.sortingOrder = -1;
                bc.enabled = false;
                
            }
            cTemp += 1 * Time.deltaTime;
            if (cTemp >= 1)
            {

                time -= 1;
                cTemp = 0;
            }
        }


    }
    
    void Mudar()
    {
        PlayerController fac = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if (fac.getFacing())
        {
            sprite.flipX = true;
            transform.position = new Vector3(player.position.x - 180.0f * Time.deltaTime, player.position.y, 0);
        }
        else
        {
            sprite.flipX = false;
            transform.position = new Vector3(player.position.x + 180.0f * Time.deltaTime, player.position.y, 0);
        }
    }

    public int Ispow()
    {
        PlayerController fac = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        
        return fac.getDirecao(); 

    }

}
