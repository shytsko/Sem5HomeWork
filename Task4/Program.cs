// Есть программа с бесконечным циклом. Когда пользователь вводит exit программа заканчивается

// Добавить к программе еще 4 команды (их можно придумать самому). Например: 
// - SetName – Установить имя 
// - Help – вывести список команд 
// - SetPassword – Установить пароль 
// - WriteName – вывести имя после ввода пароля

string name = string.Empty;
string password = string.Empty;

Console.WriteLine("Введите команду. Для вывода списка команд введите Help Для выхода введите Exit");
while (true)
{
    Console.Write("Введите команду > ");
    string inputString = Console.ReadLine();
    if (inputString == "Exit")
        break;
    else if (inputString == "SetName")
    {
        Console.Write("Введите имя > ");
        name = Console.ReadLine();
    }
    else if (inputString == "SetPassword")
    {
        Console.Write("Введите пароль > ");
        password = Console.ReadLine();
    }
    else if (inputString == "WriteName")
    {
        Console.Write("Введите пароль > ");
        string userPassword = Console.ReadLine();
        if(userPassword == password)
            Console.WriteLine($"Ваше имя: {name}");
        else
            Console.WriteLine($"Пароль не верный.");
    }
    else if (inputString == "Help")
    {
        Console.WriteLine("Exit - выход из программы");
        Console.WriteLine("Help - выход списка команд");
        Console.WriteLine("SetName - установить имя");
        Console.WriteLine("SetPassword - установить пароль");
        Console.WriteLine("WriteName - вывести имя (потребуется ввод пароля)");
    }
    else
        Console.WriteLine("Команда не распознана.");
}

