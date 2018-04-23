using System;
using System.Collections.Generic;
using System.Threading;

namespace Grid_DateOccurring {
    class DataGenerator {
        public DateTime Date { get; set; }
        public decimal Sales { get; set; }        

        public static List<DataGenerator> CreateData() {
            List<DataGenerator> data = new List<DataGenerator>();

            for (int i = 0; i < 100; i++) {
                DataGenerator record = new DataGenerator();
                int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
                DateTime startDate = new DateTime(DateTime.Today.Year, 1, 1);
                Random rand = new Random();
                int range = (DateTime.Today - startDate).Days;  

                record.Sales = new Random(seed).Next(0, 1000);
                record.Date = startDate.AddDays(rand.Next(range));
                data.Add(record);
                Thread.Sleep(3);
            }
            return data;
        }
    }
}
