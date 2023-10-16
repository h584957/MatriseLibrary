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
         public Vektor(int size){
            this.vec = new int[size];
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

        public void CheckVec(){
            Vektor temp = new Vektor();
            columns=Vec.Length;
        }
        private int Count(){
            int count=0;
            foreach(int num in Vec){
                if(num!=null){
                    count++;
                }                
            }
            return count;
        }
        public void ExpandVec(Vektor vector){
            Vektor vec = new Vektor(columns+vector.Columns);
            int startPoint = columns;
            
            for(int i = 0;i<columns;i++){
                vec.Vec[i]=Vec[i];
            }
            for(int i = startPoint;i<vec.columns;i++){
                vec.Vec[i]=vector.Vec[i-startPoint];
            }

            Vec=vec.Vec;
            columns=Vec.Length;
        }
        public void fillVector(int numb, int size){
            Vektor newVec = new Vektor(size);
            for(int i = 0;i<size;i++){
                newVec.Vec[i]=numb;
            }

            Vec=newVec.Vec;
            columns=Vec.Length;
        }
        public void PrintVec(string name){
            Console.WriteLine(name);
            foreach(int num in vec){
                Console.Write(num + " ");
            }
        }
        public void PrintVec(){
            foreach(int num in vec){
                if(num <-99 || num>999){
                Console.Write(num + " ");
                }
                else if(num <-9 || num>99){
                Console.Write(" "+num + " ");
                }
                else if(num <0 || num>9){
                Console.Write("  "+num + " ");
                }else{
                Console.Write("   "+num + " ");
                }
            }
        }
    }
}
