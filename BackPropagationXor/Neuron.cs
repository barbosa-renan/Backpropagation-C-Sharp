using System;

namespace BackPropagationXor
{
    public class Neuron
    {
        public double[] inputs = new double[2];
        public double[] weights = new double[2];
        public double error;

        private double biasWeight;

        private Random r = new Random();

        public double output
        {
            //Calcula a saída de um neurônio
            get { return Sigmoid.Output(weights[0] * inputs[0] + weights[1] * inputs[1] + biasWeight); }
        }

        public void RandomizeWeights()
        {
            weights[0] = r.NextDouble();
            weights[1] = r.NextDouble();
            biasWeight = r.NextDouble();
        }

        public void AdjustWeights()
        {
            weights[0] += error * inputs[0];
            weights[1] += error * inputs[1];
            biasWeight += error;
        }
    }
}