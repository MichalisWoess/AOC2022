var grid = File.ReadLines("input").Select(x => x.ToCharArray()).ToArray();

var visibleTreesCount = grid.Length * 4 - 4;

// iterate through the grid excluding the edges

for (int i = 1; i < grid.Length - 1; i++)
{
    // iterate through the grid excluding the edges
    for (int j = 1; j < grid[i].Length - 1; j++)
    {
        var current = grid[i][j];
        // Each tree is represented as a single digit whose value is its height, where 0 is the shortest and 9 is the tallest.
        // A tree is visible if all of the other trees between it and an edge of the grid are shorter than it.
        // count the visible trees
        var leftSmaller = grid[i].Take(j).All(x => x < current);
        var rightSmaller = grid[i].Skip(j + 1).All(x => x < current);
        var topSmaller = grid.Take(i).All(x => x[j] < current);
        var bottomSmaller = grid.Skip(i + 1).All(x => x[j] < current);
        
        if (leftSmaller || rightSmaller || topSmaller || bottomSmaller)
        {
            visibleTreesCount++;
        }
    }
}

Console.WriteLine(visibleTreesCount);
