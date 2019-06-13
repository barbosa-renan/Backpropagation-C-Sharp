using System;

namespace BackPropagationXor
{
    public class Sigmoid
    {
        //função sigmóide
        public static double Output(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        // derivada de output, também conhecido como df / dx
        public static double Derivative(double x)
        {
            return x * (1 - x);
        }
    }
}
