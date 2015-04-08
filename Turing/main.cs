using System.IO;
using System;

namespace Turing
{
    class Program
    {
        private static NeuralNetwork[] networks;
        private const int INPUTNUM = 12; // Logic gate input
        private const int HIDDENNUM = 50; 
        private const int OUTPUTNUM = 64; // Memory is 8 bytes
        private const int POPULATION = 100;
        
        private static Random random = new Random();
        
        static void Main()
        {
            // Create a population of neural networks
            networks = new NeuralNetwork[POPULATION];
            for (int i = 0; i < POPULATION; i++) {
                networks[i] = new NeuralNetwork(INPUTNUM, HIDDENNUM, OUTPUTNUM, random);
            }
            
        }
    }
}