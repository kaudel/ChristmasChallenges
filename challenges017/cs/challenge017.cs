using System;
using System.Collections.Generic;

namespace _17CarryngGifts
{
    /*Write a function that groups the gifts in bags and returns an array with the names of the gifts of each bag. 
     * To group the gifts, the names are separated by spaces (the space does not count as weight).
     * But keep in mind that if the weight of the gifts of a bag exceeds the maximum weight, 
     * the last gift of the bag must be separated and placed in the next bag.
     */

    class Program
    {
        static void Main(string[] args)
        {

            string[] gifts = { "game", "bike", "book", "toy","ferrocarril" };
            //string[] gifts = { "ferrocarril", "autocontrol" };
            Console.WriteLine( string.Join(",", carryGifts(gifts, 10)));
        }

        static string[] carryGifts(string[] toys, int MaxWeight) {

            int currentBagSize = 0;
            string currentBag = "";
            List<string> bags = new List<string>();
            for (int x = 0; x < toys.Length; x++) {
                if ((toys[x].Length + currentBagSize) <= MaxWeight)
                {
                    currentBagSize += toys[x].Length;
                    currentBag = currentBag + " " + toys[x];
                }

                if ((x < toys.Length - 1) && ((toys[x + 1].Length + currentBagSize) <= MaxWeight))
                {
                    bags.Add(currentBag);
                    currentBagSize = 0;
                    currentBag = "";
                }
                else if ((toys[x].Length + currentBagSize) <= MaxWeight) {
                    bags.Add(currentBag);
                }
            }

            return bags.ToArray();
        }
    }
}
