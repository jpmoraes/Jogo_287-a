using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enime : MonoBehaviour
{
    private bool Edireito;
    [SerializeField]
    private float speed;
    private Animator animator;
    public float distance;
    private Transform positionPlayer;
    private bool isLive;
    private SpriteRenderer dir_fala;
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Edireito = true;
        positionPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        isLive = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        ///Mover();

        if (Vector2.Distance(transform.position, positionPlayer.position) <= distance && isLive)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("attack", true);

        }
        else if (isLive)
        {
            Mover();
            animator.SetBool("attack", false);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Death", true);
            animator.SetBool("Walk", false);
            Invoke("DestroyObject", 1f);
            
        }

        

    }

    private void Mover()
    {

        transform.Translate(PegarDirecao() * (speed * Time.deltaTime));
        animator.SetBool("Walk", true);
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        dir_fala = GameObject.FindGameObjectWithTag("fala").GetComponent<SpriteRenderer>();

        if (collison.tag == "Limit")
        {
            dir_fala.flipX = Edireito;
            MudarDirecao();            

        }

        if (collison.tag == "Power")
        {
            isLive = false;
        }
    }

    private void MudarDirecao()
    {
        Edireito = !Edireito;
                
        this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        

    }


    private Vector2 PegarDirecao()
    {
        return Edireito ? Vector2.right : Vector2.left;
    }

   
    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    
}