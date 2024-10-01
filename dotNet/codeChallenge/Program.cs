using System;

namespace solidTest;

public class Program
{
    protected Program()
    {
    }

    static void Main(string[] args)
    {
        Shuffle(new int[] { 1, 2, 3, 4, 5, 6, });
    }

    private static int[] Shuffle(int[] originalDeck)
    {
        var rand = new Random();
        int[] shuffleDeck = new int[originalDeck.Length];
        originalDeck.ToList().ForEach(element => Console.Write($" ==> {element}"));
        //Generate randomItems 
        for (int i = 0; i < originalDeck.Length; i++)
        {
            //Generate RandomItem to assign, if does not exist in shuffleDeck, into shuffleDeck
            int randomItem = rand.Next(1, originalDeck.Length);
            Console.WriteLine($"randomItem: {randomItem}\n");
            //RandomItem different from Current Value in Deck[i]?
            if (randomItem != originalDeck[i])
            {   //Does randomItem already exists in shuffleDeck?
                int result = Array.Find(shuffleDeck, x => x.Equals(randomItem));
                if (result == 0)
                {
                    shuffleDeck[i] = randomItem;
                }
                else
                {
                    shuffleDeck[i] = ValidateRandomItem(rand.Next(1, originalDeck.Length + 1), shuffleDeck);
                }
            }
            else
            {
                shuffleDeck[i] = ValidateRandomItem(rand.Next(1, originalDeck.Length + 1), shuffleDeck);
            }
        }
        Console.WriteLine("\n");
        shuffleDeck.ToList().ForEach(element => Console.Write($" ==> {element}"));
        return shuffleDeck;
    }

    private static int ValidateRandomItem(int randomItem, int[] shuffleDeck)
    {
        Console.WriteLine($"randomItem: {randomItem}::60\n");
        int result = 0;
        int exist = Array.Find(shuffleDeck, x => x.Equals(randomItem));
        if (exist == 0)
        {
            result = randomItem;
        }
        else
        {
            var recursiveRandomItem = new Random();
            result = ValidateRandomItem(recursiveRandomItem.Next(1, shuffleDeck.Length + 1), shuffleDeck);
        }

        return result;
    }

}