using System;
using System.Collections.Generic;
using UnityEngine;

public class Database
{
    /// <summary>
    /// Database contentente Medici e Pazienti 
    /// </summary>
    public Database()
    {
        pazienti = new List<Paziente>();
        medici = new List<Medico>();
        List<Malattia> paziente1 = new List<Malattia>();
        paziente1.Add(new Malattia("RightLeg", "Frattura composta superiore del femore sito nella parte destra."));

        List<Malattia> paziente2 = new List<Malattia>();
        paziente2.Add(new Malattia("LeftArm", "Frattura scomposta inferiore dell'omero sito nella parte sinistra."));

        List<Malattia> paziente3 = new List<Malattia>();
        paziente3.Add(new Malattia("Hips", "Coxartrosi, lesione nella parte destra dell'anca."));

        List<Malattia> paziente4 = new List<Malattia>();
        paziente4.Add(new Malattia("Head","Sclerosi laterale amiotrofica (SLA)."));
        paziente4.Add(new Malattia("LeftArm", "Frattura composta superiore dell'omero sito nella parte sinistra."));
        paziente4.Add(new Malattia("Hips", "Lesione della parte inferiore dell'anca destra."));

        pazienti.Add(new Paziente("Mario", "Rossi", "MRORSS01", 22, "Italia", paziente1));
        pazienti.Add(new Paziente("Emma", "Bianchi", "EMMBNC00", 23, "Italia", paziente2));
        pazienti.Add(new Paziente("Giuseppe", "Marroni", "GSPMRN70", 54, "Italia",paziente3));
        pazienti.Add(new Paziente("Rosa","Verdi","RSAVRD34",90,"Italia", paziente4));


        medici.Add(new Medico("Luca", "Verdi", "userluca", "passluca"));
    }

    public List<Paziente> pazienti { get; set; }
    public List<Medico> medici { get; set; }
}
