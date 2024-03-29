﻿using System;


namespace K_Means
{
    public class DataRecord
    {
        private double[] dataset; //Хранилище-вектор параметров записи
        private string name;  //имя текущей записи

        //геттеры и сеттеры для параметров записи
        public void setName(string name)        
        {
            this.name = name;
        }

        public void setData(params double[] input)
        {
            dataset = new double[input.Length];
            for (int i = 0; i < input.Length; i++) dataset[i] = input[i];
        }

        public string getName()
        {
            return name;
        }
        public double[] getData()
        {
            try
            {
                return dataset;
            }
            catch
            {
                throw new ArgumentException("Data cannot be delivered");
            }
        }

        //Метод, возвращающий растояние до другого объекта с
        //помощью указанной меры расстояния
        public double getDistance(DataRecord compared_data, int type)
        {
            if (type == 0) return euclidianDistance(compared_data);
            else if (type == 1) return quadDistance(compared_data);
            else if (type == 2) return manhattanDistance(compared_data);
            else return ChebishevDistance(compared_data);
        }

        //Метод для высчитывания расстояния Чебышева
        public double ChebishevDistance(DataRecord compared_data)
        {
            double[] compared_dataset = compared_data.getData();
            double max = Math.Abs(this.dataset[0] - compared_dataset[0]),temp_sum;
            for (int i = 1; i < dataset.Length; i++)
            {
                temp_sum = Math.Abs(this.dataset[i] - compared_dataset[i]);
                if (temp_sum > max) max = temp_sum;
            }
            return max;
        }

        //Метод для высчитывания манхэттенского расстояния
        public double manhattanDistance(DataRecord compared_data)
        {
            double[] compared_dataset = compared_data.getData();
            double temp_sum = 0;
            for (int i = 0; i < dataset.Length; i++)
            {
                temp_sum += Math.Abs(this.dataset[i] - compared_dataset[i]);
            }
            return temp_sum;
        }

        //Метод для высчитывания квадратичного расстояния
        public double quadDistance(DataRecord compared_data)
        {
            double[] compared_dataset = compared_data.getData();
            double temp_sum = 0;
            for (int i = 0; i < dataset.Length; i++)
            {
                temp_sum += Math.Pow(this.dataset[i] - compared_dataset[i], 2);
            }
            return temp_sum;
        }

        //Метод для высчитывания расстояния Евклида
        public double euclidianDistance(DataRecord compared_data)
        {
            double[] compared_dataset = compared_data.getData();
            double temp_sum = 0;
            for (int i = 0; i < dataset.Length; i++)
            {
                temp_sum += Math.Pow(this.dataset[i] - compared_dataset[i], 2);
            }
            return Math.Sqrt(temp_sum);
        }

        //Метод, высчитывающий расстояние до центроидов кластеров и
        //присваивающий текущий объект наиболее ближнему кластеру
        public void addToCluster(Cluster[] clusters, int type_of_distance)
        {
            double minimal_distance = this.getDistance(clusters[0].getCentroid(),type_of_distance), temp;
            int index_of_cluster = 0;
            for (int i = 1; i < clusters.Length; i++)
            {
                temp = this.getDistance(clusters[i].getCentroid(),type_of_distance);
                if (temp < minimal_distance)
                {
                    index_of_cluster = i;
                    minimal_distance = temp;
                }
            }
            clusters[index_of_cluster].addData(this);
        }
    }
}
