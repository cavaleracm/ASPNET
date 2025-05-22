using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class IMCModel : PageModel
{
    [BindProperty]
    public double Peso { get; set; }

    [BindProperty]
    public double Altura { get; set; }

    public double IMC { get; set; }
    public string Clasificacion { get; set; } = "";
    public string ImagenRecomendacion { get; set; } = "";

    private readonly List<ClasificacionIMC> _clasificaciones = new()
    {
        new(0, 18, "Peso Bajo", "bajo.jpg"),
        new(18, 25, "Peso Normal", "normal.jpg"),
        new(25, 27, "Sobrepeso", "sobrepeso.jpg"),
        new(27, 30, "Obesidad Grado I", "grado1.jpg"),
        new(30, 40, "Obesidad Grado II", "grado1.jpg"),
        new(40, double.MaxValue, "Obesidad Grado III", "grado1.jpg")
    };

    public void OnPost()
    {
        if (Altura <= 0) return;

        IMC = CalcularIMC(Peso, Altura);
        var clasificacion = DeterminarClasificacion(IMC);

        Clasificacion = clasificacion.Nombre;
        ImagenRecomendacion = clasificacion.Imagen;
    }

    private static double CalcularIMC(double peso, double altura)
    {
        return peso / (altura * altura);
    }

    private ClasificacionIMC DeterminarClasificacion(double imc)
    {
        foreach (var clasificacion in _clasificaciones)
        {
            if (imc < clasificacion.LimiteSuperior)
                return clasificacion;
        }
        return _clasificaciones.Last(); 
    }

    private record ClasificacionIMC(double LimiteInferior, double LimiteSuperior, string Nombre, string Imagen);
}