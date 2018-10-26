using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static List<string> words = new List<string>();

        public static string answerWord;

        public static List<char> placeholder = new List<char>();

        public static int bodySteps = 0;

        public static List<char> guesses = new List<char>();

        static void Main(string[] args)
        {
            answerWord = GenerateWord();
            foreach (char c in answerWord)
            {
                placeholder.Add('*');
            }

            while (bodySteps < 6)
            {
                drawUI();

                makeAGuess(Console.ReadKey().KeyChar);
            }

            if (bodySteps == 6)
            {
                GameOver();
            }


            Console.ReadKey();
        }

        public static string GenerateWord()
        {
            Random rnd = new Random();

            words.Add("abacaxi");
            words.Add("anjo");
            words.Add("america");
            words.Add("azul");
            words.Add("amarelo");
            words.Add("bar");
            words.Add("bota");
            words.Add("bolo");
            words.Add("banana");

            return words[rnd.Next(0, words.Count)];
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

            for (int c = 0; c < answerWord.Length; c++)
            {
                if (guess == answerWord[c])
                {
                    placeholder[c] = answerWord[c];
                }
            }

            if (!answerWord.Contains(guess))
            {
                bodySteps++;
            }

            guesses.Add(guess);

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

            Console.WriteLine("\n\nResposta: " + s);

            string g = "";
            foreach (char j in guesses)
            {
                g += j;
            }
            Console.WriteLine("\nPalpites anteriores: " + g);
            Console.WriteLine("\n\nDigite uma letra como palpite:");



        }

        public static void GameOver()
        {
            Console.Clear();

            drawBody();

            Console.WriteLine("\n\nGAME OVER!");
        }
    }
}
