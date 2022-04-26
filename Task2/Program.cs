// Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.

// [3, 7, 23, 12] -> 19
// [-4, -6, 89, 6] -> 0

Console.Write("Введите размер массива: ");
int sizeArray = Convert.ToInt32(Console.ReadLine());
int[] array = GenerateArray(sizeArray, -999, 999);
PrintArray(array, '[', ']', ", ", true);
int sum = SumOddPositions(array);
Console.WriteLine($"Сумма элементов на нечётных позициях: {sum}");


int[] GenerateArray(int size, int minValue, int maxValue)
{
    int[] array = new int[size];

    for (int i = 0; i < array.Length; i++)
    {
        array[i] = new Random().Next(minValue, maxValue + 1);
    }

    return array;
}

int SumOddPositions(int[] array)
{
    int sum = 0;
    for (int i = 1; i < array.Length; i += 2)
    {
        sum += array[i];
    }

    return sum;
}

void PrintArray(int[] array, char startSymbol, char endSymbol, string separator, bool endLine)
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
