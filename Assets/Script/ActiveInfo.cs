using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe creata per attivare o disattivare i canvas
/// </summary>
public class ActiveInfo : MonoBehaviour
{
    public GameObject canvasMain;
    public GameObject canvasInfo;
    public GameObject canvasLogin;
    public GameObject canvaPopUp;


    //Mostra il canvas delle funzionalità
    public void ShowInfo()
    {
        canvasInfo.SetActive(true);
        canvasMain.SetActive(false);
        canvasLogin.SetActive(false);
        canvaPopUp.SetActive(false);
        
    }

    //Nasconde il canvas delle funzionalità
    public void HideInfo()
    {
        canvasMain.SetActive(true);
        canvasInfo.SetActive(false);
        canvasLogin.SetActive(false);
        canvaPopUp.SetActive(false);
        
    }

    //Mostra il canvas del login
    public void showLogin()
    {
        canvasLogin.SetActive(true);
        canvasMain.SetActive(false);
        canvaPopUp.SetActive(false);
        canvasInfo.SetActive(false);
    }

    //Nasconde il canvas del login
    public void HideLogin()
    {
        canvasMain.SetActive(true);
        canvasInfo.SetActive(false);
        canvaPopUp.SetActive(false);
        canvasLogin.SetActive(false);
    }

    //Ritorna alla login se l'utente ha sbagliato nome utente o password
    public void backPopUp()
    {
        canvasLogin.SetActive(true);
        canvaPopUp.SetActive(false);
        canvasMain.SetActive(false);
        canvasInfo.SetActive(false);
    }
}
