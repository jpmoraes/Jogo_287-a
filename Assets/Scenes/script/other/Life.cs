using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{

    Text desc; 
    // Start is called before the first frame update
    void Start()
    {
        desc = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController life = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        switch (life.getLife())
        {
            case 0:
                SceneManager.LoadScene("GameOver");
                break;
            case 1:
                desc.text = "1";
                break;
            case 2:
                desc.text = "2";
                break;

        }
    }
}
