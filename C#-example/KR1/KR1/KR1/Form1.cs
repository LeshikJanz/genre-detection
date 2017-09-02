/*
 * Выполнил студент: Моисеев В. В. 
 * группа 291001
 * Зачетная книжка № 29100-58
 * 
 *    Контрольная работа №1
 * Автоматическая рубрикация текстовой информации по образцу
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

namespace KR1
{
    public partial class Form1 : Form
    {
        char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\"','\'', ';', '?', '!', '—', '-', '+', '*', '/','=',
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
        string curDir = ""; // текущий директорий поиска
        Rubrics Rs;
        int countWords = 0; // используется для подсчета количества слов в образце
        public Form1()
        {
            InitializeComponent();
        }
        // выбор каталога данных
        private void butSelDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                curDir = folderBrowserDialog.SelectedPath;
                textBoxDir.Text = curDir;
                butDecidingFun.Enabled = true;
                infoVectorDataGridView.Visible = false;
                dataGridViewClassification.Visible = false;
            }
        }
        // запуск процесса автоматической рубрикации текстов по образцу 
        private void butClassification_Click(object sender, EventArgs e)
        {
            infoVectorDataGridView.Visible = false;
            dataGridViewClassification.Visible = false;
            labTraining.Visible = true;
            labTraining.Refresh(); // перерисовка
            сategorization();      // формирование структуры описания рубрик            
            initVCRubrics();       // инициализация вектора признаков и решающей функции
            methodPerceptron();    // метод обучения персептрона
            butDistributionRubrics.Enabled = true;
            showInfoVectorRubric();
            labTraining.Visible = false;
            infoVectorDataGridView.Visible = true;
        }

        // формирование структуры описания рубрик
        private void сategorization()
        {
            Rs = new Rubrics();
            DirectoryInfo di = new DirectoryInfo(curDir);           // текущий директорий
            DirectoryInfo[] diSourceSubDir = di.GetDirectories();   // поддиректории тематической классификации заданных рубрик
            foreach (DirectoryInfo subdi in diSourceSubDir)
            {
                Rubric R = new Rubric();
                R.nameRubric = subdi.Name; // имя рубрики
                FileInfo[] filesTxt = subdi.GetFiles("*.txt");
                for (int i = 0; i <= filesTxt.Length - 1; i++)
                {
                    SampleFile Rsf = new SampleFile();
                    Rsf.nameFile = filesTxt[i].FullName;
                    wordsLawsZipf((int)numUpDnB.Value, ref Rsf);
                    R.SF.Add(Rsf);
                }
                Rs.Rubr.Add(R);
            }
        }

        // выборка ключевых слов из файла в количестве указанных ключевых слов
        private void wordsLawsZipf(int amount, ref SampleFile refSF)
        {
            List<string> retListWors = new List<string>();
            Dictionary<string, int> wordsDict = new Dictionary<string, int>(); // коллекция слов и их количество в тексте

            wordsDict = wordsfreqLawsZipf(refSF.nameFile);
            refSF.numberWords = wordsDict.Count(); // количество ключевых слов в файле-образце
            countWords = 0;
            foreach (var pair in wordsDict.OrderByDescending(pair => pair.Value))
            {
                if (amount > countWords++)
                {
                    refSF.wordsDict.Add(pair.Key, pair.Value);
                }
                else break; // выходим из цикла если записано amount значений
            }
        }

        // слова и частота вхождения в файл
        private Dictionary<string, int> wordsfreqLawsZipf(string fileName)
        {
            Dictionary<string, int> wordsDict = new Dictionary<string, int>(); // коллекция слов и их количество в тексте
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
            return wordsDict;
        }

        // инициализация вектора признаков и решающей функции
        private void initVCRubrics()
        {
            Rs.numberSF = Rs.countSF(); // подсчет количества файлов образцов
            for (int i = 0; i < Rs.Rubr.Count(); i++)
            {//вход в i-ую рубрику
                Rs.Rubr[i].createFunDecision(Rs.numberSF * (int)numUpDnB.Value + 1); // создаем начальную  решающую функцию
                for (int j = 0; j < Rs.Rubr[i].SF.Count(); j++)
                {
                    //вход в j-ый образец
                    Rs.Rubr[i].SF[j].createVectorCharacter(Rs.numberSF * (int)numUpDnB.Value + 1); // создаем вектор признаков
                    Rs.Rubr[i].SF[j].vectorCharacter = initVectorCharacter(Rs.numberSF * (int)numUpDnB.Value + 1, Rs.Rubr[i].SF[j].wordsDict);
                }
            }
        }

        // создаем вектор признаков для данной коллекции ключевых слов
        private double[] initVectorCharacter(int amount, Dictionary<string, int> wordsD)
        {
            double[] VC = new double[amount];
            int index = 0;
            for (int i = 0; i < Rs.Rubr.Count(); i++)
            {//вход в i-ую рубрику
                for (int j = 0; j < Rs.Rubr[i].SF.Count(); j++)
                {   //вход в j-ый образец                    
                    for (int k = 0; k < Rs.Rubr[i].SF[j].wordsDict.Count(); k++)
                    {
                        if (wordsD.ContainsKey(Rs.Rubr[i].SF[j].wordsDict.Keys.ElementAt(k)))
                            VC[index++] = (double)Rs.Rubr[i].SF[j].wordsDict.Values.ElementAt(k) / Rs.Rubr[i].SF[j].numberWords;
                        else VC[index++] = 0;
                    }
                }
            }
            VC[index] = 0.001; // дополнительно одна вещественная константа
            return VC;
        }

        //Метод обучения персептрона
        private void methodPerceptron()
        {
            bool flag, flagD; // требуется ли обучение
            double[] val = new double[Rs.Rubr.Count()]; // для результатов значений решающих функций
            do
            {
                flag = false;
                for (int i = 0; i < Rs.Rubr.Count(); i++)
                {//вход в i-ую рубрику
                    for (int j = 0; j < Rs.Rubr[i].SF.Count(); j++)
                    {   //вход в j-ый образец   
                        flagD = false; //требуется ли корректировка решающей фунуции
                        for (int l = 0; l < Rs.Rubr.Count(); l++)
                            val[l] = presentForm(ref Rs.Rubr[i].SF[j].vectorCharacter, ref Rs.Rubr[l].funDecision);
                        for (int l = 0; l < Rs.Rubr.Count(); l++)
                        {
                            if (l != i) // разные рубрики
                            {
                                if (val[i] <= val[l])
                                {
                                    flag = true; // присутствует ошибка
                                    flagD = true;
                                    decFD(ref Rs.Rubr[i].SF[j].vectorCharacter, ref Rs.Rubr[l].funDecision); // уменьшить РФ
                                }
                            }
                        }
                        if (flagD) addFD(ref Rs.Rubr[i].SF[j].vectorCharacter, ref Rs.Rubr[i].funDecision); // увеличить РФ
                    }
                }
            }
            while (flag);
        }

        // вычисление для объекта VC и решающей функции  FD
        private double presentForm(ref double[] VC, ref double[] FD)
        {
            double result = 0;
            for (int i = 0; i < (Rs.numberSF * (int)numUpDnB.Value + 1); i++)
            {
                result += VC[i] * FD[i];
            }
            return result;
        }
        // добавление к решающей функции FD на объект VC
        private void addFD(ref double[] VC, ref double[] FD)
        {
            for (int i = 0; i < (Rs.numberSF * (int)numUpDnB.Value + 1); i++)
            {
                FD[i] += VC[i];
            }
        }
        // уменьшение решающей функции FD на объект VC
        private void decFD(ref double[] VC, ref double[] FD)
        {
            for (int i = 0; i < (Rs.numberSF * (int)numUpDnB.Value + 1); i++)
            {
                FD[i] -= VC[i];
            }
        }

        // возврат имени рубрики
        private string Classification(string fileName)
        {
            double[] val = new double[Rs.Rubr.Count()]; // для результатов значений решающих функций
            Dictionary<string, int> wordsDict = new Dictionary<string, int>(); // коллекция слов и их количество в тексте
            wordsDict = wordsfreqLawsZipf(fileName);
            int index = 0;
            string tmpKey;
            double maxVal;

            for (int i = 0; i < Rs.Rubr.Count(); i++) val[i] = 0; // инициализируем нулями

            for (int i = 0; i < Rs.Rubr.Count(); i++)
            {//вход в i-ую рубрику
                for (int j = 0; j < Rs.Rubr[i].SF.Count(); j++)
                {   //вход в j-ый образец                    
                    for (int k = 0; k < Rs.Rubr[i].SF[j].wordsDict.Count(); k++)
                    {

                        tmpKey = Rs.Rubr[i].SF[j].wordsDict.Keys.ElementAt(k); // index слово-ключ из обобщенного вектора признаков
                        if (wordsDict.ContainsKey(tmpKey))
                        {
                            for (int l = 0; l < Rs.Rubr.Count(); l++)
                                val[l] += Rs.Rubr[l].funDecision[index] * ((double)wordsDict[tmpKey] / wordsDict.Count());
                        }
                        index++;
                    }
                }
            }
            // прибавляем последнее вещественное число из решающей функции
            for (int i = 0; i < Rs.Rubr.Count(); i++)
                val[i] += Rs.Rubr[i].funDecision[index];
            index = 0;
            maxVal = val[index];
            for (int i = 1; i < Rs.Rubr.Count(); i++)
                if (maxVal < val[i])
                {
                    index = i;
                    maxVal = val[index];
                }
            return Rs.Rubr[index].nameRubric;
        }
        // отображение информации о векторах признаков
        private void showInfoVectorRubric()
        {
            int number = Rs.numberSF * (int)numUpDnB.Value + 2;
            int numWordsSF = (int)numUpDnB.Value; // число ключевых слов в файле образце
            //this.Controls.Add(infoVectorDataGridView);
            infoVectorDataGridView.Rows.Clear();
            infoVectorDataGridView.ColumnCount = number;

            infoVectorDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            infoVectorDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            infoVectorDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(infoVectorDataGridView.Font, FontStyle.Bold);

            infoVectorDataGridView.Name = "infoVectorDataGridView";
            infoVectorDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            infoVectorDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            infoVectorDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            infoVectorDataGridView.GridColor = Color.Black;
            infoVectorDataGridView.RowHeadersVisible = false;

            infoVectorDataGridView.Columns[0].Name = "Наименование";
            for (int i = 1; i < number; i++)
                infoVectorDataGridView.Columns[i].Name = i.ToString();

            infoVectorDataGridView.SelectionMode =
                DataGridViewSelectionMode.CellSelect;
            infoVectorDataGridView.MultiSelect = false;

            int index = 0;
            // выводим слова обобщенного вектора признаков 
            infoVectorDataGridView.Rows.Add(new DataGridViewRow());
            infoVectorDataGridView.Rows[infoVectorDataGridView.Rows.Count - 1].Cells[index++].Value = "Обобщенный вектор";
            for (int i = 0; i < Rs.Rubr.Count(); i++)
            {//вход в i-ую рубрику
                for (int j = 0; j < Rs.Rubr[i].SF.Count(); j++)
                {   //вход в j-ый образец                    
                    for (int k = 0; k < Rs.Rubr[i].SF[j].wordsDict.Count(); k++)
                    {
                        // цвет ячейки
                        if ((i % 2) > 0) infoVectorDataGridView.Rows[infoVectorDataGridView.Rows.Count - 1].Cells[index].Style.BackColor = Color.Yellow;
                        else infoVectorDataGridView.Rows[infoVectorDataGridView.Rows.Count - 1].Cells[index].Style.BackColor = Color.Lime;
                        infoVectorDataGridView.Rows[infoVectorDataGridView.Rows.Count - 1].Cells[index++].Value =
                            Rs.Rubr[i].SF[j].wordsDict.Keys.ElementAt(k);
                    }
                }
            }
            // вывод векторов признаков по файлам образцам
            for (int i = 0; i < Rs.Rubr.Count(); i++)
            {//вход в i-ую рубрику
                for (int j = 0; j < Rs.Rubr[i].SF.Count(); j++)
                {   //вход в j-ый образец   
                    infoVectorDataGridView.Rows.Add(new DataGridViewRow());
                    infoVectorDataGridView.Rows[infoVectorDataGridView.Rows.Count - 1].Cells[0].Style.BackColor = Color.LightSteelBlue;
                    infoVectorDataGridView.Rows[infoVectorDataGridView.Rows.Count - 1].Cells[0].Value =
                        "Признак: " + Rs.Rubr[i].SF[j].nameFile;
                    for (int k = 0; k < number - 2; k++)
                    {
                        // цвет фона ячейки по файлу образцу
                        if ((k / numWordsSF % 2) > 0) infoVectorDataGridView.Rows[infoVectorDataGridView.Rows.Count - 1].Cells[k+1].Style.BackColor = Color.LightSkyBlue;
                        else infoVectorDataGridView.Rows[infoVectorDataGridView.Rows.Count - 1].Cells[k+1].Style.BackColor = Color.LightBlue;
                        infoVectorDataGridView.Rows[infoVectorDataGridView.Rows.Count - 1].Cells[k + 1].Value =
                            Rs.Rubr[i].SF[j].vectorCharacter[k];
                    }
                }
            }
            // вывод решающих функций 
            for (int i = 0; i < Rs.Rubr.Count(); i++)
            {//вход в i-ую рубрику
                infoVectorDataGridView.Rows.Add(new DataGridViewRow());               
                infoVectorDataGridView.Rows[infoVectorDataGridView.Rows.Count - 1].Cells[0].Value =
                    "Решающая функция: " + Rs.Rubr[i].nameRubric;
                for (int k = 0; k < number - 1; k++)
                {   
                    infoVectorDataGridView.Rows[infoVectorDataGridView.Rows.Count - 1].Cells[k + 1].Value =
                        Rs.Rubr[i].funDecision[k];
                }

            }
        }

        // рубрикация файлов из корня каталога
        private void separatingFunctions()
        {
            DirectoryInfo di = new DirectoryInfo(curDir); // текущий директорий
            FileInfo[] filesTxt = di.GetFiles("*.txt"); // файлы для рубрикации
            dataGridViewClassification.Rows.Clear();
            for (int i = 0; i <= filesTxt.Length - 1; i++)
            {
                dataGridViewClassification.Rows.Add(new DataGridViewRow());
                dataGridViewClassification.Rows[dataGridViewClassification.Rows.Count - 1].Cells[0].Value = filesTxt[i].Name;
                dataGridViewClassification.Rows[dataGridViewClassification.Rows.Count - 1].Cells[1].Value = Classification(filesTxt[i].FullName);
            }
        }
        // создание ссылка для открытия файлов текстовым просмотрщиком системы.
        private void dataGridViewClassification_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = curDir + '\\' + dataGridViewClassification.Rows[e.RowIndex].Cells[0].Value.ToString();
            p.Start();
        }
        // вызов процедуры тематической классификации по заданным рубрикам
        private void butDistributionRubrics_Click(object sender, EventArgs e)
        {
            separatingFunctions(); // тематическая классификации по заданным рубрикам
            dataGridViewClassification.Visible = true;
        }
    }
}
