using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary> 
/// Effettua il login del medico
/// </summary>
public class LoginMedico : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    private string username;
    private string password;
    public static Medico medico_scelto;
    private List<Medico> listaMedici;
    public Button conferma;
    private static Database database;
    public GameObject popUp;
    public GameObject login;

    /// <summary>
    /// Recupera dal database la lista dei medici 
    /// </summary>
    void Start()
    {
        database = CreateDB.db;
        listaMedici = new List<Medico>();
        listaMedici = database.medici;
        
        
        if (conferma != null)
        {
            conferma.onClick.AddListener(cambiaScena);
        }
        else
        {
            Debug.LogError("Il riferimento al componente Button non ? stato assegnato!");
        }
    }

    /// <summary>
    /// Verifica che le credenziali inserite siano associate ad un medico, se vero carica la scena dell'applicativo 
    /// </summary>
    private void cambiaScena()
    {
        username = usernameField.text;
        password = passwordField.text;
        
        if ((listaMedici.Find(obj => obj.username.Equals(username) && obj.passw.Equals(password))) != null)
        {
            medico_scelto = (Medico) (listaMedici.Find(obj => obj.username.Equals(username) && obj.passw.Equals(password)));
            SceneManager.LoadScene(2);
        }
            
        else
        { 
            popUp.SetActive(true);
            login.SetActive(false);
        }
            
           
    }
}
