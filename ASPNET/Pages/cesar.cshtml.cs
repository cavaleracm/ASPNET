using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

    private readonly char[] alfabeto =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Replace("W", "").ToCharArray(); // 25 letras

    public void OnPost()
    {
        MensajeProcesado = ProcesarMensaje(MensajeOriginal.ToUpper(), Desplazamiento, Modo);
    }

    private string ProcesarMensaje(string mensaje, int n, string modo)
    {
        StringBuilder resultado = new StringBuilder();

        foreach (char c in mensaje)
        {
            if (char.IsLetter(c) && c != 'W')
            {
                int index = Array.IndexOf(alfabeto, c);
                if (index == -1)
                {
                    resultado.Append(c); // letra no incluida, como W
                    continue;
                }

                int nuevoIndex;
                switch (modo)
                {
                    case "codificar":
                        nuevoIndex = (index + n) % alfabeto.Length;
                        break;
                    case "decodificar":
                        nuevoIndex = (index - n + alfabeto.Length) % alfabeto.Length;
                        break;
                    default:
                        nuevoIndex = index;
                        break;
                }

                resultado.Append(alfabeto[nuevoIndex]);
            }
            else
            {
                // espacio u otro símbolo
                resultado.Append(c);
            }
        }

        return resultado.ToString();
    }
}
