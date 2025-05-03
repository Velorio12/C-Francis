using System;

class Kilometros
{
    public double Valor { get; set; }

    public Kilometros(double valor)
    {
        Valor = valor;
    }

    // Conversión implícita de Kilómetros a Millas
    public static implicit operator Millas(Kilometros km)
    {
        double millas = km.Valor * 0.621371;
        return new Millas(millas);
    }

    public override string ToString()
    {
        return $"{Valor:F2} km";
    }
}

class Millas
{
    public double Valor { get; set; }

    public Millas(double valor)
    {
        Valor = valor;
    }

    // Conversión implícita de Millas a Kilómetros
    public static implicit operator Kilometros(Millas mi)
    {
        double km = mi.Valor / 0.621371;
        return new Kilometros(km);
    }

    public override string ToString()
    {
        return $"{Valor:F2} mi";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Conversor de Distancias");
        Console.WriteLine("1. Convertir de kilómetros a millas");
        Console.WriteLine("2. Convertir de millas a kilómetros");
        Console.Write("Seleccione una opción (1 o 2): ");
        string opcion = Console.ReadLine();

        if (opcion == "1")
        {
            Console.Write("Ingrese la distancia en kilómetros: ");
            if (double.TryParse(Console.ReadLine(), out double kmValor))
            {
                Kilometros km = new Kilometros(kmValor);
                Millas mi = km;
                Console.WriteLine($"Equivalente: {mi}");
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }
        else if (opcion == "2")
        {
            Console.Write("Ingrese la distancia en millas: ");
            if (double.TryParse(Console.ReadLine(), out double miValor))
            {
                Millas mi = new Millas(miValor);
                Kilometros km = mi;
                Console.WriteLine($"Equivalente: {km}");
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
