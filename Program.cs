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

        public static int bodySteps = 0;
        public static string placeholder;

        public static string guesses;

        static void Main(string[] args)
        {
            answerWord = GenerateWord();
            do
            {
                drawUI();

                Console.WriteLine("\n\nDigite uma letra como palpite:");
                char _guess = Console.ReadKey().KeyChar;

                do
                {
                    Console.WriteLine("\nVocê já fez esse palpite! Escolha outra letra:");
                    _guess = Console.ReadKey().KeyChar;
                }
                while (guesses.Contains(_guess));

                makeAGuess(_guess);
            } while (bodySteps < 6);
            Console.ReadKey();
        }

        public static string GenerateWord()
        {
            Random rnd = new Random();

            words.Add("Abacaxi");
            words.Add("Anjo");
            words.Add("America");
            words.Add("Azul");
            words.Add("Amarelo");
            words.Add("Bar");
            words.Add("Bota");
            words.Add("Bolo");
            words.Add("Banana");


            var ret = words[rnd.Next(0, words.Count)];

            foreach (char c in ret)
            {
                placeholder += "*";
            }

            guesses = "";

            return ret;
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

            guesses += " " + guess.ToString().ToUpper();
            string aux = "";

            foreach (char c in answerWord)
            {
                if (guess == c)
                {
                    aux += guess;
                }
                else if (guesses.Contains(c))
                {
                    aux += c;
                }
                else
                {
                    aux += '*';
                }
            }

            placeholder = aux;

        }

        public static void drawUI()
        {
            Console.Clear();

            drawBody();

            Console.WriteLine("\n\nResposta: " + placeholder);
            Console.WriteLine("\nPalpites anteriores: " + guesses);



        }
    }
}
