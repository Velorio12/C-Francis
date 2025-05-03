using System;

class TemperaturaFahrenheit
{
    public double Valor { get; set; }

    public TemperaturaFahrenheit(double valor)
    {
        Valor = valor;
    }

    public static implicit operator TemperaturaCelsius(TemperaturaFahrenheit f)
    {
        double celsius = (f.Valor - 32) * 5 / 9;
        return new TemperaturaCelsius(celsius);
    }

    public override string ToString()
    {
        return $"{Valor:F2} °F";
    }
}

class TemperaturaCelsius
{
    public double Valor { get; set; }

    public TemperaturaCelsius(double valor)
    {
        Valor = valor;
    }

    public static implicit operator TemperaturaFahrenheit(TemperaturaCelsius c)
    {
        double fahrenheit = (c.Valor * 9 / 5) + 32;
        return new TemperaturaFahrenheit(fahrenheit);
    }

    public override string ToString()
    {
        return $"{Valor:F2} °C";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Conversor de Temperatura");
        Console.WriteLine("1. Convertir de Celsius a Fahrenheit");
        Console.WriteLine("2. Convertir de Fahrenheit a Celsius");
        Console.Write("Seleccione una opción (1 o 2): ");
        string opcion = Console.ReadLine();

        if (opcion == "1")
        {
            Console.Write("Ingrese la temperatura en °C: ");
            if (double.TryParse(Console.ReadLine(), out double gradosC))
            {
                TemperaturaCelsius tempC = new TemperaturaCelsius(gradosC);
                TemperaturaFahrenheit tempF = tempC;
                Console.WriteLine($"Equivalente: {tempF}");
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }
        else if (opcion == "2")
        {
            Console.Write("Ingrese la temperatura en °F: ");
            if (double.TryParse(Console.ReadLine(), out double gradosF))
            {
                TemperaturaFahrenheit tempF = new TemperaturaFahrenheit(gradosF);
                TemperaturaCelsius tempC = tempF;
                Console.WriteLine($"Equivalente: {tempC}");
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }
        else
        {
            Console.WriteLine("Opción no válida.");
        }

        Console.ReadKey();
    }
}
