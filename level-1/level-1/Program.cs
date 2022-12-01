
var file = File.ReadAllLines("input.txt");

List<int> calorieSums = new();
int calorieSum = 0;
foreach (var calorieCount in file)
{
    if(calorieCount != "")
        calorieSum += int.Parse(calorieCount);
    else
    {
        calorieSums.Add(calorieSum);
        calorieSum = 0;
    }
}

Console.WriteLine(calorieSums.Max());
// sum of top three
Console.WriteLine(calorieSums.OrderByDescending(x => x).Take(3).Sum());