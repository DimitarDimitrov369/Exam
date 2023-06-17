using System.Collections.Generic;
using System;

Queue<int> tools = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

Stack<int> substances = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

List<int> challenges = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

while (challenges.Any())
{
    int tool = tools.Dequeue();
    int substance = substances.Pop();
    int result = tool * substance;

    if (challenges.Contains(result))
    {
        challenges.Remove(result);
    }

    else
    {
        tools.Enqueue(tool + 1);
        int newSubstance = substance - 1;
        if (newSubstance != 0)
        {
            substances.Push(newSubstance);
        }
    }

    if (!tools.Any() || !substances.Any())
    {
        if (challenges.Any())
        {
            Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            if (tools.Any())
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }
            if (substances.Any())
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }
            if (challenges.Any())
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
            return;
        }
    }
}

Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
if (tools.Any())
{
    Console.WriteLine($"Tools: {string.Join(", ", tools)}");
}
if (substances.Any())
{
    Console.WriteLine($"Substances: {string.Join(", ", substances)}");
}