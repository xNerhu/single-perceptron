using System;

namespace SinglePerceptron {
    public class DataSet {
        public double[] Inputs;
        public double Output;

        public DataSet(double[] inputs, double output) {
            Inputs = inputs;
            Output = output;
        }

        public void Print(Perceptron p) {
            double guess = p.FeedForwad(Inputs);
            double guessRounded = Math.Round(guess);
            double error = Output - guess;
            bool isCorrect = guessRounded == Output;

            PrintColored("Inputs: [", ConsoleColor.White);
            for (int i = 0; i < Inputs.Length; i++) {
                string str = Inputs[i].ToString();
                if (i < Inputs.Length - 1) {
                    str += ",";
                }
                PrintColored(str.ToString(), ConsoleColor.Cyan);
            }

            PrintColored("]\nGuess: ", ConsoleColor.White);
            PrintColored(guessRounded.ToString(), isCorrect ? ConsoleColor.Green : ConsoleColor.DarkRed);
            if (!isCorrect) {
                PrintColored(string.Format(" ({0})", Output), ConsoleColor.Yellow);
            }

            PrintColored("\nError: ", ConsoleColor.White);
            PrintColored(error + "\n\n", isCorrect ? ConsoleColor.Green : ConsoleColor.Red);
        }

        static void PrintColored(string str, ConsoleColor color) {
            Console.ForegroundColor = color;
            Console.Write(str);
        }
    }

    public class TrainingData {
        public static DataSet[] And = {
            new DataSet(new double[] {
                0,
                0,
            }, 0),
            new DataSet(new double[] {
                1,
                0,
            }, 0),
            new DataSet(new double[] {
                0,
                1,
            }, 0),
            new DataSet(new double[] {
                1,
                1,
            }, 1),
        };

        public static DataSet[] Or = {
            new DataSet(new double[] {
                0,
                0,
            }, 0),
            new DataSet(new double[] {
                1,
                0,
            }, 1),
            new DataSet(new double[] {
                0,
                1,
            }, 1),
            new DataSet(new double[] {
                1,
                1,
            }, 1),
        };

        public static DataSet[] Implication = {
            new DataSet(new double[] {
                0,
                0,
            }, 1),
            new DataSet(new double[] {
                0,
                1,
            }, 1),
            new DataSet(new double[] {
                1,
                0,
            }, 0),
            new DataSet(new double[] {
                1,
                1,
            }, 1),
        };
    }
}
