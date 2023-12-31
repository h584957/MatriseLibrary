﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
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

            Console.WriteLine("Subtraksjon: mat3 - mat1 = mat3");
            mat3.PrintMat("mat3: ", true);

            Matrise mat4 = MatriseMath.ScalarMultiply(mat3,3);

            Console.WriteLine("Skalarprodukt: mat3 * 3 = mat4");

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

            a.PrintMat("Mat a: ", true);
            b.PrintMat("Mat b: ", true);
            
            // test multiply
            Matrise c = MatriseMath.Multiply(a, b);
        
            c.PrintMat("Mat c: ", true);

            // test scalarMultiply
            Matrise d = MatriseMath.ScalarMultiply(c,10);
            
            d.PrintMat("mat d: ",true);

            // test fillMatrix 
            Matrise aa = new Matrise(4);
            aa.fillMatrix(0,2);
            aa.PrintMat("mat aa: ",true);

            Matrise bb = new Matrise(3);
            bb.fillMatrix(1,3);
            bb.PrintMat("mat bb: ",true);
            
            //test Expand
            Console.WriteLine("Expand(Mat a, int row)");
            Console.WriteLine("BB Expand CC -> BBCC");
            Matrise cc = new Matrise(2);
            cc.PrintMat("Mat cc: ",true);
            bb.PrintMat("mat bb: ",true);
            bb.Expand(cc,0);
            bb.PrintMat("bb expand cc: ",true);
 
            Console.WriteLine("CC Expand BB -> CCBB");
            cc.PrintMat("cc: ",true);
            bb.PrintMat("bb: ",true);
            cc.Expand(bb,0);
            cc.PrintMat("cc expand bb: ",true);

            // test KroneckerProduct
            Console.WriteLine("KroneckerProduct: ");
            Matrise xx = new Matrise(2);
            xx.Add(new Vektor(new int[]{1,-4,7}));
            xx.Add(new Vektor(new int[]{-2,3,3}));

            Matrise yy = new Matrise(4);
            yy.Add(new Vektor(new int[]{8,-9,-6,5}));
            yy.Add(new Vektor(new int[]{1,-3,-4,7}));
            yy.Add(new Vektor(new int[]{2,8,-8,-3}));
            yy.Add(new Vektor(new int[]{1,2,-5,-1}));
            
           
            xx.PrintMat("Mat xx: ",true);
            yy.PrintMat("Mat yy: ",true);

            Matrise zz = MatriseMath.KroneckerProduct(xx,yy);
            zz.PrintMat("Mat Kronecker: ", true);

            // test hadamardProduct
            Matrise g = new Matrise(3);
            Matrise h = new Matrise(3);

            g.fillMatrix(2,g.RowsCount);
            g.PrintMat("Mat g: ",true);
            h.fillMatrix(2,h.RowsCount);
            h.PrintMat("Mat h: ",true);

            Matrise i = MatriseMath.HadamardProduct(g,h);
            i.PrintMat("HadamardProduct: ",true);

            // test DirectSum 
            Matrise j = new Matrise(2);
            Matrise k = new Matrise(3);

            j.fillMatrix(3,j.RowsCount);
            j.PrintMat("Mat j: ",true);
            k.fillMatrix(2,k.RowsCount);
            k.PrintMat("Mat k: ",true);

            Matrise DS = MatriseMath.DirectSum(j,k);
            DS.PrintMat("DirectSum: ",true);

            // test Transpose
            Matrise tp = new Matrise(2);
            tp.Add(new Vektor(new int[]{1,3,7}));
            tp.Add(new Vektor(new int[]{2,4,6}));

            tp.PrintMat("tp: ",true);
            tp.Transpose();
            tp.PrintMat("tpTransposed: ",true);

            Vektor ac = new Vektor(new int[]{1,2,3});
            Vektor bc = new Vektor(new int[]{1,1,1});
            Console.WriteLine();
            ac.PrintVec("Vektor AC: ");
            Console.WriteLine();
            bc.PrintVec("Vektor BC: ");
            Console.WriteLine();
            Console.WriteLine("DotProduct testing: ");
            Console.WriteLine("DotProduct => Vec AC dot Vec BC: "+ MatriseMath.DotProduct(ac,bc));

            Matrise dp = new Matrise(3);
            dp.Add(ac);
            dp.Add(bc);
            dp.Add(bc);
            dp.PrintMat("Mat ",true);
            dp.PrintMat("Mat DP",true);

            Vektor dpSvar = MatriseMath.DotProduct(ac,dp);
            Console.WriteLine();
            dpSvar.PrintVec("DotProduct => Vec AC dot Mat DP : ");
            Console.WriteLine();
            

            Console.WriteLine("Determinant testing: ");
            Matrise ma = new Matrise(2);
            ma.Add(new Vektor(new int[]{1,2}));
            ma.Add(new Vektor(new int[]{3,4}));
            ma.PrintMat("Mat ma: ",true);
            Console.WriteLine("Ma determinant: "+MatriseMath.Determinant(ma));


            Matrise detMat = new Matrise(3);
            detMat.Add(new Vektor(new int[]{2,-3,1}));
            detMat.Add(new Vektor(new int[]{2,0,-1}));
            detMat.Add(new Vektor(new int[]{1,4,5}));
            detMat.PrintMat("Mat detMat: ",true);
            Console.WriteLine("detMat determinant: "+MatriseMath.Determinant(detMat));

            Console.WriteLine("TEST inverse: ");
            Matrise inve = new Matrise(2);
            inve.Add(new Vektor(new int[]{1,2}));
            inve.Add(new Vektor(new int[]{2,3}));
            inve.PrintMat("Mat inve: ",true);

            inve.Inverse2x2();
            inve.PrintMat("Mat inve: ",true);


        }
    }
}
