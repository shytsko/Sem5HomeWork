// Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.

// [3 7 22 2 78] -> 76


Console.Write("Введите размер массива: ");
int sizeArray = Convert.ToInt32(Console.ReadLine());
double[] array = GenerateDoubleArray(sizeArray, 0, 100);

double min = array[0];
double max = array[0];
for (int i = 1; i < array.Length; i++)
{
    if (array[i] > max)
        max = array[i];

    if (array[i] < min)
        min = array[i];
}

double diff = max - min;
PrintArray(array, '[', ']', ", ", true);
Console.WriteLine($"Разность между максимальным и минимальным элементами массива: {diff}");


double[] GenerateDoubleArray(int size, double minValue, double maxValue)
{
    double[] array = new double[size];

    for (int i = 0; i < array.Length; i++)
    {
        array[i] = new Random().NextDouble() * (maxValue - minValue) + minValue;
    }

    return array;
}

void PrintArray(double[] array, char startSymbol, char endSymbol, string separator, bool endLine)
{
    Console.Write(startSymbol);
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i]);
        if (i != array.Length - 1)
            Console.Write(separator);
    }
    Console.Write(endSymbol);
    if (endLine)
        Console.WriteLine();
}