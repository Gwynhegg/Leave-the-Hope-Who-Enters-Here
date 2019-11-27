using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace K_Means
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        private System.Data.DataTable source_table;  //Инициализируем таблицу для хранения основных данных
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)  //Кнопка, начинающая работу алгоритма
        {
            List<DataRecord> records = new List<DataRecord>();  //Список, содержащий экземпляры записей
            try
            {
                Logs.Content += '\n'+ "Вводим данные: " + '\n';

                //Заполняем данные
                for (int i = 0; i < source_table.Rows.Count; i++)
                {
                    records.Add(new DataRecord());
                    records[i].setName(source_table.Rows[i][0].ToString());
                    double[] temp_vector = new double[source_table.Columns.Count - 1];
                    for (int j = 1; j < source_table.Columns.Count; j++) temp_vector[j - 1] = Double.Parse(source_table.Rows[i][j].ToString());
                    records[i].setData(temp_vector);
                }
            } catch
            {
                MessageBox.Show("Ошибка в типе входных данных");
                return;
            }

            //При необходимости нормализируем данные
            if (checkNormalize.IsChecked == true) normalizeData(records);

            //определяем меру расстояния для всех вычислений
            int type_of_distance;
            switch (boxDistance.Text)
            {
                case "Евклидово расстояние": type_of_distance = 0; break;
                case "Квадратичное расстояние": type_of_distance = 1;break;
                case "Манхэттенское расстояние": type_of_distance = 2;break;
                case "Расстояние Чебышева": type_of_distance = 3;break;
                default: type_of_distance = 0;break;
            }

            //Определяем размер кластера, считывая его из поля TextBox
            if (textBox.Text == "Введите число...") textBox.Text = "1";

            int num_of_clusters = Int32.Parse(textBox.Text); //инициализируем массив, содержащий кластеры
            Cluster[] clusters = new Cluster[num_of_clusters];

            //Здесь определяются первоначальные центроиды
            int[] primary_centroids = getFarawayDots(records, num_of_clusters, type_of_distance);
            for (int i = 0; i < num_of_clusters; i++)
            {
                clusters[i] = new Cluster();
                clusters[i].setCentroid(records[primary_centroids[i]]);
                Logs.Content += "Установлен центроид " + String.Join(" ",records[primary_centroids[i]].getData()) + '\n';
            }

            Logs.Content += "Определяем первоначальные кластеры:" + '\n';

            //Здесь начинается работа основного алгоритма
            int current_step = 1;
            bool finalize_condition = false;
            while (!finalize_condition)
            {
                Logs.Content += "Итерация №" + current_step++ + '\n';
                finalize_condition = true;
                for (int i = 0; i < records.Count; i++) records[i].addToCluster(clusters,type_of_distance);  //добавлем записи в соответствующий кластер

                //Переопределяем центроиды для каждого кластера
                for (int i = 0; i < num_of_clusters; i++) clusters[i].overrideCentroid();

                //Проверяем условие выхода из алгоритма
                for (int i=0;i<num_of_clusters;i++) if (clusters[i].exitCondition())
                    {
                        finalize_condition = false;
                        for (int j = 0; j < num_of_clusters; j++) clusters[j].clearData();
                        break;
                    }
            }
            Logs.Content += "Работа алгоритма завершена."+'\n';

            //Выводим данные о сформированных кластерах
            for (int i = 0; i < clusters.Length; i++)
            {
                string temp = "Кластер "+(i+1)+":";
                foreach (DataRecord dtr in clusters[i].getRecords()) temp+=dtr.getName()+"  ";
                Logs.Content += temp + '\n';
            }

            //Создаем экземпляр результирующей формы и выводим результаты
            ResultWindow new_result = new ResultWindow();
            new_result.Show();
            new_result.drawGraph(clusters); //отображаем графики
        }

        // Метод, производящий сортировку точек по степени их удаленности друг от друга.
        // Для нахождения данных находим минимальное расстояние то ближайшей точки, а потом сортируем в порядке возрастания для нахождения
        // максимально удаленных точек и добавления их в упорядоченный массив
        private int[] getFarawayDots(List<DataRecord> records, int num_of_clusters, int type_of_distance)
        {
            double[,] dots_minimals = new double[records.Count,2];
            double min, temp;
            for (int i = 0; i < records.Count; i++)
            {
                if (i != records.Count - 1) min = records[i].getDistance(records[i + 1],type_of_distance);
                else min = records[i].getDistance(records[i - 1],type_of_distance);
                for (int j = 0; j < records.Count; j++)
                {
                    if (i != j)
                    {
                        temp = records[i].getDistance(records[j],type_of_distance);
                        if (temp < min) min = temp;
                    }
                }
                dots_minimals[i,0]=i; dots_minimals[i, 1] = min; //Здесь находим минимальное расстояние от точки i до ближайшей точки
            }
            dots_minimals = QuickSort(dots_minimals, 0, records.Count-1);  //Сортируем точки в порядке возрастания
            int[] indexes_of_maximal = new int[num_of_clusters];
            for (int i = 0; i < num_of_clusters; i++) indexes_of_maximal[i] = (int)dots_minimals[records.Count-1-i, 0];
            return indexes_of_maximal; //Возвращаем массив необходимой длины, содержащий максимально удаленные точки
        }

		//Алгоритм сортировки QuickSort для упорядочивания точек по их расстоянию до ближайшей точки
        private static double[,] QuickSort(double[,] a, int i, int j)
        {
            if (i < j)
            {
                int q = Partition(a, i, j);
                a = QuickSort(a, i, q);
                a = QuickSort(a, q + 1, j);
            }
            return a;
        }

        private static int Partition(double[,] a, int p, int r)
        {
            double x = a[p,1];
            int i = p - 1;
            int j = r + 1;
            while (true)
            {
                do
                {
                    j--;
                }
                while (a[j,1] > x);
                do
                {
                    i++;
                }
                while (a[i,1] < x);
                if (i < j)
                {
                    double tmp = a[i,1];
                    a[i,1] = a[j,1];
                    a[j,1] = tmp;
                    double tmp1 = a[i, 0];
                    a[i, 0] = a[j, 0];
                    a[j, 0] = tmp1;
                }
                else
                {
                    return j;
                }
            }
        }
		
		//Метод, вызываемый при нажатии на элемент меню "новый проект"
        private void createNewTable(object sender, RoutedEventArgs e)
        {
            Create create = new Create(); //Создаем новый экземпляр формы Create и выводим его на экран
            create.ShowDialog();
            int num_of_objects = create.getObjects(), num_of_params = create.getParams(); //получаем необходимые параметры
            create.Close();
            source_table = new System.Data.DataTable(); //Создаем таблицу и заполняем заголовки соответственно количеству параметров
            source_table.Columns.Add("Название");
            for (int i = 1; i <= num_of_params; i++) source_table.Columns.Add("Параметр №" + i);
            for (int i = 0; i < num_of_objects; i++) source_table.Rows.Add();
            itemsTable.ItemsSource = source_table.AsDataView(); //Устанавливаем таблицу в качестве источника данных
        }

		//Метод, заполняющий таблицу данных случайными значениями. Предназначен для тестирования
        private void fillRandomly(object sender, RoutedEventArgs e)
        {
            try
            {
                Random rnd = new Random();
                for (int i = 0; i < source_table.Rows.Count; i++)
                {
                    source_table.Rows[i][0] = new String((char)rnd.Next(60, 90),1);
                    for (int j = 1; j < source_table.Columns.Count; j++) source_table.Rows[i][j] = rnd.Next(1000);
                 }
            }
            catch
            {
                MessageBox.Show("Невозможно получить доступ к таблице"); //Обработчик на случай возникновения ошибок
            }
        }

		//Метод, вызываемый при нажатии на textBox
        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
        }
		
		//Метод, вызываемый при изменении значения в textBox. Предназначен
		// для динамического контроля формата входных данных
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int temp = Int32.Parse(textBox.Text); //попытка преобразования значения в целочисленное
				
				//если количество кластеров больше количества элементов, то
				// создаем исключение
                if (temp > source_table.Rows.Count) throw new ArgumentException(); 
            } catch (ArgumentException exc)
            {
                MessageBox.Show("Количество кластеров превышает количество элементов");
                textBox.Text = "";
            } catch (FormatException exc1)
            {
                if (source_table != null && textBox.Text!="") //обработчик исключений
                {
                    MessageBox.Show("Ошибка при вводе количества кластеров");
                    textBox.Text = "";
                }
            } catch (NullReferenceException exc2) //Обработчик исключений
            {
                MessageBox.Show("Сначала создайте таблицу");
            }
        }

		//Метод, вызываемый при нажатии на элемент меню "Добавить столбец"
        private void addColumn(object sender, RoutedEventArgs e)
        {
            try
            {
                source_table.Columns.Add("Параметр №" + (source_table.Columns.Count)); //Добавляем столбец с параметром и обновляем таблицу
                itemsTable.ItemsSource = source_table.AsDataView();
            } catch
            {
                MessageBox.Show("Возникла ошибка при доступе к таблице"); //обработчик ошибок
            }

        }

		//Метод, вызываемый при нажатии на элемент меню "Удалить столбец"
        private void deleteColumn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (source_table.Columns.Count > 1)
                {
                    source_table.Columns.RemoveAt(source_table.Columns.Count - 1); //Удаляем последний столбец и обновляем таблицу
                    itemsTable.ItemsSource = source_table.AsDataView();
                } else throw new ArgumentException();
            } catch
            {
                MessageBox.Show("Нeвозможно удалить параметр"); //обработчик ошибок
            }


        }

		//Метод, вызываемый при нажатии на элемент меню "Добавить строку"
        private void addRow(object sender, RoutedEventArgs e)
        {
            try
            {
                source_table.Rows.Add(); //добавляем строку и обновляем таблицу
                itemsTable.ItemsSource = source_table.AsDataView();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при доступе к таблице");
            }
        }

		//Метод, вызываемый при нажатии на элемент меню "Удалить строку"
        private void deleteRow(object sender, RoutedEventArgs e)
        {
            try
            {
                if (source_table.Rows.Count > 1)
                {
                    source_table.Rows.RemoveAt(source_table.Rows.Count-1); //Если возможно, удаляем последнюю строку
                    itemsTable.ItemsSource = source_table.AsDataView();
                }
                else throw new ArgumentException();

            }
            catch
            {
                MessageBox.Show("Невозможно удалить объект"); //обработчик ошибок
            }
        }

        //Нормализация данных методов минимакса
        private void normalizeData(List<DataRecord> records)
        {
            double[] temp_vector;
            double min = records[0].getData()[0], max= records[0].getData()[0];

            foreach (DataRecord rec in records)
            {
                temp_vector = rec.getData();
                for (int i = 0; i < temp_vector.Length; i++) //В цикле находим максимальный и минимальный элементы
                {
                    if (temp_vector[i] < min) min = temp_vector[i];
                    if (temp_vector[i] > max) max = temp_vector[i];
                }
            }
            for (int i = 0; i < records.Count; i++)
            {
                temp_vector = records[i].getData();
				//Для каждого элемента записи применяем функцию нормализации:
				// x = (x-min)/(max-min)
                for (int j = 0; j < temp_vector.Length; j++) temp_vector[j] = (temp_vector[j] - min) / (max - min);
                records[i].setData(temp_vector);
            }
        }

		//Метод, вызываемый при нажатии на элемент меню "Загрузить из Excel"
        private void loadFromExcel(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog(); //Открываем диалоговое окно
            dialog.Filter = "Excel files (*.xls*)|*.xls*"; //задает формат файлов маской для файлов-книг Excel
            Nullable<bool> result = dialog.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dialog.FileName;
            }
			
			//создаем новый экземпляр приложения Excel и пытаемся открыть существующую книгу
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                Microsoft.Office.Interop.Excel.Workbook cur_workbook = excel.Workbooks.Open(filename);
            } catch
            {
                MessageBox.Show("Файл не был выбран");
                return;
            }
			
			//Открываем рабочий лист и находим используемый диапазон ячеек
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range range = sheet.UsedRange;
            source_table = new System.Data.DataTable();
            for (int i = 1; i < range.Columns.Count+1;i++) //Считываем заголовки столбцов
            {
                source_table.Columns.Add(range.Cells[1, i].Value.ToString());
            }

            object[] temp = new object[range.Columns.Count];
            for (int i=2;i<range.Rows.Count+1;i++) //Считываем строки и заполняем таблицу данными
            {
                temp[0] = range.Cells[i, 1].Value.ToString();
                for (int k = 2; k < range.Columns.Count+1; k++) temp[k-1] = range.Cells[i, k].Value.ToString();
                source_table.Rows.Add(temp);
            }
            excel.Quit(); //Выходим из созданного экземпляра приложения
            itemsTable.ItemsSource = source_table.AsDataView(); //Устанавливаем таблицу в качестве источника данных
        }
    }
}
