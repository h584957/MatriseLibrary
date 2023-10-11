using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Training
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            int[] row1 = new int[]{1,2,3};
            int[] row2 = new int[]{4,5,6};
            int[] row3 = new int[]{7,8,9};

            Vektor vec1 = new Vektor(new int[]{1,2,3});
            Vektor vec2 = new Vektor(new int[]{4,5,6});
            Vektor vec3 = new Vektor(new int[]{7,8,9});
            Vektor vec4 = new Vektor(new int[]{7,8,9});
            Vektor[] vecArr = new Vektor[]{vec1,vec2,vec3,vec4};

            Matrise mat1 = new Matrise(3);
            Matrise mat2 = new Matrise(vecArr);

            mat1.Add(new Vektor(new int[]{1,2,3}));
            mat1.Add(new Vektor(new int[]{1,2,3}));
            mat1.Add(new Vektor(new int[]{1,2,3}));
            mat1.Add(new Vektor(new int[]{1,2,3}));
            
            mat1.CheckAllRows();
            mat2.CheckAllRows();
            
            mat1.PrintMat("mat1: ",true);
            mat2.PrintMat("mat2: ",true);

            Matrise mat3 = MatriseMath.addisjon(mat1 , mat2);
            mat3.CheckAllRows();
            mat1.CheckAllRows();
            Console.WriteLine("Add: mat1 + mat2 = mat3");
            mat3.PrintMat("mat3: ",true);
            mat1.PrintMat("mat1: ",true);
            mat3 = MatriseMath.substraksjon(mat3, mat1);

            mat3.CheckAllRows();
            Console.WriteLine("Subtract: mat3 - mat1 = mat3");
            mat3.PrintMat("mat3: ", true);

            Matrise mat4 = MatriseMath.SkalarMultiplikasjon(mat3,3);

            mat4.CheckAllRows();
            mat4.PrintMat("mat4: ", true);

            mat3.CheckAllRows();
            mat3.PrintMat("mat3: ", true);



        }
    }
}
