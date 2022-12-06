var line = File.ReadAllText("input");

for (int i = 0; i < line.Length - 14; i++)
{
    var slice = line.Substring(i, 14);
    if (slice.Distinct().Count() == 14)
    {
        Console.WriteLine(i + 14);
        break;
    } 
}
