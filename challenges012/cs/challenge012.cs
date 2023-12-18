using System;
using System.Collections.Generic;

namespace _12ElectricSleighs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Sleigh> sleighsList = new List<Sleigh>
            {
                new Sleigh("Gorusuke", 0.3),  //->9W
                new Sleigh("Madeval", 0.5),   //->15W  *
                new Sleigh("lolivier", 0.7),  //->21W
                new Sleigh("Hyuuh", 1)        //->30W
            };

            Console.WriteLine( selectSleigh(30, sleighsList));

        }

        static string selectSleigh(int distance, List<Sleigh> sleighs) {
            //battery is just 20W

            Sleigh finalItem = new Sleigh();
            foreach (Sleigh item in sleighs) {
                if (((item.Consumption * distance) < 20) && ((item.Consumption * distance) > finalItem.Consumption) )
                {
                    finalItem.Consumption = item.Consumption * distance;
                    finalItem.Name = item.Name;
                }
            }

            return finalItem.Name;
        }
    }

    public class Sleigh {
        public string Name;
        public double Consumption;

        public Sleigh()
        {
        }

        public Sleigh(string name, double consumption)
        {
            this.Name = name;
            this.Consumption = consumption;
        }
    }
}


