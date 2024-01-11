Console.WriteLine("Advent of code 2023 - Day 4");

var filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString(), "input.txt");
string[] input = File.ReadLines(filePath).ToArray();

uint total_sum = 0;
foreach (var line in input)
{
    var card_num_splt = line.Split(":");
    var num_split = card_num_splt[1].Split("|");
    int[] winning_numbers = num_split[0].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    int[] test_numbers = num_split[1].Trim(). Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    uint cur_value = 0;
    foreach (var num in test_numbers)
    {
        if (winning_numbers.Contains(num))
        {
            if (cur_value == 0) cur_value = 1;
            else cur_value *= 2;
        }
    }
    total_sum += cur_value;
}

Console.WriteLine($"Output Part 1: {total_sum}");


input = File.ReadLines(filePath).ToArray();

total_sum = 0;

var cardsList = new List<ScratchCard>();

foreach (var line in input)
{
    cardsList.Add(new(line));
}

int[] cardCounts = new int[cardsList.Count];
Array.Fill(cardCounts, 1);

for (int i=0; i < cardsList.Count; i++)
{
    for (int j=i+1; j<(i+cardsList[i].cardNumbersWon+1);j++)
    {
        cardCounts[j] += cardCounts[i];
    }
}

Console.WriteLine($"Output Part 2: {cardCounts.Sum()}");


class ScratchCard
{
    public int number;
    public int[] winningNumbers;
    public int[] testNumbers;
    public int cardNumbersWon;
    public ScratchCard(string contents)
    {
        var card_num_splt = contents.Split(":");
        number = int.Parse(card_num_splt[0].Split().Last());
        var num_split = card_num_splt[1].Split("|");
        winningNumbers = num_split[0].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        testNumbers = num_split[1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        cardNumbersWon = 0;
        foreach (var num in testNumbers)
        {
            if (winningNumbers.Contains(num))
            {
                cardNumbersWon++;
            }
        }
    }
}