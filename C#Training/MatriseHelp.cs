using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace C_Training
{
    internal class MatriseHelp
    {

        public static bool Addable(Matrise a, Matrise b){
            
            a.CheckAllRows();
            b.CheckAllRows();
            if(a.AllRowsEqualLength && b.AllRowsEqualLength){

            } else return false;
            if(EqualDim(a,b)){

            }else return false;
            
            return true;
        }
        public static bool EqualDim(Matrise a, Matrise b){
            if(a.RowsCount == b.RowsCount && a.Mat[0].Columns == b.Mat[0].Columns ){
                
            }else return false;
            return true;
        }

        public static bool multipliable(Matrise a, Matrise b){

                a.CheckAllRows();
                b.CheckAllRows();

                int bN=b.RowsCount;
                int aM=a.Mat[0].Columns;

                if(!a.AllRowsEqualLength ||!b.AllRowsEqualLength ){
                    return false;
                }

                if(!(aM==bN)){
                    return false;
                }
                
            return true;
        }

    }
}
