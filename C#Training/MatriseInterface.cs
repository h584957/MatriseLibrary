using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Training
{
    internal interface MatriseInterface
    {

        // Prints matrix with info
        void PrintMat(string name,bool moreInfo);

        // Force set matrix size
        void setRows(int size);

        // Prints matrix
        void PrintMat(string name);

        // Remove row at given index
        void RemoveRow(int index);

        // Checks if all rows are equal length
        void CheckAllRows();

        // Adds vector at the bottom of the matrix
        void Add(Vektor vec);

        // Fills matris with given number and given Vector size
        void fillMatrix(int numb, int m);

    }
}
