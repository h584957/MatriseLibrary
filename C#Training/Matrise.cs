using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
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
        CheckAllRows();
    }
    public Matrise(Vektor[] mat) {
        this.mat = mat;
        rowsCount=mat.Length;
        CheckAllRows();
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
    private int Count(){
        int counter = 0;
        foreach(Vektor vec in Mat){
            counter++;
        }
        return counter;
    }
    public void Expand(Matrise a){
        a.CheckAllRows();
        a.PrintMat("Mat a: ",true);
        Console.WriteLine("A rowsCount: "+a.rowsCount);
        Console.WriteLine("rowsCount: "+rowsCount);
        for(int i=0;i<a.rowsCount;i++){
            Console.WriteLine("index: "+i);
            Mat[i].ExpandVec(a.Mat[i]);
        }
        rowsCount=Mat.Length;
    }
    public void Expand(Matrise a, int row){
        a.CheckAllRows();
        int aSize = a.rowsCount;
        Console.WriteLine("aSize: "+aSize);
        int matSize = aSize + rowsCount;
        
        Matrise newMat = new Matrise(matSize);
        Matrise m = new Matrise(matSize);
        m.Mat=Mat;
        m.PrintMat("m: ",true);
        PrintMat("H: ",true);
        Console.WriteLine("matSize: "+matSize);
        newMat.Expand(m);
        int index=row;
        for(int i=0;i<a.rowsCount;i++){
            newMat.Mat[index].ExpandVec(a.Mat[i]);
            index++;
        }
 
        Mat=newMat.Mat;
        rowsCount=Mat.Length;
        CheckAllRows();
    }
    public void Expand2(Matrise a){
        a.CheckAllRows();
        int aSize = a.rowsCount;
        int newSize = rowsCount+aSize; 
        
        Matrise newMat = new Matrise(newSize);
        Matrise m = new Matrise(Mat);
        newMat.Expand(m);

        for(int i=0;i<a.rowsCount;i++){
            newMat.Add(a.Mat[i]);
        }
        Mat=newMat.Mat;
        rowsCount=Mat.Length;
    }
    public void fillMatrix(int numb, int m){
        for(int i = 0;i<rowsCount;i++){
            Vektor temp = new Vektor(m);
            temp.fillVector(numb,m);
            Mat[i] = temp;
        }
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
            
            foreach(Vektor row in mat){
                row.CheckVec();
                if(row.Columns == numbOfRows){

                }else {
                    allRowsEqualLength=false;
                    return;
                }
            }
            rowsCount=Count();
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
            CheckAllRows();
        }
        public void ClearEmptyLines(){
            Console.WriteLine("Mat length = " + mat.Length);
            for(int i=0;i<mat.Length;i++){
                
                Console.WriteLine("Column = " + mat[i].Columns);
                if(mat[i].Columns==0){
                    RemoveRow(i);
                }
            }
            CheckAllRows();
        }
   
        public void PrintMat(string name )
        {
            CheckAllRows();
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
            CheckAllRows();
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
                "Rows: "+ rowsCount +
                " , Columns: "+ mat[0].Columns + 
                " , All rows equal length: " + allRowsEqualLength
                );

            Console.WriteLine("------------------------------------------------------");
        }
   



}
}
