var grid = File.ReadLines("input")
    .Select(x => x.Select(x => x - 48).ToArray())
    .ToArray();

var bestScenicScore = 0;

for (var i = 1; i < grid.Length - 1; i++)
{
    for (var j = 1; j < grid[i].Length - 1; j++)
    {
        var current = grid[i][j];
        
        var leftVisibleCount = grid[i].Take(j).Reverse().TakeWhile(x => x < current).Count();
        var rightVisibleCount = grid[i].Skip(j + 1).TakeWhile(x => x < current).Count();
        var topVisibleCount = grid.Take(i).Reverse().TakeWhile(x => x[j] < current).Count();
        var bottomVisibleCount = grid.Skip(i + 1).TakeWhile(x => x[j] < current).Count();
        
        var leftVisibleSameHeight = grid[i].Take(j).Reverse().FirstOrDefault(x => x >= current);
        var rightVisibleSameHeight = grid[i].Skip(j + 1).FirstOrDefault(x => x >= current);
        var topVisibleSameHeight = grid.Take(i).Reverse().Select(x => x[j]).FirstOrDefault(x => x >= current);
        var bottomVisibleSameHeight = grid.Skip(i + 1).Select(x => x[j]).FirstOrDefault(x => x >= current);
        
        if(leftVisibleSameHeight > 0) leftVisibleCount++;
        if(rightVisibleSameHeight > 0) rightVisibleCount++;
        if(topVisibleSameHeight > 0) topVisibleCount++;
        if(bottomVisibleSameHeight > 0) bottomVisibleCount++;

        var scenicScore = leftVisibleCount * rightVisibleCount * topVisibleCount * bottomVisibleCount;
        if (scenicScore > bestScenicScore) bestScenicScore = scenicScore;
    }
}

Console.WriteLine(bestScenicScore);
