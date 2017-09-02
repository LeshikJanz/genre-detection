using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR1
{
    class SampleFile // текст-образец из файла
    {
        public string nameFile; // имя файла-образца
        public Dictionary<string, int> wordsDict; // все ключевые слова с частотами файла образца
        
        public double[] vectorCharacter; // вектор признаков
        public int numberWords; // количество ключевых слов в образце
        public SampleFile()
        { // конструктор
            this.wordsDict = new Dictionary<string, int>();      // инициализируется новый список слов
        }        
        public void createVectorCharacter(int number)
        {
            this.vectorCharacter = new double[number];      // инициализирует вектор-признаков
            for (int i = 0; i < number; i++)
                this.vectorCharacter[i] = 0;
        }
    }
}
