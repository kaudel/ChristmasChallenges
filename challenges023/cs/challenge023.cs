using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SantaClausCompiler
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Command> commands = new List<Command>();
            commands.Add(new Command("MOV 5", "V00"));
            commands.Add(new Command("MOV 10", "V01"));
            commands.Add(new Command("DEC V00", ""));
            commands.Add(new Command("ADD V00", "V01"));

            //commands.Add(new Command("MOV 10", "V100"));
            //commands.Add(new Command("DEC V00", ""));
            //commands.Add(new Command("INC V01", ""));
            //commands.Add(new Command("JMP 1", ""));
            //commands.Add(new Command("INC V06", ""));

            Console.WriteLine( string.Join(",", ExecuteCommands(commands)));
        }

        static int[] ExecuteCommands(List<Command> command )
        {
            //MOV Vxx,Vyy: copies the value from register Vxx to register Vyy;
            //MOV n,Vxx: assign the numeric constant n to register Vxx (overwrite if already has a value);
            //ADD Vxx, Vyy: calculates(Vxx + Vyy) and stores the result in Vxx;
            //DEC Vxx: decrements Vxx value by 1.
            //INC Vxx: increments Vxx value by 1.
            //JMP i: jumps to instruction number i if V00 is different to 0.
            //i is guaranteed to be a valid instruction number and 0 would be the first command.

            //The CPU has available 8 registers, which are named V00..V07
            int[] CPURegisters = new int[8];

            for (int x = 0; x < command.Count; x++) {
                Command item = command[x];                
                string cmd = item.command.Substring(0, 3);
                int CPURegisterIndexX = 0;
                int CPURegisterIndexY = 0;
                switch (cmd) {
                    case "MOV":
                        Regex re = new Regex(@"\d+");
                        Match m = re.Match(item.command);

                        if (m.Success)
                        {
                            int value = Convert.ToInt32(item.command.Substring(4, (item.command.Length - 4)));
                            int CPURegisterIndex = Convert.ToInt32(item.position.Substring(2, 1));
                            //256 bytes  0 -->255: 280 -256= 24
                            if (value > 255)
                                value -= 255;

                            CPURegisters[CPURegisterIndex] = value;
                        }
                        else {
                            CPURegisterIndexX = GetIndex(item, "X");
                            CPURegisterIndexY = GetIndex(item, "Y");
                            // x -->y
                            CPURegisters[CPURegisterIndexY] = CPURegisters[CPURegisterIndexX];
                        }
                        break;
                    case "ADD":
                        CPURegisterIndexX = GetIndex(item, "X"); 
                        CPURegisterIndexY = GetIndex(item, "Y"); 
                        int sumXY = CPURegisters[CPURegisterIndexX] + CPURegisters[CPURegisterIndexY];

                        if (sumXY > 255)
                            sumXY = sumXY - 255;
                        CPURegisters[CPURegisterIndexX] = sumXY;                       
                        break;
                    case "DEC":
                        //Dec decrements 1 to the current value in the record
                        CPURegisterIndexX = GetIndex(item, "X");

                        if (CPURegisters[CPURegisterIndexX] == 0)
                            CPURegisters[CPURegisterIndexX] = 255;
                        else
                            CPURegisters[CPURegisterIndexX] = CPURegisters[CPURegisterIndexX] - 1;
                        break;
                    case "INC":
                        //INC increments current value +1
                        CPURegisterIndexX = GetIndex(item, "X");
                        if (CPURegisters[CPURegisterIndexX] == 255)
                            CPURegisters[CPURegisterIndexX] = 0;
                        else
                            CPURegisters[CPURegisterIndexX] = CPURegisters[CPURegisterIndexX] + 1;

                        break;
                    case "JMP":
                        if (CPURegisters[0] != 0) {
                            int value = Convert.ToInt32(item.command.Substring(4, (item.command.Length - 4)));
                            x = value-1;
                        }
                        break;
                }
            }
            return CPURegisters;
        }

        static int GetIndex(Command command, string indexName) {
            if (indexName == "X")
                return Convert.ToInt32(command.command.Substring(6, 1));
            else
                return Convert.ToInt32(command.position.Substring(2, 1));
        }
    }

    public class Command
    {
        public string command, position;

        public Command(string Command, string Position)
        {
            this.command = Command;
            this.position = Position;
        }
    }
}

