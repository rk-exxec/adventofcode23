
Console.WriteLine("Advent of code 2023 - Day 2");

var input = System.IO.File.ReadLines("S:\\git_repos\\adventofcode23\\adventofcode23-2\\input.txt");

int sum = 0;
var invalidGames = new List<int>();
foreach (var line in input)
{
    var gameSplit = line.Split(":");
    int gameID = int.Parse(gameSplit[0].Split(" ")[1]);
    var setsSplit = gameSplit[1].Split(";");
    var gameValid = true;

    foreach (var set in setsSplit)
    {
        var cubesSplit = set.Split(",");
        var numRedCubes = 0;
        var numGreenCubes = 0;
        var numBlueCubes = 0;
        foreach (var cubes in cubesSplit) 
        {
            var amount = int.Parse(cubes.Trim().Split(" ")[0]);
            var color = cubes.Trim().Split(" ")[1];
            switch (color )
            {
                case "red": numRedCubes = amount; break;
                case "green": numGreenCubes = amount; break;
                case "blue": numBlueCubes = amount; break;
            }
        }
        if (numRedCubes > 12 || numGreenCubes > 13 || numBlueCubes > 14)
        {
            gameValid = false;
            break;
        }
    }
    if (gameValid) sum += gameID;
    else invalidGames.Add(gameID);
}

Console.WriteLine($"Output Part 1: {sum}");
//invalidGames.ForEach(Console.WriteLine);

// -----------------------------------------
input = System.IO.File.ReadLines("S:\\git_repos\\adventofcode23\\adventofcode23-2\\input.txt");

sum = 0;
foreach (var line in input)
{
    var gameSplit = line.Split(":");
    int gameID = int.Parse(gameSplit[0].Split(" ")[1]);
    var setsSplit = gameSplit[1].Split(";");

    var numRedCubes = 0;
    var numGreenCubes = 0;
    var numBlueCubes = 0;

    foreach (var set in setsSplit)
    {
        var cubesSplit = set.Split(",");
        foreach (var cubes in cubesSplit)
        {
            var amount = int.Parse(cubes.Trim().Split(" ")[0]);
            var color = cubes.Trim().Split(" ")[1];
            // only keep max amount
            switch (color)
            {
                case "red": numRedCubes = (amount > numRedCubes) ? amount : numRedCubes; break;
                case "green": numGreenCubes = (amount > numGreenCubes) ? amount : numGreenCubes; break;
                case "blue": numBlueCubes = (amount > numBlueCubes) ? amount : numBlueCubes; break;
            }
        }
    
    }
    sum += numRedCubes*numGreenCubes*numBlueCubes;
}

Console.WriteLine($"Output Part 2: {sum}");