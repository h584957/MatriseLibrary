using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace C_Training
{
    internal class Matrise
    {

        private Vektor[] mat ; 
        private int rowsCount;
        private bool allRowsEqualLength=false;

    public Matrise(int rowsCount) { 
        this.rowsCount = rowsCount;
        this.mat = new Vektor[rowsCount];
        for(int i=0;i<rowsCount;i++){
            this.mat[i]=new Vektor();
        }
    }
    public Matrise(Vektor[] mat) {
        
            this.mat = mat;
            rowsCount=mat.Length;
    }

    public void Expand(Matrise a, int row){
        
    }
    public void fillMatrix(int numb, int m){
        for(int i = 0;i<rowsCount;i++){
            Vektor temp = new Vektor(m);
            temp.fillVector(numb,m);
            Mat[i] = temp;
        }
    }
    public bool AllRowsEqualLength{
        get{return allRowsEqualLength;}
        set{allRowsEqualLength=value;}
    }
        public int RowsCount{
            get{return rowsCount;}
            set{rowsCount=value;}
        }
        public Vektor[] Mat { 
            get { return mat;} 
            set { mat = value;}
        }
        public void Expand(Matrise a){
            

        }
        public void Add(Vektor vec){
            for(int i = 0; i<rowsCount;i++){
                if(mat[i].Vec.Length == 0){
                    mat[i]=vec;
                    //check if all rows are same length
                    CheckAllRows();
                return; 
                }
            }
        
            rowsCount++;
            Matrise tempMat= new Matrise(rowsCount);
            
            for(int i =0;i<tempMat.mat.Length-1;i++){
                tempMat.mat[i] = mat[i];
            }

            tempMat.mat[rowsCount-1]=vec;
            
            Mat = tempMat.mat;
            //check if all rows are same length
            CheckAllRows();
        }      
        // Check if all rows have the same column length
        public void CheckAllRows(){
            int numbOfRows=0;
            numbOfRows=mat[0].Columns;
            if(!allRowsEqualLength){
                foreach(Vektor row in mat){
                    if(row.Columns == numbOfRows){

                    }else {
                        allRowsEqualLength=false;
                        return;
                    }
                }
            }
            allRowsEqualLength=true;
        }
        public void RemoveRow(int index){
            rowsCount--;
            Matrise tempMat = new Matrise(rowsCount);
            int j=0;
            for(int i = 0;i<mat.Length;i++){
                if(i !=index){
                    tempMat.mat[j]=mat[i];
                    j++;
                }                
            }
            Mat=tempMat.mat;
        }
        public void ClearEmptyLines(){
            Console.WriteLine("Mat length = " + mat.Length);
            for(int i=0;i<mat.Length;i++){
                
                Console.WriteLine("Column = " + mat[i].Columns);
                if(mat[i].Columns==0){
                    RemoveRow(i);
                }
            }
        }
   
        public void PrintMat(string name )
        {
            Console.WriteLine(name);            
            foreach (Vektor row in mat)
            {
                Console.Write("    ");
                row.PrintVec();
                Console.WriteLine();
            }

        }
        public void PrintMat(string name,bool moreInfo)
        {
            Console.WriteLine(name);            
            foreach (Vektor row in mat)
            {
                Console.Write("    ");

                row.PrintVec();
                Console.WriteLine();
            }

            PrintMatInfo(moreInfo);
            Console.WriteLine();
        }
        private void PrintMatInfo(bool moreInfo){
            if(moreInfo)
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(
                "Amout of Rows: "+ rowsCount +
                " , amout of column: "+ mat[0].Columns + 
                " , All rows equal length: " + allRowsEqualLength
                );

            Console.WriteLine("------------------------------------------------------");
        }
   



}
}
