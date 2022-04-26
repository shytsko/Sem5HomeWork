// Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.

// [3 7 22 2 78] -> 76


Console.Write("Введите размер массива: ");
int sizeArray = Convert.ToInt32(Console.ReadLine());
double[] array = new double[sizeArray];

for (int i = 0; i < array.Length; i++)
{
    Console.Write($"array[{i}] = ");
    array[i] = Convert.ToDouble(Console.ReadLine());
}

double min = array[0];
double max = array[0];
for (int i = 1; i < array.Length; i++)
{
    if (array[i]>max)
        max = array[i];

    if (array[i]<min)
        min = array[i];
}

double diff = max - min;

Console.WriteLine($"Разность между максимальным и минимальным элементами массива: {diff}");