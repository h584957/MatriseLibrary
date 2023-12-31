﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Training
{
    internal class MatriseMath
    {
        public static Matrise IDMat(int dim){
            Matrise id = new Matrise(dim);
            id.fillMatrix(0,dim);

            for(int i =0;i<dim;i++){
                id.Mat[i].Vec[i]=1;
            }

            return id; 
        }
        public static int Determinant(Matrise mat){
            
            int determinant=0;
            if(mat.RowsCount==3){
                determinant=Determinant3x3(mat);
            }else if(mat.RowsCount==2){
                determinant=Determinant2x2(mat);
            }else{
                Console.WriteLine("Error!");
                Console.WriteLine("Matrix is not a 3x3 nor 2x2");
                return 0;
            }

            return determinant;
        }
        private static int Determinant3x3(Matrise mat){
            // check if mat is 3x3 Mat;
            if(!(mat.RowsCount==3 && mat.Mat[0].Columns==3)){
                Console.WriteLine("Error!");
                Console.WriteLine("Mat is not a 3x3 Matrix");
                return 0;
            }
            int determinant = 0;
            Vektor topvec = mat.Mat[0];
    
            Matrise a = new Matrise(2);
            a.fillMatrix(0,2);
            a.Mat[0].Vec[0]=mat.Mat[1].Vec[1];
            a.Mat[0].Vec[1]=mat.Mat[1].Vec[2];
            a.Mat[1].Vec[0]=mat.Mat[2].Vec[1];
            a.Mat[1].Vec[1]=mat.Mat[2].Vec[2];
            int da = Determinant2x2(a);

            Matrise b = new Matrise(2);
            b.fillMatrix(0,2);
            b.Mat[0].Vec[0]=mat.Mat[1].Vec[0];
            b.Mat[0].Vec[1]=mat.Mat[1].Vec[2];
            b.Mat[1].Vec[0]=mat.Mat[2].Vec[0];
            b.Mat[1].Vec[1]=mat.Mat[2].Vec[2];
            int db = Determinant2x2(b);

            Matrise c = new Matrise(2);
            c.fillMatrix(0,2);
            c.Mat[0].Vec[0]=mat.Mat[1].Vec[0];
            c.Mat[0].Vec[1]=mat.Mat[1].Vec[1];
            c.Mat[1].Vec[0]=mat.Mat[2].Vec[0];
            c.Mat[1].Vec[1]=mat.Mat[2].Vec[1];
            int dc = Determinant2x2(c);

            determinant=topvec.Vec[0]*da-topvec.Vec[1]*db+topvec.Vec[2]*dc;

            return determinant;
        }

        
        private static int Determinant2x2(Matrise mat){
            // check if mat is a 2x2 Mat
            if(!(mat.Mat.Length==2 && mat.Mat[0].Columns == 2)){
                Console.WriteLine("Error!");
                Console.WriteLine("Mat is not a 2x2 Matrix");
                return 0;
            }
            int determinant =0;

            int a=mat.Mat[0].Vec[0];
            int b=mat.Mat[0].Vec[1];
            int c=mat.Mat[1].Vec[0];
            int d=mat.Mat[1].Vec[1];

            determinant = a*d-b*c;

            return determinant;
        }
        public static Vektor DotProduct(Vektor vec, Matrise a){
            // check all rowsAreEqual
            a.CheckAllRows();
            if(!a.AllRowsEqualLength){
                Console.WriteLine("Error!");
                Console.WriteLine("All rows are not equal in Matrise A");
                return null;
            }
            Vektor svar = new Vektor(a.RowsCount);

            for(int i=0;i<a.RowsCount;i++){
                svar.Vec[i]=DotProduct(vec,a.Mat[i]);
            }

            return svar; 
        }
        public static int DotProduct(Vektor a, Vektor b){
            // Vektor size eqial check
            if(a.Columns!=b.Columns){
                Console.WriteLine("Error!");
                Console.WriteLine("Vektor A and Vektor b have different length!");
                return 0;
            }
            int svar = 0; 

            for(int i=0;i<a.Columns;i++){
                svar+=a.Vec[i]*b.Vec[i];
            }
            return svar; 
        }

        
        public static Matrise DirectSum(Matrise a, Matrise b){
             // check allRowsEqualLength
            if(!MatriseHelp.AllRowsEqualCheck(a,b)){
                Console.WriteLine("HadamardProduct Failed! ");
                Console.WriteLine("Not all rows are equal length!");
                
                return null;
            }

            int matSize = a.RowsCount+b.RowsCount;
            int colSize = a.Mat[0].Columns+b.Mat[0].Columns;
            
            Matrise resultMat = new Matrise(matSize);
            resultMat.Expand(a);
            
            Matrise fillTop = new Matrise(a.RowsCount);
            fillTop.fillMatrix(0,b.Mat[0].Columns);
            resultMat.Expand(fillTop,0);

            Matrise fillBot = new Matrise(b.RowsCount);
            fillBot.fillMatrix(0,a.Mat[0].Columns);
            resultMat.Expand(fillBot,a.RowsCount);
            resultMat.Expand(b,a.RowsCount);

            return resultMat;
        }
        public static Matrise HadamardProduct(Matrise a, Matrise b){
            // check A and B for sameDim
            if(!MatriseHelp.EqualDim(a,b)){
                Console.WriteLine("HadamardProduct Failed! ");
                Console.WriteLine("Mat A and Mat B have different dimensions");
                return null;
            }
            // check allRowsEqualLength
            if(!MatriseHelp.AllRowsEqualCheck(a,b)){
                Console.WriteLine("HadamardProduct Failed! ");
                Console.WriteLine("Not all rows are equal length!");
                
                return null;
            }
            Matrise resultMat = new Matrise(a.RowsCount);
            resultMat.fillMatrix(0,resultMat.RowsCount);
            int colLength = a.Mat[0].Columns;

            for(int row=0;row<resultMat.RowsCount;row++){

                for(int col=0;col<colLength;col++){
                    resultMat.Mat[row].Vec[col]=a.Mat[row].Vec[col]*b.Mat[row].Vec[col];
                }
            }            
            return resultMat;
        }
        public static Matrise KroneckerProduct(Matrise a, Matrise b){
            if(!MatriseHelp.AllRowsEqualCheck(a,b)){
                Console.WriteLine("KroneckerProduct FAILED");
                Console.WriteLine("NOT ALL ROWS ARE EQUAL LENGTH! ");
                return null;
            }
            int size = b.RowsCount*a.RowsCount;
            Matrise resultMat = new Matrise(size);
            Matrise temp = new Matrise(b.RowsCount);

            int colSize = b.Mat[0].Columns;
            int colLength = a.Mat[0].Columns*b.Mat[0].Columns;
            int rowSize=b.RowsCount;
            int scalarIndex=0;
            for(int rowIndex=0;rowIndex<resultMat.Mat.Length;rowIndex+=rowSize){
                int i = 0;
                for(int colIndex=0;colIndex<colLength;colIndex+=colSize){
                    temp=ScalarMultiply(b,a.Mat[scalarIndex].Vec[i]);    
                    resultMat.Expand(temp,rowIndex);
                    i++; 
                }
                scalarIndex++;
            }

            return resultMat;
        }
        public static Matrise Multiply(Matrise a, Matrise b){
            if(!MatriseHelp.multipliable(a,b)){
                Console.WriteLine("Mat A is not multipliable with Mat B");
                return null;
            }
            int aN = a.RowsCount;
            int bM = b.Mat[0].Columns;

            int resultRowsize= aN;
            int resultColumnSize=bM;
            
            Matrise resultMat = new Matrise(resultRowsize);
           
            for(int resultIndex =0;resultIndex<resultRowsize;resultIndex++ ){
                resultMat.Mat[resultIndex] = new Vektor(resultColumnSize);
                for(int i = 0; i<bM;i++){
                    Vektor colA = new Vektor(a.Mat[resultIndex].Vec);
                    Vektor rowB = new Vektor(getRowAsVec(b,i).Vec);
                    
                    Vektor toBeSum = new Vektor(tempMultiplyVectors(colA, rowB).Vec);
                    resultMat.Mat[resultIndex].Vec[i]=sumVec(toBeSum);
                }
            }

            return resultMat;
        }
        public static Matrise ScalarMultiply(Matrise a, int scalar){
            Matrise resultMat = new Matrise(a.RowsCount);
            for(int i = 0; i<resultMat.RowsCount;i++){
                Vektor vec= new Vektor(new int[a.Mat[i].Columns]);
                for(int j=0;j<a.Mat[i].Vec.Length;j++){

                vec.Vec[j]=scalar*a.Mat[i].Vec[j];
                resultMat.Mat[i] = vec;
                }
            }

            return resultMat;
        }
        public static Matrise Add(Matrise a, Matrise b)
        {
            int rowM = a.RowsCount;
            Matrise sum = new Matrise(rowM);
            
            if(MatriseHelp.Addable(a,b)){

                for(int i = 0;i<rowM;i++){
                    sum.Mat[i]=AddisjonVek(a,b,i);
                }
            } else {
                Console.WriteLine("NON ADDABLE MATRIXES");
                return null;} 

            return sum;
        }
        public static Matrise Substract(Matrise a,Matrise b){
            int colN = a.Mat[0].Columns;
            int rowM = a.RowsCount;
            Matrise sum = new Matrise(rowM);
            
            if(MatriseHelp.Addable(a,b)){
                for(int i = 0;i<rowM;i++){
                    sum.Mat[i]=substraksjonVek(a,b,i);
                }

            } else {
                Console.WriteLine("NON SUBSTRACTABLE MATRIXES");
                return null;} 

            return sum;
        }

        private static Vektor AddisjonVek(Matrise a, Matrise b, int index){
            Vektor vec = new Vektor(new int[a.Mat[0].Columns]);

            for(int i=0;i<a.Mat[index].Columns;i++){
                Vektor av = new Vektor(a.Mat[index].Vec);
                Vektor bv = new Vektor(b.Mat[index].Vec);
                vec.Vec[i]=av.Vec[i]+bv.Vec[i];
            }

            return vec;
        }
       
        private static Vektor substraksjonVek(Matrise a, Matrise b, int index){
            Vektor vec = new Vektor(new int[a.Mat[0].Columns]);
            for(int i=0;i<a.Mat[index].Columns;i++){
                Vektor av = a.Mat[index];
                Vektor bv = b.Mat[index];
                vec.Vec[i]=av.Vec[i]-bv.Vec[i];
            }
            return vec;
        }

        private static int sumVec(Vektor vec){
            if(vec==null){
                Console.WriteLine("Can not sum vec because vec is null!");
                return 0;
            }

            int result=0;
            for(int i=0;i<vec.Columns;i++){
                result+=vec.Vec[i];
            }
            return result;
        }
        private static Vektor tempMultiplyVectors(Vektor a, Vektor b){
            Vektor resultVek = new Vektor(a.Columns);
            
            if(a.Columns != b.Columns){
                Console.WriteLine("Can not multiply vectors because the length is different.");
                return null;
            }
            for(int i =0;i<a.Columns;i++){
                resultVek.Vec[i]=a.Vec[i]*b.Vec[i];
            }

            return resultVek;
        }
        private static Vektor getRowAsVec(Matrise a, int index){
            Vektor resultVek = new Vektor(a.RowsCount);
            for(int i = 0; i<a.RowsCount;i++){
                resultVek.Vec[i]=a.Mat[i].Vec[index];
            }
            
            return resultVek;
        }
    }
}
