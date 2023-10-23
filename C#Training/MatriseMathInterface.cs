using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Training
{
    internal interface MatriseMathInterface
    {
        // Multiply two matrices : A*B=C
        Matrise Multiply(Matrise a, Matrise b);

        // Multiply a scalar to a matrix : A*B = C
        Matrise ScalarMultiply(Matrise a, int scalar);

        // Adds two matrices togheter : scalar*A 
        Matrise Add(Matrise a, Matrise b);

        // Subtracts two matrixes : A-B = C
        Matrise Substract(Matrise a,Matrise b);

        // Kronecker Product : A x B = C
        Matrise KroneckerProduct(Matrise a, Matrise b);

    }
}
