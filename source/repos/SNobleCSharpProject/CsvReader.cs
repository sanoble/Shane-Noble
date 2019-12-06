using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SNobleCSharpProject
{
    class CsvReader
    {
        /* ======================================
         * CSV Reader
         *
         * This class handles the IO operations.
         * ======================================
         */
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }
        static void GetData()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            string csvFilePath = Path.Combine(directory.FullName, "ProductMixOneWeek.csv");
            //string filePath = ReadFile(csvFilePath);
        }

        public static string ReadFile(string csvFilePath)
        {
            using (var reader = new StreamReader(csvFilePath))
            {
                return reader.ReadToEnd();
            }

        }

        /*
         * Reads CSV file, creates list of contents
         */
        public List<Product> ReadProductMix(string csvFilePath)
        {
            var productMix = new List<Product>();
            int tmpInt = 0;

            using (var reader = new StreamReader(csvFilePath))
            {
                string csvLine = "";
                reader.ReadLine();
                while ((csvLine = reader.ReadLine()) != null)
                {
                    var listItem = new Product();
                    var Part = csvLine.Split(',');
                    listItem.prodName = Part[0];

                    tmpInt = 0;
                    if (int.TryParse(Part[1], out tmpInt))
                        listItem.prodSKU = tmpInt;

                    //Not making Barcode Int because doesn't seem necessary.
                    listItem.prodBarcode = Part[2];
                    listItem.prodCategory = Part[3];
                    listItem.prodSubcategory = Part[4];


                    if (int.TryParse(Part[5], out tmpInt))
                    listItem.prodQuantityMon = tmpInt;
                    if (int.TryParse(Part[6], out tmpInt))
                        listItem.prodTotalMon = tmpInt;

                    if (int.TryParse(Part[7], out tmpInt))
                        listItem.prodQuantityTue = tmpInt;
                    if (int.TryParse(Part[8], out tmpInt))
                        listItem.prodTotalTue = tmpInt;

                    if (int.TryParse(Part[9], out tmpInt))
                        listItem.prodQuantityWed = tmpInt;
                    if (int.TryParse(Part[10], out tmpInt))
                        listItem.prodTotalWed = tmpInt;

                    if (int.TryParse(Part[11], out tmpInt))
                        listItem.prodQuantityThu = tmpInt;
                    if (int.TryParse(Part[12], out tmpInt))
                        listItem.prodTotalThu = tmpInt;

                    if (int.TryParse(Part[13], out tmpInt))
                        listItem.prodQuantityFri = tmpInt;
                    if (int.TryParse(Part[14], out tmpInt))
                        listItem.prodTotalFri = tmpInt;

                    if (int.TryParse(Part[15], out tmpInt))
                        listItem.prodQuantitySat = tmpInt;
                    if (int.TryParse(Part[16], out tmpInt))
                        listItem.prodTotalSat = tmpInt;

                    if (int.TryParse(Part[16], out tmpInt))
                        listItem.prodQuantitySun = tmpInt;
                    if (int.TryParse(Part[17], out tmpInt))
                        listItem.prodTotalSun = tmpInt;

                    productMix.Add(listItem);
                }
            }
            return productMix;
        }

        /* ======================================
         * File Write: Method writes back out to the file.
         *
         * ======================================
         */

        public static void FileWrite(List<Product> productList)
        {
            string DataDirectory = AppDomain.CurrentDomain.BaseDirectory;

            using (var sWriter = new StreamWriter(DataDirectory + "ProductMixOneWeek.csv"))
            {
                foreach (Product pm in productList)
                {
                    sWriter.WriteLine(pm.prodName + "," + pm.prodCategory + "," + pm.prodSubcategory
                        + "," + pm.prodSKU + "," + pm.prodBarcode + "," + pm.prodQuantityMon + "," + pm.prodTotalMon + "," + pm.prodQuantityTue + "," + pm.prodTotalTue + "," + pm.prodQuantityWed + "," + pm.prodTotalWed + "," + pm.prodQuantityThu + "," + pm.prodTotalThu + "," + pm.prodQuantityFri + "," + pm.prodTotalFri + "," + pm.prodQuantitySat + "," + pm.prodTotalSat + "," + pm.prodQuantitySun + "," + pm.prodTotalSun
                        );
                }
            }
        }

    }
}