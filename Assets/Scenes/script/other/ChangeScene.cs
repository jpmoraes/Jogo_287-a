using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nomeScene;
   
    public void changeS()
    {
        SceneManager.LoadScene(nomeScene);

    }

    public void quitJogo()
    {
        Application.Quit();

    }
}
