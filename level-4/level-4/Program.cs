var file = File.ReadAllLines("input");

var overlapCounter = 0;
foreach (var line in file)
{
    var splitArr = line.Split(',');
    var pair1 = splitArr[0].Split('-').Select(int.Parse).ToArray();
    var pair2 = splitArr[1].Split('-').Select(int.Parse).ToArray();

    if ((pair1[1] <= pair2[1] && pair1[1] >= pair2[0]) ||
        (pair1[0] >= pair2[0] && pair2[1] >= pair1[0]) ||
        (pair1[0] <= pair2[0] && pair1[1] >= pair2[1]) ||
        (pair2[0] <= pair1[0] && pair2[1] >= pair1[1]))
        overlapCounter++;
}

Console.WriteLine(overlapCounter);
