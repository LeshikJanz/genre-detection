using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR1
{
    class Rubrics
    {        
        public List<Rubric> Rubr;
        public int numberSF; // общее число файлов образцов
        public Rubrics()
        { // конструктор
            this.Rubr = new List<Rubric>();      // инициализируется новый список рублик
        }
        public int countSF()
        { 
            int numberSF = 0;
            for (int i = 0; i < this.Rubr.Count(); i++)
            {//вход в i-ую рубрику
                numberSF += this.Rubr[i].SF.Count();                
            }
            return numberSF;
        }
    }
}
