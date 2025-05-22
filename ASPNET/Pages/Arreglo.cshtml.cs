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
        Random rnd = new();
        for (int i = 0; i < 20; i++)
        {
            ArregloOriginal.Add(rnd.Next(0, 101));
        }

        ArregloOrdenado = new List<int>(ArregloOriginal);
        ArregloOrdenado.Sort();

        Suma = 0;
        foreach (var num in ArregloOriginal)
        {
            Suma += num;
        }

        Promedio = (double)Suma / ArregloOriginal.Count;

        var frecuencias = new Dictionary<int, int>();
        foreach (var num in ArregloOriginal)
        {
            if (frecuencias.ContainsKey(num))
                frecuencias[num]++;
            else
                frecuencias[num] = 1;
        }

        int maxFreq = frecuencias.Values.Max();
        Moda = frecuencias.Where(kv => kv.Value == maxFreq && kv.Value > 1)
                         .Select(kv => kv.Key)
                         .ToList();

        int count = ArregloOrdenado.Count;
        if (count % 2 == 1)
        {
            Mediana = ArregloOrdenado[count / 2];
        }
        else
        {
            Mediana = (ArregloOrdenado[(count / 2) - 1] + ArregloOrdenado[count / 2]) / 2.0;
        }
    }
}