using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private bool Ebaixo;
    [SerializeField]
    private float speed;
    private Animator animator;
    private Transform positionPlayer;
    public float distance;
    public int vida;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Ebaixo = true;
        positionPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        vida = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Mover();


        if (Vector2.Distance(transform.position, positionPlayer.position) <= distance)
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
            animator.SetBool("idle", true);
        }

        if (vida <= 0)
        {
            animator.SetBool("attack", false);
            animator.SetBool("idle", false);
            animator.SetBool("death", true);
            
            Invoke("DestroyObject", 1f);
        }

    }

    private void Mover()
    {

        transform.Translate(PegarDirecao() * (speed * Time.deltaTime));
        animator.SetBool("idle", true);

    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.tag == "Limit")
        {
            MudarDirecao();
        }

        if(collison.tag == "Power")
        {
            vida -= 1;
        }


    }

    private void MudarDirecao()
    {
        Ebaixo = !Ebaixo;

        this.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

    }


    private Vector2 PegarDirecao()
    {
        return Ebaixo ? Vector2.up : Vector2.down;
    }

    
    private void DestroyObject()
    {
        Destroy(gameObject);

    }
}