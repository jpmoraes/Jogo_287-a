using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBau : MonoBehaviour
{
    public bool Interacao;
    private Animator animator;
    public GameObject Imagem;
    // Start is called before the first frame update
    void Start()
    {
        Imagem.SetActive(false);
        animator = GetComponent<Animator>();
        Interacao = false;
    }

    // Update is called once per frame
    void Update()
    {
        ///Input.GetKeyDown(KeyCode.E)
        if ( Interacao)
        {
            animator.SetBool("Aberto", true);
            Imagem.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Interacao = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Interacao = false;
        }
    }
}
