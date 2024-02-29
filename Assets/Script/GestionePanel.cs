using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

/// <summary>
/// Gestisce il panel della descrizione del paziente nella scena AR
/// </summary>
public class GestionePanel : MonoBehaviour
{
    public static Paziente paziente_scelto;
    public TMP_Text nome;
    public TMP_Text parte_corpo_val;
    public TMP_Text sintomatoloiga_val;
    private int partiColpite;

    /// <summary>
    /// Associa la descrizione del paziente scelto ai componenti UI del pannello
    /// </summary>
    void Start()
    {
        paziente_scelto = SceltaPaziente.paziente_scelto;
        
        nome.text = paziente_scelto.nome + " " + paziente_scelto.cognome;

         partiColpite = paziente_scelto.malattia.Count;

        if (partiColpite == 1)
        {
            //Debug.Log("1 malattia nel panel:");
            parte_corpo_val.text = "" + paziente_scelto.malattia[0].parteColpita;
            sintomatoloiga_val.text = "" + paziente_scelto.malattia[0].sintomatologia;
        }        
    }

    void Update()
    {
        if (partiColpite == 1)
        {
            //Debug.Log("1 malattia nel panel:");
            parte_corpo_val.text = "" + paziente_scelto.malattia[0].parteColpita;
            sintomatoloiga_val.text = "" + paziente_scelto.malattia[0].sintomatologia;
        }
        else
        {
            Debug.Log("Parte_Corpo_Val_GESTIONE PANEL " + GestioneClick.parteCorpo);
            parte_corpo_val.text = "" + GestioneClick.parteCorpo;
            sintomatoloiga_val.text = "" + GestioneClick.sintomatologia;
        }
    }
    
}
