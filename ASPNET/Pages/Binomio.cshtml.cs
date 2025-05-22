using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class BinomioModel : PageModel
{
    [BindProperty]
    public double A { get; set; }

    [BindProperty]
    public double B { get; set; }

    [BindProperty]
    public double X { get; set; }

    [BindProperty]
    public double Y { get; set; }

    [BindProperty]
    public int N { get; set; }

    public double? Resultado { get; set; }

    public void OnPost()
    {
        Resultado = EvaluarExpresion(A, B, X, Y, N);
    }

    private double EvaluarExpresion(double a, double b, double x, double y, int n)
    {
        double resultado = 0;

        for (int k = 0; k <= n; k++)
        {
            double coefBinomial = Factorial(n) / (Factorial(k) * Factorial(n - k));
            double termino = coefBinomial * Math.Pow(a * x, n - k) * Math.Pow(b * y, k);
            resultado += termino;
        }

        return resultado;
    }

    private double Factorial(int num)
    {
        double res = 1;
        for (int i = 2; i <= num; i++)
            res *= i;
        return res;
    }
}
