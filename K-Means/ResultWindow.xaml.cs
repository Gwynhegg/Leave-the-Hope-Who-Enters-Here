using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace K_Means
{
    /// <summary>
    /// Логика взаимодействия для Create.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        Cluster[] this_clusters; //Здесь содержатся данные по кластерам
        public ResultWindow()
        {
            InitializeComponent();
        }

        public void drawGraph(Cluster[] clusters)
        {
            this_clusters = clusters;
            //Создаем две таблицы для хранения данных
            DataTable clusters_table = new DataTable();
            DataTable average_table = new DataTable();
            List<string> names = new List<string>();
            clusters_table.Columns.Add("Кластеры");
            average_table.Columns.Add("Кластеры");
            clusters_table.Columns.Add("Элементы кластеров");
            //Создаем колонки для вывода средних значений по параметрам
            for (int i = 0; i < clusters[0].getCentroid().getData().Length;i++) average_table.Columns.Add("Параметр " + (i + 1));
            for (int i = 0; i < clusters.Length; i++)
            {
                names.Clear();

                //Записываем имена объектов, принадлежащих конкретному кластеру, в таблицу
                foreach (DataRecord e in clusters[i].getRecords()) names.Add(e.getName());
                clusters_table.Rows.Add("Кластер " + (i + 1), String.Join(",", names));

                //Записываем средние значения по кластеру (которые являются центроидами), во вторую таблицу
                average_table.Rows.Add("Кластер " + (i + 1));
                double[] temp = clusters[i].getCentroid().getData();
                for (int j = 1; j < temp.Length+1; j++) average_table.Rows[i][j] = Math.Round(temp[j-1],8);
            }

            //Выводим таблицы на форму
            outputTable.ItemsSource = clusters_table.AsDataView();
            clustersAverage.ItemsSource = average_table.AsDataView();

            drawAverage(clusters);

            //Заполняем два ListBox доступным количеством измерений
            for (int i = 0; i < clusters[0].getCentroid().getData().Length+1; i++)
            {
                boxFirstDim.Items.Add(i);
                boxSecondDim.Items.Add(i);
            }
            boxFirstDim.SelectedIndex = 0;
            boxSecondDim.SelectedIndex = 0;
        }


        //Метод отрисовки графика объектов с помощью импортированной библиотеки
        //Windows.Forms.DataVisualization.Chart
        private void drawClusters(int first_dim, int second_dim)
        {
            System.Windows.Forms.DataVisualization.Charting.Chart clusters_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            clusters_chart.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Default"));
            for (int i = 0; i < this_clusters.Length; i++)
            {
                clusters_chart.Series.Add("Кластер " + (i + 1));
                clusters_chart.Series["Кластер " + (i + 1)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                foreach (DataRecord d in this_clusters[i].getRecords())
                {
                    if (first_dim == 0 && second_dim !=0) clusters_chart.Series["Кластер " + (i + 1)].Points.AddXY(0, d.getData()[second_dim-1]);
                     else if (first_dim!=0 && second_dim==0) clusters_chart.Series["Кластер " + (i + 1)].Points.AddXY(d.getData()[first_dim-1], 0);
                    else if (first_dim!=0 && second_dim!=0) clusters_chart.Series["Кластер " + (i + 1)].Points.AddXY(d.getData()[first_dim-1], d.getData()[second_dim-1]);
                    clusters_chart.Series["Кластер " + (i + 1)].MarkerSize = 10;
                }
            }
            clusters_chart.Legends.Add("Кластеры");
            w_host.Child = clusters_chart;
            clusters_chart.Show();
        }

        //Отрисовка графика средних значений по кластерам с помощью все
        //той же импортированной библиотеки
        private void drawAverage(Cluster[] clusters)
        {
            System.Windows.Forms.DataVisualization.Charting.Chart average_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            average_chart.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Default"));
            for (int i = 0; i < clusters.Length; i++)
            {
                average_chart.Series.Add("Кластер " + (i + 1));
                average_chart.Series["Кластер " + (i + 1)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                int index = 1;
                foreach (double d in clusters[i].getCentroid().getData())
                {
                    average_chart.Series["Кластер " + (i + 1)].Points.AddXY(index++, d);
                }
            }
            average_chart.Legends.Add("Кластеры");
            average_host.Child = average_chart;
            average_chart.Show();
        }

        private void boxFirstDim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                drawClusters((int)boxFirstDim.SelectedValue, (int)boxSecondDim.SelectedValue);
            }
            catch
            {

            }
        }

        private void boxSecondDim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                drawClusters((int)boxFirstDim.SelectedValue, (int)boxSecondDim.SelectedValue);
            }
            catch
            {

            }
        }
    }
}