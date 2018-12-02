using System;

namespace SinglePerceptron {
    class Program {
        static void Main(string[] args) {
            Perceptron p = new Perceptron(2);
            DataSet[] data = TrainingData.And;

            p.TrainWithDataSet(data);

            for (int i = 0; i < data.Length; i++) {
                data[i].Print(p);
            }
        }
    }
}