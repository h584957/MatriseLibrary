using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Training
{
    internal class Vektor
    {

        private int[] vec;
        private int columns;
        public Vektor(){
            this.vec = new int[0];
            this.columns=vec.Length;
        }
        public Vektor(int[] vec){
            this.vec = vec;
            this.columns=vec.Length;
        }
        public int Columns{
            get{return columns;}
            set{columns=value;}
        }

        public int[] Vec {
            get{return vec;}
            set{vec = value;}
        }
      
        public void PrintVec(string name){
            Console.WriteLine(name);
            foreach(int num in vec){
                Console.Write(num + " ");
            }
        }
        public void PrintVec(){
            foreach(int num in vec){
                Console.Write(num + " ");
            }
        }


    }
}
