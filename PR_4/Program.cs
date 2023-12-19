class Program
{
    static List<Zametka> list_one_day = new List<Zametka>();
    static List<Zametka> all_zametki = new List<Zametka>()
        {
            new Zametka("Заметка1","Описание1", new DateTime(2023,12,10)),
            new Zametka("Заметка2","Описание2", new DateTime(2023,12,12)),
            new Zametka("Заметка3","Описание3", new DateTime(2023,12,18)),
            new Zametka("Заметка4","Описание4", new DateTime(2023,12,18))
        };
    static void Main()
    {
        set_day(DateTime.Now);
    }
    static void set_day(DateTime date)
    {
        Console.Clear();
        Console.WriteLine($"Выбранная дата: {date.ToShortDateString()}");
        Console.WriteLine(string.Join("", Enumerable.Repeat("-", 30)));
        list_one_day.Clear();
        foreach (var a in all_zametki)
            if (date.ToShortDateString() == a.Date)
            {
                Console.WriteLine($"  {a.Title}");
                list_one_day.Add(a);
            }
        ConsoleKeyInfo key;
        int point = 2;
        Console.SetCursorPosition(0, point);
        Console.Write(">>");
        do
        {
            Console.SetCursorPosition(0, point);
            Console.Write(">>");
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.DownArrow)
            {
                Console.SetCursorPosition(0, point);
                Console.WriteLine("  ");
                point++;
                if (point > list_one_day.Count + 1)
                    point = 2;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                Console.SetCursorPosition(0, point);
                Console.WriteLine("  ");
                point--;
                if (point < 2)
                    point = list_one_day.Count + 1;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
                set_day(date.AddDays(-1));
            else if (key.Key == ConsoleKey.RightArrow)
                set_day(date.AddDays(1));
        } while (key.Key != ConsoleKey.Enter);
        read_zametka(list_one_day[point - 2]);
        set_day(date);

    }
    static void read_zametka(Zametka tmp)
    {
        Console.Clear();
        Console.WriteLine($"Выбранная заметка {tmp.Title}");
        Console.WriteLine(string.Join("", Enumerable.Repeat("-", 50)));
        Console.WriteLine($"Описание: {tmp.Description}\nДата заметки: {tmp.Date}");
        Console.ReadKey(true);
    }
}
class Zametka
{
    public string Title;
    public string Description;
    public string Date;

    public Zametka(string title, string description, string date)
    {
        Title = title;
        Description = description;
        Date = date;
    }
    public Zametka(string title, string description, DateTime date)
    {
        Title = title;
        Description = description;
        Date = date.ToShortDateString();
    }
}