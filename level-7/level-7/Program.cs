using System.Text;

var file = File.ReadLines("input").ToArray();

var fileTree = new Dictionary<string, long>();
var currentDir = new Stack<string>();
for (var i = 0; i < file.Length; i++)
{
    var line = file[i];
    if (line.StartsWith("$ cd"))
    {
        if (line.Last() == '.')
            currentDir.Pop();
        else
        {
            var dirName = line.Split(' ')[2];
            
            if (dirName != "/") currentDir.Push("/" + dirName);
            else currentDir.Push("/");
            
            if (!fileTree.ContainsKey(GetPath()))
                fileTree.Add(GetPath(), 0);
            
            var dirContents = file
                .Skip(i + 2)
                .TakeWhile(l => !l.StartsWith("$ cd"));

            foreach (var elem in dirContents)
                if (char.IsNumber(elem[0]))
                {
                    var path = GetPath();
                    while (path != "/" && path != "" && path != "//")
                    {
                        fileTree[path] += long.Parse(elem.Split(' ')[0]);
                        path = path[..path.LastIndexOf('/')];
                    }

                    fileTree["/"] += long.Parse(elem.Split(' ')[0]);
                }
        }
    }
}

// A
// var sum = result
//     .Where(x => x.Value <= 100000)
//     .Sum(x => x.Value);

const int totalSpace = 70_000_000;
const int neededSpace = 30_000_000;
var freeSpace = totalSpace - fileTree["/"];
var spaceToDelete = neededSpace - freeSpace;

var smallestDir = fileTree
    .Where(x => x.Value >= spaceToDelete)
    .MinBy(x => x.Value);

Console.WriteLine(smallestDir);

string GetPath()
{
    if (currentDir.Count == 1)
        return "/";

    var sb = new StringBuilder();
    foreach (var d in currentDir.Reverse())
        sb.Append(d);
    return sb.ToString();
}