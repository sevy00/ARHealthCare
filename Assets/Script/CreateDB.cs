using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDB : MonoBehaviour
{
    public static Database db;

    /// <summary>
    /// Quando viene avviata l'applicazione viene creato il databse di pazienti e medici.
    /// </summary>
    void Awake()
    {
        db = new Database(); 
    }
}
