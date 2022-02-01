using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Text : MonoBehaviour
{
    public bool Interacao;
    public GameObject Imagem;
    // Start is called before the first frame update
    void Start()
    {
        Imagem.SetActive(false);
        Interacao = false;
    }

    // Update is called once per frame
    void Update()
    {
        ///Input.GetKeyDown(KeyCode.E)
        if (Interacao)
        {
            Imagem.SetActive(true);
        }
        else
        {
            Imagem.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Interacao = true;
        }
        
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Interacao = false;

        }
    }

}