﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Training
{
    internal class MatriseMath
    {
        public static Matrise KroneckerProduct(Matrise a, Matrise b){
            Matrise resultMat = new Matrise(b.RowsCount+a.RowsCount);
            Matrise temp = new Matrise(b.RowsCount);
            int RowIndex=0;
            int ColumnIndex=0;
            int indexSize = b.Mat[0].Columns;
            int rowSize = b.RowsCount;
            
            int Length = resultMat.RowsCount;
            int RowLength = a.Mat[0].Columns + b.Mat[0].Columns;

            for(int i =0;i<b.RowsCount;i++){
                
                for(int j =0;j<a.Mat[0].Columns;j++){
                int scalar = a.Mat[i].Vec[j];
                temp=ScalarMultiply(b, scalar);
                temp.PrintMat("temp: ",true);
                // add temp to the resultMatrix correct
                Console.WriteLine("resultMatColIndex: "+ColumnIndex);
                Console.WriteLine("resultMatRowIndex: "+RowIndex);
                Console.WriteLine("resultMatRowLength: "+RowLength);
                Console.WriteLine("indexSize: "+indexSize);
                Console.WriteLine("rowSize: "+rowSize);

                resultMat.Expand(temp,RowIndex);
                if(ColumnIndex<RowLength){
                    ColumnIndex+=indexSize;
                }else{
                    ColumnIndex=0;
                    RowIndex+=rowSize;
                    if(RowIndex>Length){
                        return resultMat;
                    }
                }

                }
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
