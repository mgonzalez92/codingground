using System.IO;
using System;

namespace Turing
{
    class NeuralNetwork
    {
        // Number of neurons
        public int inputNum;
        public int hiddenNum;
        public int outputNum;
        
        // Neuron values
        public double[] inputValues;
        public double[] hiddenValues;
        public double[] outputValues;
        
        // Neuron weights
        public double[][] hiddenWeights;
        public double[] hiddenBiases;
        public double[][] outputWeights;
        public double[] outputBiases;
        
        public NeuralNetwork(int inputNum, int hiddenNum, int outputNum, Random random)
        {
            // Set number of neurons
            this.inputNum = inputNum;
            this.hiddenNum = hiddenNum;
            this.outputNum = outputNum;
            
            // Initialize neuron value arrays
            this.inputValues = new double[this.inputNum];
            this.hiddenValues = new double[this.hiddenNum];
            this.outputValues = new double[this.outputNum];
            
            // Initialize neuron weights arrays
            this.hiddenWeights = new double[this.hiddenNum][];
            this.hiddenBiases = new double[this.hiddenNum];
            for (int i = 0; i < this.hiddenNum; i++) {
                this.hiddenWeights[i] = new double[this.inputNum];
                for (int j = 0; j < this.inputNum; j++) {
                    this.hiddenWeights[i][j] = random.NextDouble();
                }
                this.hiddenBiases[i] = random.NextDouble();
            }
            this.outputWeights = new double[this.outputNum][];
            this.outputBiases = new double[this.outputNum];
            for (int i = 0; i < this.outputNum; i++) {
                this.outputWeights[i] = new double[this.hiddenNum];
                for (int j = 0; j < this.hiddenNum; j++) {
                    this.outputWeights[i][j] = random.NextDouble();
                }
                this.outputBiases[i] = random.NextDouble();
            }
        }
    }
}