using System;

namespace BackPropagationXor
{
    class Program
    {
        static void Main(string[] args)
        {
            Train();
        }

        private static void Train()
        {
            // Valores de entrada
            double[,] inputs =
            {
                { 0, 0},
                { 0, 1},
                { 1, 0},
                { 1, 1}
            };

            // resultados esperados
            double[] results = { 0, 1, 1, 0 };

            // instanciar neurônios
            Neuron hiddenNeuron1 = new Neuron();
            Neuron hiddenNeuron2 = new Neuron();
            Neuron outputNeuron = new Neuron();

            // Criar pesos aleatórios
            hiddenNeuron1.RandomizeWeights();
            hiddenNeuron2.RandomizeWeights();
            outputNeuron.RandomizeWeights();

            int epoch = 0;

        Retry:
            epoch++;
            for (int i = 0; i < 4; i++)  // para resultados melhores o ideal é não treinar com apenas 1 exemplo
            {
                // 1) forward propagation (calcula a saída)
                hiddenNeuron1.inputs = new double[] { inputs[i, 0], inputs[i, 1] };
                hiddenNeuron2.inputs = new double[] { inputs[i, 0], inputs[i, 1] };

                outputNeuron.inputs = new double[] { hiddenNeuron1.output, hiddenNeuron2.output };

                Console.WriteLine("{0} xor {1} = {2}", inputs[i, 0], inputs[i, 1], outputNeuron.output);

                // 2) back propagation (ajusta os pesos)

                // ajusta o peso do neurônio de saída, com base em seu erro
                outputNeuron.error = Sigmoid.Derivative(outputNeuron.output) * (results[i] - outputNeuron.output);
                outputNeuron.AdjustWeights();

                // em seguida, ajusta os pesos dos neurônios ocultos, com base em seus erros
                hiddenNeuron1.error = Sigmoid.Derivative(hiddenNeuron1.output) * outputNeuron.error * outputNeuron.weights[0];
                hiddenNeuron2.error = Sigmoid.Derivative(hiddenNeuron2.output) * outputNeuron.error * outputNeuron.weights[1];

                hiddenNeuron1.AdjustWeights();
                hiddenNeuron2.AdjustWeights();
            }

            if (epoch < 2000)
                goto Retry;

            Console.ReadLine();
        }
    }
}
