using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;

namespace PixelShred
{
    class Program
    {
        [STAThread]
        static void  Main(string[] args)
        {
            string file_path = "";
            using (System.Windows.Forms.OpenFileDialog openDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openDialog.Filter = "PNG|*.png|JPG|*jpg";
                if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        file_path = openDialog.FileName;

                    } catch
                    {
                        Console.WriteLine("Не удалось открыть файл");
                        return;
                    }
                }
            }

            var bitmap = (System.Drawing.Bitmap)Image.FromFile(file_path);
            int[,,] pixel_array = new int[bitmap.Width,bitmap.Height,5];
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixel_array[i, j, 0] = i;
                    pixel_array[i, j, 1] = bitmap.Height - 1-j;
                    pixel_array[i, j, 2] = bitmap.GetPixel(i, j).R;
                    pixel_array[i, j, 3] = bitmap.GetPixel(i, j).G;
                    pixel_array[i, j, 4] = bitmap.GetPixel(i, j).B;
                }
            }
            Excel.Application excelApp = new Excel.Application();

            // Сделать приложение Excel видимым
            ////excelApp.Visible = true;
            excelApp.Interactive = false;
            excelApp.Workbooks.Add();
            Excel._Worksheet workSheet = excelApp.ActiveSheet;
            // Установить заголовки столбцов в ячейках
            workSheet.Cells[1, "A"] = "Номер пикселя";
            workSheet.Cells[1, "B"] = "Координата Х";
            workSheet.Cells[1, "C"] = "Координата У";
            workSheet.Cells[1, "D"] = "R";
            workSheet.Cells[1, "E"] = "G";
            workSheet.Cells[1, "F"] = "B";
            int starting_point = 2;
            Console.WriteLine(bitmap.Width);
            for (int i = 0; i < bitmap.Height; i++)
            {
                Console.WriteLine(i);
                for (int j = 0; j < bitmap.Width; j++)
                {
                    workSheet.Cells[starting_point, "A"] = (starting_point - 1) + " пиксель";
                    workSheet.Cells[starting_point, "B"] = pixel_array[j,i,0];
                    workSheet.Cells[starting_point, "C"] = pixel_array[j, i, 1]; 
                    workSheet.Cells[starting_point, "D"] = pixel_array[j, i, 2]; 
                    workSheet.Cells[starting_point, "E"] = pixel_array[j, i, 3]; 
                    workSheet.Cells[starting_point, "F"] = pixel_array[j, i, 4];
                    starting_point++;
                }
            }
            excelApp.Interactive = true;
            workSheet.SaveAs(string.Format(@"{0}\Pixels.xlsx", Environment.CurrentDirectory));
            excelApp.Quit();
        }
    }
}
