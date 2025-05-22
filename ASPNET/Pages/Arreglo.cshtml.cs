using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

public class ArregloModel : PageModel
{
    public List<int> ArregloOriginal { get; set; } = new();
    public List<int> ArregloOrdenado { get; set; } = new();
    public int Suma { get; set; }
    public double Promedio { get; set; }
    public List<int> Moda { get; set; } = new();
    public double Mediana { get; set; }

    public void OnGet()
    {
        // Generar 20 números aleatorios
        Random rnd = new();
        ArregloOriginal = Enumerable.Range(0, 20).Select(_ => rnd.Next(0, 101)).ToList();
        ArregloOrdenado = ArregloOriginal.OrderBy(n => n).ToList();

        // Suma y promedio
        Suma = ArregloOriginal.Sum();
        Promedio = ArregloOriginal.Average();

        // Moda
        var grupos = ArregloOriginal.GroupBy(n => n)
                                    .Select(g => new { Numero = g.Key, Frecuencia = g.Count() })
                                    .Where(g => g.Frecuencia > 1);

        int maxFreq = grupos.Any() ? grupos.Max(g => g.Frecuencia) : 0;
        Moda = grupos.Where(g => g.Frecuencia == maxFreq).Select(g => g.Numero).ToList();

        // Mediana
        int mid = ArregloOrdenado.Count / 2;
        Mediana = ArregloOrdenado.Count % 2 == 0
            ? (ArregloOrdenado[mid - 1] + ArregloOrdenado[mid]) / 2.0
            : ArregloOrdenado[mid];
    }
}
