using System;

namespace SinglePerceptron {
    public class Perceptron {
        double[] Weights;
        double Bias;
        double LearningRate;

        public Perceptron(int inputNodes, double lr = 0.1) {
            Weights = new double[inputNodes];
            LearningRate = lr;
            // Initialize the weights randomly
            for (int i = 0; i < Weights.Length; i++) {
                Weights[i] = GetRandom(-1, 1);
            }
            // Including the bias
            Bias = GetRandom(-1, 1);
        }

        /// <summary>
        /// Guesses an output using Feedforwad algorithm
        /// </summary>
        public double FeedForwad(double[] inputs) {
            double sum = 0;
            // Sum all the weights multiplied by the corresponding input
            // Σ(wx * ix)
            for (int i = 0; i < Weights.Length; i++) {
                sum += inputs[i] * Weights[i];
            }
            // Add the sum with bias and compress it with the activation function
            return Sigmoid(sum + Bias);
        }

        /// <summary>
        /// Trains the perceptron
        /// </summary>
        public void Train(double[] inputs, double answer) {
            double guess = FeedForwad(inputs);
            double error = answer - guess;
            // Adjust the weights
            for (int i = 0; i < Weights.Length; i++) {
                Weights[i] += error * inputs[i] * LearningRate;
            }
            // Adjust the bias
            Bias += error * LearningRate;
        }

        /// <summary>
        /// Trains the perceptron with given dataset
        /// </summary>
        /// <param name="num">How many times the perceptron will be trained</param>
        public void TrainWithDataSet(DataSet[] data, int num = 50000) {
            Random rnd = new Random();

            for (int i = 0; i < num; i++) {
                int index = rnd.Next(0, data.Length);
                Train(data[index].Inputs, data[index].Output);
            }
        }
        
        /// <summary>
        /// An activation function
        /// </summary>
        static double Sigmoid(double x) {
            double k = Math.Exp(x);
            return k / (1 + k);
        }

        static double GetRandom(double min, double max) {
            Random rand = new Random();
            return min + rand.NextDouble() * (max - min);
        }
    }
}
