public class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static ComplexNumber ReadFromConsole()
    {
        Console.Write("Введите действительную часть: ");
        double real = double.Parse(Console.ReadLine());
        Console.Write("Введите мнимую часть: ");
        double imaginary = double.Parse(Console.ReadLine());
        return new ComplexNumber(real, imaginary);
    }

    // Сложение
    public ComplexNumber Sum(ComplexNumber other)
    {
        return new ComplexNumber(Real + other.Real, Imaginary + other.Imaginary);
    }

    // Вычитание
    public ComplexNumber Difference(ComplexNumber other)
    {
        return new ComplexNumber(Real - other.Real, Imaginary - other.Imaginary);
    }

    // Умножение
    public ComplexNumber Product(ComplexNumber other)
    {
        return new ComplexNumber(
            Real * other.Real - Imaginary * other.Imaginary,
            Real * other.Imaginary + Imaginary * other.Real
        );
    }

    // Деление
    public ComplexNumber Quotient(ComplexNumber other)
    {
        double denominator = other.Real * other.Real + other.Imaginary * other.Imaginary;
        return new ComplexNumber(
            (Real * other.Real + Imaginary * other.Imaginary) / denominator,
            (Imaginary * other.Real - Real * other.Imaginary) / denominator
        );
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите первое комплексное число:");
        ComplexNumber a = ComplexNumber.ReadFromConsole();
        Console.WriteLine("Введите второе комплексное число:");
        ComplexNumber b = ComplexNumber.ReadFromConsole();

        ComplexNumber sum = a.Sum(b);
        ComplexNumber difference = a.Difference(b);
        ComplexNumber product = a.Product(b);
        ComplexNumber quotient = a.Quotient(b);

        Console.WriteLine($"Сумма: {sum}");
        Console.WriteLine($"Разность: {difference}");
        Console.WriteLine($"Произведение: {product}");
        Console.WriteLine($"Частное: {quotient}");
    }
}
