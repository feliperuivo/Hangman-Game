using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Game
    {
        public static List<string> words = new List<string>();

        public static string answerWord;

        public static int rightGuesses = 0;

        public static List<char> placeholder = new List<char>();

        public static int bodySteps = 0;

        public static List<char> guesses = new List<char>();

        static void Main(string[] args)
        {
            GenerateWord();



            while (bodySteps < 6 && rightGuesses < answerWord.Length)
            {
                drawUI();

                makeAGuess(Console.ReadKey().KeyChar);
            }

            if (rightGuesses == answerWord.Length)
            {
                YouWin();
            }

            if (bodySteps == 6)
            {
                GameOver();
            }


            Console.ReadKey();
        }

        public static void GenerateWord()
        {
            Random rnd = new Random();

            words.Add("anthem");
            words.Add("america");
            words.Add("beach");
            words.Add("blue");
            words.Add("caramel");
            words.Add("camp");
            words.Add("dice");
            words.Add("dandelion");
            words.Add("escape");
            words.Add("empty");
            words.Add("faith");
            words.Add("forearm");
            words.Add("game");
            words.Add("gore");
            words.Add("help");
            words.Add("house");
            words.Add("integral");
            words.Add("impossible");
            words.Add("june");
            words.Add("jump");
            words.Add("kilometer");
            words.Add("kin");
            words.Add("loop");
            words.Add("lamp");
            words.Add("monkey");
            words.Add("mayo");
            words.Add("navy");
            words.Add("nothing");
            words.Add("orange");
            words.Add("obscure");
            words.Add("purple");
            words.Add("parallel");
            words.Add("quota");
            words.Add("quality");
            words.Add("rupture");
            words.Add("ramen");
            words.Add("suspect");
            words.Add("simple");
            words.Add("trauma");
            words.Add("tomb");
            words.Add("unusual");
            words.Add("unless");
            words.Add("vampire");
            words.Add("vault");
            words.Add("whiskey");
            words.Add("winner");
            words.Add("xerox");
            words.Add("xanthic");
            words.Add("yellow");
            words.Add("yesterday");
            words.Add("zoo");
            words.Add("zombie");

            answerWord = words[rnd.Next(0, words.Count)];

            foreach (char c in answerWord)
            {
                placeholder.Add('*');
            }
        }

        public static void drawBody()
        {


            string head = "O", body = "|", lArm = "/", rArm = "\\", lLeg = "/", rLeg = "\\";

            switch (bodySteps)
            {
                case 0:
                    head = " "; body = " "; lArm = " "; rArm = " "; lLeg = " "; rLeg = " ";
                    break;

                case 1:
                    body = " "; lArm = " "; rArm = " "; lLeg = " "; rLeg = " ";
                    break;
                case 2:
                    lArm = " "; rArm = " "; lLeg = " "; rLeg = " ";
                    break;
                case 3:
                    rArm = " "; lLeg = " "; rLeg = " ";
                    break;
                case 4:
                    lLeg = " "; rLeg = " ";
                    break;
                case 5:
                    rLeg = " ";
                    break;
                case 6:
                    break;

                default:
                    break;
            }

            string complete = string.Format("\n |----------| \n |          | \n |          {0} \n |         {2}{1}{3} \n |         {4} {5} \n_|_", head, body, lArm, rArm, lLeg, rLeg);

            Console.WriteLine(complete);
        }

        public static void makeAGuess(char guess)
        {
            if (!guesses.Contains(guess))
            {
                guesses.Add(guess);

                if (answerWord.Contains(guess))
                {
                    for (int c = 0; c < answerWord.Length; c++)
                    {
                        if (guess == answerWord[c])
                        {
                            placeholder[c] = answerWord[c];
                        }
                    }

                    rightGuesses++;
                }
                else if (!answerWord.Contains(guess))
                {
                    bodySteps++;
                }
            }

        }

        public static void drawUI()
        {
            Console.Clear();

            drawBody();

            string s = "";
            foreach (char i in placeholder)
            {
                s += i;
            }

            Console.WriteLine("\n\nAnswer: " + s);

            string g = "";
            foreach (char j in guesses)
            {
                g += j;
            }

            Console.WriteLine("\n\nPress a key to make a guess.");
            Console.WriteLine("\nGuesses: " + g);




        }

        public static void GameOver()
        {
            Console.Clear();

            drawBody();

            Console.WriteLine("\n\nGAME OVER!");
        }

        public static void YouWin()
        {
            Console.Clear();

            Console.WriteLine("\n\nYOU WIN!");
        }

    }
}
