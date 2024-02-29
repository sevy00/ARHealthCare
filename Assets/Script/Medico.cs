using System;
public class Medico
{
    public Medico(string nome, string cognome, string username, string passw)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.username = username;
        this.passw = passw;
    }

    public string nome { get; set; }
    public string cognome { get; set; }
    public string username { get; set; }
    public string passw { get; set; }
}
