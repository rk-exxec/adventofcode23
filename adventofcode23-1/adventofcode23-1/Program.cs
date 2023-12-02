
using System.Text.RegularExpressions;

Console.WriteLine("Advent of code 2023 - Day 1");

var input = System.IO.File.ReadLines("S:\\git_repos\\adventofcode23\\adventofcode23-1\\input.txt");

int sum = 0;
foreach (var line in input)
{
    if (string.IsNullOrEmpty(line)) continue;
    int firstDigit = -1, lastDigit = -1;

    foreach (char symbol in line)
    {
        if ('0' <= symbol && symbol <= '9')
        {
            var number = symbol - '0';
            if (firstDigit == -1) firstDigit = number;
            lastDigit = number; 
        }
        
    }
    sum += firstDigit * 10 + lastDigit;
}

Console.WriteLine($"Output Part 1: {sum}");

//------------------------------------------

input = System.IO.File.ReadLines("S:\\git_repos\\adventofcode23\\adventofcode23-1\\input.txt");
//input = @"two1nine
//eightwothree
//abcone2threexyz
//xtwone3four
//4nineeightseven2
//zoneight234
//7pqrstsixteen
//".Split('\n');

sum = 0;
foreach (var line in input)
{
    if (string.IsNullOrEmpty(line)) continue;
    int firstDigit = -1, lastDigit = -1;

    var numberWordMatches = Regex.Matches(line, "(?:one|two|three|four|five|six|seven|eight|nine|[0-9])").ToList();
    var numberWordDict = new Dictionary<string, int>() { 
        { "one", 1 },   { "two", 2 },   { "three", 3 }, { "four", 4 },  { "five", 5 },  { "six", 6 },   { "seven", 7 }, { "eight", 8 }, { "nine", 9 },
        {"1",1 },       {"2",2 },       {"3",3 },       {"4",4 },       {"5",5 },       {"6",6 },       {"7",7 },       {"8",8 },       {"9",9 } 
    };


    firstDigit = numberWordDict[numberWordMatches.First().Value];
    lastDigit = numberWordDict[numberWordMatches.Last().Value];
    var value = firstDigit * 10 + lastDigit;
    //Console.WriteLine(value );
    sum += value;
}

Console.WriteLine($"Output Part 2: {sum}");