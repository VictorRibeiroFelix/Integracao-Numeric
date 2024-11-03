using System;

class Program
{
    static double F1(double x) => x * x * Math.Sin(x);
    static double F2(double x) => Math.Pow(x, 3) / 3;
    static double F3(double x) => Math.Pow(x, 2);
    static double F4(double x) => Math.Exp(-x * x);

    static double TrapezoidalRule(Func<double, double> f, double a, double b, int n)
    {
        double h = (b - a) / n;
        double integral = 0.5 * (f(a) + f(b));

        for (int i = 1; i < n; i++)
        {
            integral += f(a + i * h);
        }

        integral *= h;
        return integral;
    }

    static void ExibirMenu()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("═══════════════════════════════════════════");
        Console.WriteLine("          Calculadora de Integração        ");
        Console.WriteLine("═══════════════════════════════════════════");

        Console.WriteLine("\nEscolha a função para integrar:\n");
        Console.WriteLine(" 1. f(x) = x^2 * sin(x)");
        Console.WriteLine(" 2. f(x) = x^3 / 3");
        Console.WriteLine(" 3. f(x) = x^2");
        Console.WriteLine(" 4. f(x) = e^-x*2");
        Console.WriteLine("═══════════════════════════════════════════");
        Console.Write("\nEscolha (1 a 4): ");
    }

    static void Main()
    {
        ExibirMenu();

        if (!int.TryParse(Console.ReadLine(), out int escolha) || escolha < 1 || escolha > 4)
         {
             Console.WriteLine("\nEscolha inválida! Tente novamente.");
             return;
        }

        Console.Write("\nDigite o valor de a (limite inferior): ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("\nDigite o valor de b (limite superior): ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("\nDigite o número de subdivisões (n): ");
        int n = int.Parse(Console.ReadLine());

        double result = escolha switch
        {
            1 => TrapezoidalRule(F1, a, b, n),
            2 => TrapezoidalRule(F2, a, b, n),
            3 => TrapezoidalRule(F3, a, b, n),
            4 => TrapezoidalRule(F4, a, b, n)
        }; 

        Console.WriteLine("\n═══════════════════════════════════════════");
        Console.WriteLine($" Resultado da Integral: {result:F3}");
        Console.WriteLine("═══════════════════════════════════════════");
    }
}
