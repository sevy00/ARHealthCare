using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GestioneClick : MonoBehaviour
{
    public static string parteCorpo, sintomatologia;
    public static Paziente paziente;
    private Touch t;

    // Start is called before the first frame update
    void Start()
    {
        paziente = SceltaPaziente.paziente_scelto;
        if (paziente == null) {
            Debug.LogWarning("PAZIENTE SCELTO NON TROVATO!!");
        }
    }

    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Debug.Log("Hit");
            if(Physics.Raycast(ray, out hit))
            {
                switch (hit.transform.name)
                {
                    case "objectLeftArm":
                        parteCorpo = "" + paziente.malattia[1].parteColpita;
                        sintomatologia = "" + paziente.malattia[1].sintomatologia;
                        //Debug.Log("Colpito braccio sx");
                        break;
                    case "objectHips":
                        parteCorpo = "" + paziente.malattia[2].parteColpita;
                        sintomatologia = "" + paziente.malattia[2].sintomatologia;
                        //Debug.Log("Colpito hips");
                        break;
                    case "objectHead":
                        parteCorpo = "" + paziente.malattia[0].parteColpita;
                        sintomatologia = "" + paziente.malattia[0].sintomatologia;
                        //Debug.Log("Colpito testa");
                        break;
                }
            }
        }
    }
}
