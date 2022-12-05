var file = File.ReadAllLines("input");

var crateStacks = file.TakeWhile(l => l != "").SkipLast(1);
var stacks = new Stack<char>[9];

for (var i = 0; i < stacks.Length; i++)
    stacks[i] = new Stack<char>();

foreach (var line in crateStacks.Reverse())
    for (var i = 1; i < line.Length; i += 4)
        if(line[i] != ' ') stacks[i / 4].Push(line[i]);

var moves = file.SkipWhile(x => x != "").Skip(1);
foreach (var line in moves)
{
    var a = line.Split(' ');
    var (amount, from, to) = (int.Parse(a[1]), int.Parse(a[3]), int.Parse(a[5]));

    var tmp = stacks[from - 1].Take(amount);
    foreach (var crate in tmp.Reverse())
        stacks[to - 1].Push(crate);
    
    for (var i = 0; i < amount; i++)
        stacks[from - 1].Pop();
}

foreach (var stack in stacks)
    Console.Write(stack.ElementAtOrDefault(0));
