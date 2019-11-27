using System;
using System.Collections.Generic;


namespace K_Means
{
    public class Cluster
    {
        private List<DataRecord> cluster;
        private DataRecord current_centroid;
        private DataRecord previous_centroid = null;

        public Cluster()
        {
            cluster = new List<DataRecord>();
        }

        //Определяем центроиды методом minmax
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

        public void addData(DataRecord record)
        {
            this.cluster.Add(record);
        }

        public List<DataRecord> getRecords()
        {
            return this.cluster;
        }


        public void changeCentroid()
        {
            previous_centroid = current_centroid;
        }

        public void overrideCentroid()
        {
            double[] temp_vector = new double[this.getCentroid().getData().Length];
            for (int i = 0; i < cluster.Count; i++) temp_vector = sumarizeVectors(temp_vector, cluster[i].getData());
            for (int i = 0; i < temp_vector.Length; i++) temp_vector[i] /= cluster.Count;
            changeCentroid();
            current_centroid = new DataRecord();
            current_centroid.setData(temp_vector);
        }

        private double[] sumarizeVectors(double[] first, double[] second)
        {
            for (int i = 0; i < first.Length; i++) first[i] +=second[i];
            return first;
        }

        public bool exitCondition()
        {
            double[] first_data = previous_centroid.getData();
            double[] second_data = current_centroid.getData();
            for (int i = 0; i < first_data.Length; i++) if (Math.Round(first_data[i],5) != Math.Round(second_data[i],5)) return true;
            return false;
        }

        public void clearData()
        {
            this.cluster = new List<DataRecord>();
        }
    }
}
