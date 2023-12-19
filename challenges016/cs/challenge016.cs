using System;
using System.Text;

namespace _16SatasLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            //string letter = "hello,  how are you??     do you know if santa claus exists?  i really hope he does!  bye.  see ya later  ";
            string letter = "  Hi Santa claus. I'm a girl???     from Barcelona , Spain . please, send me a bike.  Is it possible?";
            Console.WriteLine(fixLetter(letter));
        }

        public static string fixLetter( string letter) {
            /*  Remove spaces at the beginning and end of the prase   +
                Remove multiple spaces and leave only one    +
                Leave a space after each comma and point  +
                Remove spaces before comma or point  +
                Questions must only end with a question mark  +
                The first letter of each sentence must be capitalized 1/2
                Put the word "Santa Claus" in uppercase if it appears in the letter  +
                Put a point at the end of the sentence if it does not have punctuation
            */

            letter = letter.Trim();

            while (letter.Contains("  "))
            {
                letter = letter.Replace("  ", " ");
            }

            if (letter.ToLower().Contains("santa claus")){
                letter = letter.ToLower().Replace("santa claus", "SANTA CLAUS");
            }

            string[] words = letter.Split(' ');
            StringBuilder buffer = new StringBuilder();
            foreach (var word in words) {   
                buffer.Append(word+' ');
            }

            int bufferLong = buffer.Length;

            for (int x = 0; x < bufferLong; x++)
            {
                if (buffer[x] == '.' || buffer[x] == ',') {
                    //space before . ,
                    if (buffer[x - 1] == ' ') {
                        buffer.Remove(x - 1, 1);
                        bufferLong--;
                        x--;
                    }
                }

                if (buffer[x] == '.' )
                {
                    //UpperCase
                    char upper = buffer[x + 2];
                    buffer.Remove(x + 2, 1);
                    buffer.Insert(x + 2, Char.ToUpper(upper));
                }

                if (buffer[x] == '?' && buffer[x + 1] == '?') {
                    buffer.Remove(x, 1);
                    bufferLong--;
                }
            }

            //Console.WriteLine(buffer);

            return buffer.ToString();

        }
    }
}
