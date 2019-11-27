using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization;

namespace K_Means
{
    /// <summary>
    /// Логика взаимодействия для Create.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        Cluster[] this_clusters;
        public ResultWindow()
        {
            InitializeComponent();
        }

        public void drawGraph(Cluster[] clusters)
        {
            this_clusters = clusters;
            DataTable clusters_table = new DataTable();
            DataTable average_table = new DataTable();
            List<string> names = new List<string>();
            clusters_table.Columns.Add("Кластеры");
            average_table.Columns.Add("Кластеры");
            clusters_table.Columns.Add("Элементы кластеров");
            for (int i = 0; i < clusters[0].getCentroid().getData().Length;i++) average_table.Columns.Add("Параметр " + (i + 1));
            for (int i = 0; i < clusters.Length; i++)
            {
                names.Clear();
                foreach (DataRecord e in clusters[i].getRecords()) names.Add(e.getName());
                clusters_table.Rows.Add("Кластер " + (i + 1), String.Join(",", names));
                average_table.Rows.Add("Кластер " + (i + 1));
                double[] temp = clusters[i].getCentroid().getData();
                for (int j = 1; j < temp.Length+1; j++) average_table.Rows[i][j] = Math.Round(temp[j-1], 5);
            }
            outputTable.ItemsSource = clusters_table.AsDataView();
            clustersAverage.ItemsSource = average_table.AsDataView();

            drawAverage(clusters);

            for (int i = 0; i < clusters[0].getCentroid().getData().Length+1; i++)
            {
                boxFirstDim.Items.Add(i);
                boxSecondDim.Items.Add(i);
            }
            boxFirstDim.SelectedIndex = 0;
            boxSecondDim.SelectedIndex = 0;
        }

        private void drawClusters(int first_dim, int second_dim)
        {
            System.Windows.Forms.DataVisualization.Charting.Chart clusters_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            clusters_chart.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Default"));
            for (int i = 0; i < this_clusters.Length; i++)
            {
                clusters_chart.Series.Add("Кластер " + (i + 1));
                clusters_chart.Series["Кластер " + (i + 1)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
                foreach (DataRecord d in this_clusters[i].getRecords())
                {
                    if (first_dim == 0 && second_dim !=0) clusters_chart.Series["Кластер " + (i + 1)].Points.AddXY(0, d.getData()[second_dim-1]);
                     else if (first_dim!=0 && second_dim==0) clusters_chart.Series["Кластер " + (i + 1)].Points.AddXY(d.getData()[first_dim-1], 0);
                    else if (first_dim!=0 && second_dim!=0) clusters_chart.Series["Кластер " + (i + 1)].Points.AddXY(d.getData()[first_dim-1], d.getData()[second_dim-1]);
                }
            }
            clusters_chart.Legends.Add("Кластеры");
            w_host.Child = clusters_chart;
            clusters_chart.Show();
        }

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