using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Training
{
    internal class MatriseMath
    {

        public static Matrise SkalarMultiplikasjon(Matrise a, int skalar){
            Matrise resultMat = new Matrise(a.RowsCount);
            for(int i = 0; i<resultMat.RowsCount;i++){
                Vektor vec= new Vektor(new int[a.Mat[i].Columns]);
                for(int j=0;j<a.Mat[i].Vec.Length;j++){

                vec.Vec[j]=skalar*a.Mat[i].Vec[j];
                resultMat.Mat[i] = vec;
                }
            }

            return resultMat;
        }
        public static Matrise addisjon(Matrise a, Matrise b)
        {
            int rowM = a.RowsCount;
            int colN = a.Mat[0].Columns;
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
        public static Matrise substraksjon(Matrise a,Matrise b){
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
    }
}
