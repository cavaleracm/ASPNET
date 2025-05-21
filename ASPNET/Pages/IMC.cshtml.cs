using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IMCModel : PageModel
{
    [BindProperty]
    public double Peso { get; set; }

    [BindProperty]
    public double Altura { get; set; }

    public double IMC { get; set; }
    public string Clasificacion { get; set; } = "";
    public string ImagenRecomendacion { get; set; } = "";

    public void OnPost()
    {
        if (Altura <= 0) return;

        IMC = Peso / (Altura * Altura);

        if (IMC < 18)
        {
            Clasificacion = "Peso Bajo";
            ImagenRecomendacion = "bajo.jpg";
        }
        else if (IMC < 25)
        {
            Clasificacion = "Peso Normal";
            ImagenRecomendacion = "normal.webp";
        }
        else if (IMC < 27)
        {
            Clasificacion = "Sobrepeso";
            ImagenRecomendacion = "sobrepeso.jpg";
        }
        else if (IMC < 30)
        {
            Clasificacion = "Obesidad Grado I";
            ImagenRecomendacion = "grado1.jpg";
        }
        else if (IMC < 40)
        {
            Clasificacion = "Obesidad Grado II";
            ImagenRecomendacion = "grado1.jpg";
        }
        else
        {
            Clasificacion = "Obesidad Grado III";
            ImagenRecomendacion = "grado1.jpg";
        }
    }
}
