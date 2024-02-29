using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Gestisce lil popolamento dello scrollView
/// </summary>
public class SceltaPaziente : MonoBehaviour
{
    public GameObject text;
    public Transform contenitore;
    public List<Paziente> listaPazienti;
    private static Database database;
    public static Medico med;
    public TMP_Text nome_medico;
    public static Paziente paziente_scelto;

    
    void Start()
    {
        database = CreateDB.db;
        listaPazienti = database.pazienti;

        med = LoginMedico.medico_scelto;
        nome_medico.text = med.nome + " " + med.cognome;
        PopolaLista();
    }

    void PopolaLista()
    {
        // Pulire il contenitore
        foreach (Transform child in contenitore)
        {
            Debug.Log("Pulito.");
            Destroy(child.gameObject);
        }

        // Posizione iniziale degli elementi nel content
        float yOffset = -75;

        // Popola la lista con gli elementi
        foreach (Paziente p in listaPazienti)
        {
            string nome = p.nome + " " + p.cognome;
            GameObject nuovoElemento = Instantiate(text, contenitore);

            // Regola la posizione del nuovo elemento nel content
            RectTransform rt = nuovoElemento.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector3(0, -yOffset, 0);

            // Aggiorna l'offset per il prossimo elemento
            yOffset += rt.rect.height + 40; // Spazio tra gli elementi

            nuovoElemento.GetComponentInChildren<TMP_Text>().text = nome;
            Button button = nuovoElemento.GetComponent<Button>();
            button.onClick.AddListener(() => SelezionaOpzione(p.nome, p.cognome));
        }
    }

    void SelezionaOpzione(string nome_scelto, string cognome_scelto)
    {
        //Debug.Log("Entrato in paziente");
        paziente_scelto = listaPazienti.Find(obj => obj.nome.Equals(nome_scelto) && obj.cognome.Equals(cognome_scelto));
        if (paziente_scelto != null)
        {
            //Debug.Log("Paziente scelto: " + paziente_scelto.nome + paziente_scelto.malattia[0].parteColpita);
            SceneManager.LoadScene(1);
        }

    }
}
