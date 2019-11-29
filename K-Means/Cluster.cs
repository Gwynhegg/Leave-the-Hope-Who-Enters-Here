using System;
using System.Collections.Generic;


namespace K_Means
{
    public class Cluster
    {
        private List<DataRecord> cluster;  //Лист записей, содержащий все записи, принадлежащие кластеру
        private DataRecord current_centroid;  //Текущий центроид
        private DataRecord previous_centroid = null; //Предыдущий центроид для проверки услови выхода

        public Cluster()
        {
            cluster = new List<DataRecord>();
        }

        //Геттеры и сеттеры для записей и центроидов
        public void setCentroid(DataRecord value)
        {
            current_centroid = value;
        }

        public DataRecord getCentroid()
        {
            return current_centroid;
        }

        public DataRecord getPreviousCentroid()
        {
            return previous_centroid;
        }

        //Метод добавления записи в текущий кластер
        public void addData(DataRecord record)
        {
            this.cluster.Add(record);
        }

        //Геттер листа с записями
        public List<DataRecord> getRecords()
        {
            return this.cluster;
        }

        //Вспомогательный метод изменения центроида
        public void changeCentroid()
        {
            previous_centroid = current_centroid;
        }

        //Метод перезаписи центроида после окончания очередной итерации
        public void overrideCentroid()
        {
            double[] temp_vector = new double[this.getCentroid().getData().Length];
            for (int i = 0; i < cluster.Count; i++) temp_vector = sumarizeVectors(temp_vector, cluster[i].getData()); //Суммируем все векторы, входящие в кластер
            for (int i = 0; i < temp_vector.Length; i++) temp_vector[i] /= cluster.Count; //Определяем среднее значение
            changeCentroid();
            current_centroid = new DataRecord();
            current_centroid.setData(temp_vector); //Записываем получившийся центроид в текущий
        }

        //Метод для суммирования двух векторов
        private double[] sumarizeVectors(double[] first, double[] second)
        {
            for (int i = 0; i < first.Length; i++) first[i] +=second[i];
            return first;
        }

        //Метод, проверяющий кластер на условие выхода
        public bool exitCondition()
        {
            double[] first_data = previous_centroid.getData();
            double[] second_data = current_centroid.getData();
            //Если текущий центроид равен предыдущему, то возвращаем true
            for (int i = 0; i < first_data.Length; i++) if (Math.Round(first_data[i],5) != Math.Round(second_data[i],5)) return true;
            return false;
        }

        //Метод для очистки кластера от записей
        public void clearData()
        {
            this.cluster = new List<DataRecord>();
        }
    }
}
