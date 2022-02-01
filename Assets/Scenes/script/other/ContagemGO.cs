using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContagemGO : MonoBehaviour
{
    Text desc;
    private int seg;
    void Start()
    {
        desc = GetComponent<Text>();
        StartCoroutine("cronometro");
        seg = 3;
    }

    // Update is called once per frame
    IEnumerator cronometro()
    {

        yield return new WaitForSeconds(1f);
        seg -= 1;
        switch (seg)
        {
            case 0:
                SceneManager.LoadScene("Menu");
                break;
            case 1:
                desc.text = "1";
                break;
            case 2:
                desc.text = "2";
                break;
            case 3:
                desc.text = "3";
                break;

        }

        StartCoroutine("cronometro");
    }
}
