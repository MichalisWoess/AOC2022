var line = File.ReadAllText("input");

for (int i = 0; i < line.Length - 4; i++)
{
    var slice = line.Substring(i, 4);
    if (slice.Distinct().Count() == 4)
    {
        Console.WriteLine(i +4);
        break;
    } 
}
