/*
 * Выполнил студент: Моисеев В. В. 
 * группа 291001
 * Зачетная книжка № 29100-58
 * 
 *    Контрольная работа №2
 * МЕТОД АВТОМАТИЧЕСКОГО РЕФЕРИРОВАНИЯ ТЕКСТОВОЙ ИНФОРМАЦИИ
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KR2
{
    public partial class Form1 : Form
    {
        char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\"','\'', ';', '?', '!', '—', '-', '–','•','+', '*', '/','=',
                                  '_', '(', ')', '<', '>', '«', '»', '\\','0','1','2','3','4','5','6','7','8','9'};
        List<string> stopwords = new List<string> { "а", "без", "более", "бы", "был", "была", "были", "было", "быть", "в","вам", "вас",
                                  "весь", "во", "вот", "все", "всего", "всех", "вы", "где", "да", "даже", "для", "до", "его",
                                  "ее", "если", "есть", "ещё", "же", "за", "здесь", "и", "из", "из-за", "или", "им", "их", 
                                  "к", "как", "как-то", "ко", "когда", "кто", "ли", "либо", "мне", "может", "мы", "на", "надо",
                                  "наш", "не", "него", "неё", "нет", "ни", "них", "но", "ну", "о", "об", "однако", "он", "она",
                                  "они", "оно", "от", "очень", "по", "под", "при", "с", "со", "так", "также", "такой", "там", "те", 
                                  "тем", "то", "того", "тоже", "той", "только", "том", "ты", "у", "уже", "хотя", "чего", "чей", "чем", 
                                  "что", "чтобы", "чьё", "чья", "эта", "эти", "это", "я"
                                }; //стоп-слова
        Dictionary<string, int> wordsDict; // коллекция слов и их количество в тексте
        //List<string> sentence; // список предложений из файла.
        public Form1()
        {
            InitializeComponent();
        }
        // реферирование текста файла
        private void butOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileTxt = new OpenFileDialog(); // диалог выбора файла
            fileTxt.Filter = "Текстовые файлы (*.txt)|*.txt"; // маска поиска файлов
            if (fileTxt.ShowDialog() == DialogResult.OK)
            {
                wordsfreqLawsZipf(fileTxt.FileName); // словарь слов и их частот в файле 
                createFileRef(fileTxt.FileName);     // реферирование
            }
        }

        // слова и частота вхождения в файл
        private void wordsfreqLawsZipf(string fileName)
        {
            wordsDict = new Dictionary<string, int>(); // коллекция слов и их количество в тексте
            StreamReader sr = new StreamReader(fileName, System.Text.Encoding.UTF8);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                // приводим к нижнему регистру и разбиваем входную строку на массив слов
                string[] wordsArray = line.ToLower().Split(delimiterChars);
                foreach (string word in wordsArray)                 // обработка массива слов
                {
                    string wordtmp = word.Trim(' '); //  убираем пробелы
                    if (wordtmp != "" && !stopwords.Contains(wordtmp))
                    {
                        if (wordsDict.ContainsKey(wordtmp)) wordsDict[wordtmp]++;
                        else wordsDict.Add(wordtmp, 1);
                    }
                }
            }
            sr.Close();
        }
        // создание списка предложений из файла
        private string[] sentenceList(string fileName)
        {
            string text;
            StreamReader sr = new StreamReader(fileName, System.Text.Encoding.UTF8);
            text = sr.ReadToEnd();
            sr.Close();
            string[] sentence = text.Split('.'); // список предложений из файла
            for (int i = 0; i < sentence.Length; i++)
            {
                sentence[i] = sentence[i].Replace(Environment.NewLine, " "); // удаление разрывов строк
            }
            return sentence;
        }

        // создания файла реферата
        private void createFileRef(string fileName)
        {
            int  sizeFull=0,sizeRef=0,i,j;
            double percent=0;
            string[] sentence;
            List<int> numSent=new List<int>(); // номера предложений из текста.
            List<string> wordsSort = new List<string>(); // список ключевых слов            

            sentence=sentenceList(fileName);
            for (i = 0; i < sentence.Length; i++)            
            {
                sizeFull+=sentence[i].Length; // размер текстовой информации
            }
            foreach (var pair in wordsDict.OrderByDescending(pair => pair.Value))
            {
                wordsSort.Add(pair.Key);
            }
            i=-1;j=0;
            do
            {
                if(++i>=sentence.Length) {
                    i=0;
                    j++;
                }
                if (j >= wordsSort.Count()) break; // использованы все ключевые слова 
                if (sentence[i].Contains(wordsSort[j]))
                { // предложение содержит ключевое слово
                    if(!numSent.Contains(i)) 
                    {
                        numSent.Add(i);
                        sizeRef+=sentence[i].Length;
                        percent=(double)sizeRef/sizeFull*100; // текущий процент файла-реферата
                    }                
                }
            }
            while (((int)percent)<DegreeNumUpDnEssay.Value);
            numSent.Sort(); // сортируем список
            // запись результата реферирования в файл
            StreamWriter sw = new StreamWriter(fileName.Remove(fileName.IndexOf('.')) + "_ref.txt", false, Encoding.UTF8);
            foreach (int ind in numSent) 
            {
             sw.WriteLine("{0}.", sentence[ind]);
            }
            sw.Close();
            MessageBox.Show(" Реферат в файле : " + fileName.Remove(fileName.IndexOf('.')) + "_ref.txt");
        }
    }
}
