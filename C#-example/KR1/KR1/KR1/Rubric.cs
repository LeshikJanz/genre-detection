using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR1
{
    class Rubric // рубрика
    {    
        public string nameRubric; // имя рубрики
        public List<SampleFile> SF; // список класса файлов образцов
        public double[] funDecision; // решающая функция
        public Rubric()
        { // конструктор
            this.SF = new List<SampleFile>();      // инициализируется новый список файлов с текст-образцов           
        }
        public void createFunDecision(int number)
        {
            this.funDecision = new double[number];      // инициализирует значения для решающей функции
            for (int i = 0; i < number; i++)
                this.funDecision[i] = 0;
        }
    }
}
