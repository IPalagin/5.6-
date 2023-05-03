using System;

internal class Program
{
    private static void Main()
    {
        ReturnCort();
    }
    static void ReturnCort() 
    {
        (string Name, string Famaly, byte Age, bool isPets, byte petNum, byte colorNum) anketa;
        byte petNumb;
        byte colorNumb;
        byte ageUser;

        Console.WriteLine("Введите имя пользователя");
        anketa.Name = Console.ReadLine();

        Console.WriteLine("Введите фамилию пользователя");
        anketa.Famaly = Console.ReadLine();

        anketa.Age = CheckInputByte("Введите возраст пользователя", 100);

        Console.WriteLine("Есть ли у вас питомец ? (Ответьте Да/Нет)");
        var result = Console.ReadLine();
        while (result != "Да" && result != "Нет")
        {
            Console.WriteLine("Некорректный ответ, пожалуйста, ответьте Да или Нет");
            result = Console.ReadLine();
        }

        if (result == "Да")
        {
            anketa.isPets = true;
            petNumb = CheckInputByte("Укажите количество питомцев", 10);
            while (petNumb == 0)
            {
                Console.WriteLine("Количество питомцев не может быть равно 0");
                petNumb = CheckInputByte("Укажите количество питомцев", 10);
            }
            anketa.petNum = petNumb;
            NumPetsName(ref petNumb);
        }
        else 
        {
            anketa.isPets = false;
        }

        colorNumb = CheckInputByte("Укажите количество ваших любимых цветов", 10);
        anketa.colorNum = colorNumb;
        NumColor(ref colorNumb);
    }

    static string[] NumPetsName(ref byte petNumb)
    {
        string[] petName = new string[petNumb];

        Console.WriteLine("Назовите кличку(ки) своего(их) питомцев");
        for (int i = 0; i < petNumb; i++)
        {
            petName[i] = Console.ReadLine();
        }
        return petName;   
    }

    static string[] NumColor(ref byte colorNumb)
    {
        string[] color = new string[colorNumb];

        Console.WriteLine("Назовите ваши любимые цвета");
        for (int j = 0;j < colorNumb; j++)
        {
            color[j] = Console.ReadLine();
        }
        return color;
    }

    static byte CheckInputByte(string message, byte maxAllowedValue)
    {
        byte result;
        bool isValidInput;
        do
        {
            Console.WriteLine(message);
            isValidInput = byte.TryParse(Console.ReadLine(), out result) && result <= maxAllowedValue;
            if (!isValidInput)
            {
                Console.WriteLine($"Некорректное значение. Введите число от 0 до {maxAllowedValue}.");
            }
        } while (!isValidInput);
        return result;
    }

    static void ShowData((string Name, string Famaly, byte Age, bool isPets, byte petNum, byte colorNum) anketa, string[] petName, string[] color)
    {
        Console.WriteLine($"Имя: {anketa.Name}");
        Console.WriteLine($"Фамилия: {anketa.Famaly}");
        Console.WriteLine($"Возраст: {anketa.Age}");
        if (anketa.isPets)
        {
            Console.WriteLine($"Количество питомцев: {anketa.petNum}");
            Console.WriteLine("Клички питомцев:");
            foreach (string pet in petName)
            {
                Console.WriteLine(pet);
            }
        }
        else
        {
            Console.WriteLine("У пользователя нет питомцев");
        }
        Console.WriteLine($"Количество любимых цветов: {anketa.colorNum}");
        Console.WriteLine("Любимые цвета:");
        foreach (string col in color)
        {
            Console.WriteLine(col);
        }
    }
}