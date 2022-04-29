// Конвертер валют. У пользователя есть баланс в каждой из представленных валют. С помощью команд он
// может попросить сконвертировать одну валюту в другую. Курс конвертации просто описать в программе.
// Программа заканчивает свою работу в тот момент, когда решит пользователь.

string[] currencies = { "USD", "EUR", "BYN", "RUB", "UAH", "KZT", "CNY" };

double[] аccountBalance = { 1000, 1000, 1000, 1000, 1000, 1000, 1000 };

// To                   USD,    EUR,    BYN,    RUB,    UAH,    KZT,    CNY         From
double[] exchange = {
                        1.00,   0.95,   3.36,   72.75,  30.23,  446.49, 6.66,       // USD
                        1.05,   1.00,   3.53,   76.39,  31.74,  468.80, 6.99,       // EUR
                        0.30,   0.28,   1.00,   21.65,  8.99,   132.85, 1.98,       // BYN
                        0.014,  0.013,  0.046,  1.00,   0.42,   6.14,   0.092,      // RUB
                        0.033,  0.032,  0.11,   2.41,   1.00,   14.77,  0.22,       // UAH
                        0.0022, 0.0021, 0.0075, 0.16,   0.068,  1.00,   0.015,      // KZT
                        0.15,   0.14,   0.50,   10.93,  4.54,   67.06,  1.00        // CNY
                    };



Console.WriteLine("Введите команду. Для вывода списка команд введите Help Для выхода введите Exit");
while (true)
{
    string inputString = InputString("Введите команду > ");
    if (inputString == "Exit")
        break;

    else if (inputString == "Bal")
    {
        inputString = InputString("Остаток какой валюты хотите посмотреть? > ");
        int id = GetIDCurrency(inputString);
        if (id == -1)
        {
            Console.WriteLine($"Нет такой валюты.");
            continue;
        }
        Console.WriteLine($"Остаток валюты {currencies[id]}: {аccountBalance[id]}");
    }

    else if (inputString == "Sell")
    {
        inputString = InputString("Какую валюту хотите продать? > ");
        int idFrom = GetIDCurrency(inputString);
        if (idFrom == -1)
        {
            Console.WriteLine("Нет такой валюты.");
            continue;
        }
        inputString = InputString("Какую валюту хотите получить? > ");
        int idTo = GetIDCurrency(inputString);
        if (idTo == -1)
        {
            Console.WriteLine("Нет такой валюты.");
            continue;
        }
        double amountSell = InputDouble($"Какую сумму хотите продать в {currencies[idFrom]}? > ");
        double exchangeRate = GetExchangeRate(idFrom, idTo);
        Console.WriteLine($"Курс обмена {currencies[idFrom]} -> {currencies[idTo]}: {exchangeRate}");
        double amountReceived = Math.Round(amountSell * exchangeRate, 2);
        if (аccountBalance[idFrom] < amountSell)
        {
            Console.WriteLine($"Не достаточно средств на счёте {currencies[idFrom]}");
            continue;
        }
        Console.WriteLine($"Будет списано {amountSell} {currencies[idFrom]} и зачислено {amountReceived} {currencies[idTo]}.");
        inputString = InputString("Для подтверждения введите Yes > ");
        if (inputString == "Yes")
        {
            аccountBalance[idFrom] -= amountSell;
            аccountBalance[idTo] += amountReceived;
            Console.WriteLine("Операция проведена успешно.");
        }
        else
        {
            Console.WriteLine("Операция отменена.");
        }
    }

    else if (inputString == "Buy")
    {
        inputString = InputString("Какую валюту хотите купить? > ");
        int idTo = GetIDCurrency(inputString);
        if (idTo == -1)
        {
            Console.WriteLine("Нет такой валюты.");
            continue;
        }
        inputString = InputString("Какой валютой хотите оплатить? > ");
        int idFrom = GetIDCurrency(inputString);
        if (idFrom == -1)
        {
            Console.WriteLine("Нет такой валюты.");
            continue;
        }
        double amountBuy = InputDouble($"Какую сумму хотите получить в {currencies[idTo]}? > ");
        double exchangeRate = GetExchangeRate(idFrom, idTo);
        Console.WriteLine($"Курс обмена {currencies[idFrom]} -> {currencies[idTo]}: {exchangeRate}");
        double amountPay = Math.Round(amountBuy / exchangeRate, 2);
        if (аccountBalance[idFrom] < amountPay)
        {
            Console.WriteLine($"Не достаточно средств на счёте {currencies[idFrom]}");
            continue;
        }
        Console.WriteLine($"Будет списано {amountPay} {currencies[idFrom]} и зачислено {amountBuy} {currencies[idTo]}.");
        inputString = InputString("Для подтверждения введите Yes > ");
        if (inputString == "Yes")
        {
            аccountBalance[idFrom] -= amountPay;
            аccountBalance[idTo] += amountBuy;
            Console.WriteLine("Операция проведена успешно.");
        }
        else
        {
            Console.WriteLine("Операция отменена.");
        }
    }

    else if (inputString == "Help")
    {
        Console.WriteLine("Exit - выход из программы");
        Console.WriteLine("Help - выход списка команд");
        Console.WriteLine("Bal - остаток на счёте");
        Console.WriteLine("Sell - продать валюту");
        Console.WriteLine("Buy - купить валюту");
    }
    else
        Console.WriteLine("Команда не распознана.");
}

int GetIDCurrency(string nameCurrency)
{
    for (int i = 0; i < currencies.Length; i++)
    {
        if (currencies[i] == nameCurrency)
            return i;
    }
    return -1;
}

double GetExchangeRate(int codeFrom, int codeTo)
{
    return exchange[codeFrom * currencies.Length + codeTo];
}

string InputString(string message)
{
    Console.Write(message);
    return Console.ReadLine();
}

int InputInt(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

double InputDouble(string message)
{
    Console.Write(message);
    return Convert.ToDouble(Console.ReadLine());
}