using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_game : MonoBehaviour
{
    public string nomeScene;
    public int cli;
    private SpriteRenderer order;
    // Start is called before the first frame update
    void Start()
    {
        cli = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (cli)
        {
            case 1:
                order = GameObject.FindGameObjectWithTag("int1").GetComponent<SpriteRenderer>();
                order.sortingOrder = -1;
                break;

            case 2:
                order = GameObject.FindGameObjectWithTag("int2").GetComponent<SpriteRenderer>();
                order.sortingOrder = -2;
                break;

            case 3:
                changeS();
                break;

        }
        

    }
        

    public void changeS()
    {
        SceneManager.LoadScene(nomeScene);

    }

    public void Click()
    {
        cli += 1;

    }

}
