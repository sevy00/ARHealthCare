using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Cambiascena : MonoBehaviour
{
    /// <summary>
    /// Scene nella build
    /// </summary>
    enum sceneIndices {
        Applicativo = 2,
        ARScene = 1,
        MainScene = 0
    }

    /// <summary>
    /// Carica la scena AR
    /// </summary>
    public void GestisciClick()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        //Debug.Log("Sei uscito credici.");
        Application.Quit();
    }

    /// <summary>
    /// Carica la scena Main
    /// </summary>
    public void LogoutMedico()
    {
        SceneManager.LoadScene(0);
    }
}



