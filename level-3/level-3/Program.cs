var file = File.ReadAllLines("input");

var rucksacks = file.Select(line => line).ToList();

// Part A
// var prioritySum = 0;
// foreach (var rucksack in rucksacks)
// {
//     var letters = new char[52];
//     for (var i = 0; i < rucksack.Length / 2; i++)
//     {
//         var letter = rucksack[i];
//         var letterIndex = letter - 'a' >= 0 ? letter - 'a' : letter - 'A' + 26;
//         letters[letterIndex]++;
//     }
//     
//     for (var i = rucksack.Length / 2; i < rucksack.Length; i++)
//     {
//         var letter = rucksack[i];
//         var letterIndex = letter - 'a' >= 0 ? letter - 'a' : letter - 'A' + 26;
//         if (letters[letterIndex] > 0)
//         {
//             prioritySum += letterIndex + 1;
//             break;
//         }
//     }
// }

// Part B
var prioritySum = 0;
for (var i = 0; i < rucksacks.Count; i += 3)
{
    var letterCounts = new Dictionary<char, int>();
    for (var j = 0; j < 3; j++)
    {
        var rucksack = rucksacks[i + j];
        foreach (var letter in rucksack.Distinct())
        {
            if (letterCounts.ContainsKey(letter))
                letterCounts[letter]++;
            else
                letterCounts.Add(letter, 1);
        }
    }
    
    foreach (var (letter, value) in letterCounts)
    {
        if (value >= 3)
        {
            prioritySum += (letter - 'a' >= 0 ? letter - 'a' : letter - 'A' + 26) + 1;
            break;
        }
    }
}

Console.WriteLine(prioritySum);
