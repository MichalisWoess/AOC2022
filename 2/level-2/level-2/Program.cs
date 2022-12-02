var file = File.ReadAllLines("input");

Dictionary<char, int> shapeScores = new()
{
    ['X'] = 1,
    ['Y'] = 2,
    ['Z'] = 3
};

Dictionary<char, char> winPairing = new()
{
    ['A'] = 'Y', // Rock vs Paper
    ['B'] = 'Z', // Paper vs Scissors
    ['C'] = 'X' // Scissors vs Rock
};

Dictionary<char, char> losePairing = new()
{
    ['A'] = 'Z',
    ['B'] = 'X',
    ['C'] = 'Y'
};

Dictionary<char, char> sameShape = new()
{
    ['A'] = 'X',
    ['B'] = 'Y',
    ['C'] = 'Z'
};

var scoreSum = 0;
foreach (var pairing in file)
{
    var shape1 = pairing[0];
    var pick = pairing[2];

    // X lose
    // Y draw
    // Z win
    var shape2 = pick switch
    {
        'X' => losePairing[shape1],
        'Y' => sameShape[shape1],
        'Z' => winPairing[shape1]
    };

    var shapeScore = shapeScores[shape2];

    var winScore = 0;
    if (shape2 == sameShape[shape1]) winScore = 3;
    else if (winPairing[shape1] == shape2) winScore = 6;

    scoreSum += shapeScore + winScore;
}

Console.WriteLine(scoreSum);
