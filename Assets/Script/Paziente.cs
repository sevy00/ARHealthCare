using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paziente
{
    public Paziente(string nome, string cognome, string cf, int eta, string nazione, List<Malattia> malattia)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.cf = cf;
        this.eta = eta;
        this.nazione = nazione;
        this.malattia = malattia;
    }

    public string nome { get; set; }
    public string cognome { get; set; }
    private string cf { get; set; }
    private int eta { get; set; }
    private string nazione { get; set; }
    public List<Malattia> malattia { get; set; }
}
