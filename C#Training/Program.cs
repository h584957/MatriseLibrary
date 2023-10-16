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
           
            Vektor vec4a = new Vektor(new int[]{7,8,9});
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

            Matrise mat3 = MatriseMath.Add(mat1 , mat2);
            mat3.CheckAllRows();
            
            Console.WriteLine("Addisjon: mat1 + mat2 = mat3");
            
            mat3.PrintMat("mat3: ",true);            
            mat3 = MatriseMath.Substract(mat3, mat1);

            mat3.CheckAllRows();
            Console.WriteLine("Subtraksjon: mat3 - mat1 = mat3");
            mat3.PrintMat("mat3: ", true);

            Matrise mat4 = MatriseMath.ScalarMultiply(mat3,3);

            Console.WriteLine("Skalarprodukt: mat3 * 3 = mat4");

            mat4.CheckAllRows();
            mat4.PrintMat("mat4: ", true);

            Console.WriteLine("Multiply: mat a * mat b = mat c");
            Matrise a = new Matrise(3);
            Matrise b = new Matrise(2);
            
            Vektor a1 = new Vektor(new int[] { 3, 7});
            Vektor a2 = new Vektor(new int[] {-1, 5});
            Vektor a3 = new Vektor(new int[] { 2, 1});

            Vektor b1 = new Vektor(new int[] { 7, 1, 1, 2});
            Vektor b2 = new Vektor(new int[] { 3, 5, 4,-2});


            a.Add(a1);
            a.Add(a2);
            a.Add(a3);
            
            b.Add(b1);
            b.Add(b2);
            
            a.CheckAllRows();
            b.CheckAllRows();

            a.PrintMat("Mat a: ", true);
            b.PrintMat("Mat b: ", true);

            Matrise c = MatriseMath.Multiply(a, b);
            c.CheckAllRows();
            c.PrintMat("Mat c: ", true);
            Matrise d = MatriseMath.ScalarMultiply(c,10);
            d.CheckAllRows();
            d.PrintMat("mat d: ",true);

            Matrise aa = new Matrise(4);
            aa.fillMatrix(0,2);
            aa.CheckAllRows();
            aa.PrintMat("mat aa: ",true);

            Matrise bb = new Matrise(3);
            bb.fillMatrix(1,3);
            bb.CheckAllRows();
            bb.PrintMat("mat bb: ",true);
            
            Matrise cc = new Matrise(3);
            cc.fillMatrix(2,3);
            cc.CheckAllRows();
            cc.PrintMat("mat cc: ",true);

            Console.WriteLine("Expand: bb ++ cc => bb");
            bb.Expand(cc);
            bb.CheckAllRows();
            bb.PrintMat("mat bb: ",true);
            

            Matrise dd = new Matrise(3);
            dd.fillMatrix(5,3);
            dd.CheckAllRows();
            dd.PrintMat("mat dd: ",true);

            Console.WriteLine("Expand2: bb ++ dd => bb");
            bb.Expand2(dd);
            bb.CheckAllRows();
            bb.PrintMat("mat bb: ",true);


            Console.WriteLine("Expand: bb ++ dd => bb");
            bb.Expand(dd,3);
            bb.CheckAllRows();
            bb.PrintMat("mat cc: ",true);

            // test KroneckerProduct
            Console.WriteLine("KroneckerProduct: ");
            Matrise xx = new Matrise(2);
            Matrise yy = new Matrise(2);
            xx.fillMatrix(2,xx.RowsCount);
            yy.fillMatrix(2,xx.RowsCount);
            xx.CheckAllRows();
            yy.CheckAllRows();
            xx.PrintMat("Mat xx: ",true);
            yy.PrintMat("Mat yy: ",true);

            Matrise zz = MatriseMath.KroneckerProduct(xx,yy);
            zz.CheckAllRows();
            zz.PrintMat("Mat zz: ", true);

            
        
        }
    }
}
