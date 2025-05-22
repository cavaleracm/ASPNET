using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Text;

public class CesarModel : PageModel
{
    [BindProperty]
    public string MensajeOriginal { get; set; } = "";

    [BindProperty]
    public int Desplazamiento { get; set; }

    [BindProperty]
    public string Modo { get; set; } = "codificar";

    public string MensajeProcesado { get; set; } = "";

    private const string Alfabeto = "ABCDEFGHIJKLMNOPQRSTUVXYZ";

    public void OnPost()
    {
        MensajeProcesado = ProcesarMensajeAlternativo(MensajeOriginal.ToUpper(), Desplazamiento, Modo);
    }

    private string ProcesarMensajeAlternativo(string mensaje, int desplazamiento, string modo)
    {
        return new string(mensaje.Select(c => ProcesarCaracter(c, desplazamiento, modo)).ToArray());
    }

    private char ProcesarCaracter(char caracter, int desplazamiento, string modo)
    {
        if (!Alfabeto.Contains(caracter))
        {
            return caracter; 
        }

        int posicion = Alfabeto.IndexOf(caracter);
        int nuevaPosicion;

        if (modo == "codificar")
        {
            nuevaPosicion = (posicion + desplazamiento) % Alfabeto.Length;
            if (nuevaPosicion < 0) nuevaPosicion += Alfabeto.Length;
        }
        else // decodificar
        {
            nuevaPosicion = (posicion - desplazamiento) % Alfabeto.Length;
            if (nuevaPosicion < 0) nuevaPosicion += Alfabeto.Length;
        }

        return Alfabeto[nuevaPosicion];
    }
}