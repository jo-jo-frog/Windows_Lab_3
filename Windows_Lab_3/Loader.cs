using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Lab_3
{
    internal class Loader
    {
        private static int progress;
        static List<ICarInterface> cars = new List<ICarInterface>()
        {
            { new PassengerCar("Toyota", "Camry", 203, 210, "ABC123", "JBL", 6) },
            { new PassengerCar("Honda", "Accord", 192, 200, "DEF456", "Bose", 6) },
            { new PassengerCar("Ford", "Fusion", 175, 190, "GHI789", "Sony", 7) },
            { new PassengerCar("Chevrolet", "Malibu", 160, 180, "JKL012", "Pioneer", 6) },
            { new PassengerCar("Kia", "Optima", 185, 195, "STU901", "Harman Kardon", 6) },
            { new PassengerCar("Volkswagen", "Passat", 174, 185, "VWX234", "Dynaudio", 6) },                                           
            { new Truck("Toyota", "Tundra", 381, 115, "TRK012", 4, 1.6f) },
            { new Truck("Ram", "1500", 305, 115, "TRK789", 4, 1.7f) },
            { new PassengerCar("Nissan", "Altima", 182, 195, "MNO345", "Rockford Fosgate", 6) },
            { new Truck("Nissan", "Titan", 400, 115, "TRK345", 4, 1.7f) },
            { new PassengerCar("Subaru", "Legacy", 182, 190, "YZA567", "Harman Kardon", 7) },
            { new PassengerCar("Mazda", "6", 187, 200, "BCD890", "Bose", 6) },
            { new PassengerCar("BMW", "3 Series", 255, 250, "EFG123", "Harman Kardon", 6) },
            { new PassengerCar("Mercedes-Benz", "C-Class", 255, 240, "HIJ456", "Burmester", 6) },
            { new PassengerCar("Hyundai", "Sonata", 191, 200, "PQR678", "Infinity", 7) },
            { new Truck("Chevrolet", "Silverado", 285, 115, "TRK456", 4, 1.6f) },
            { new Truck("Ford", "F-150", 290, 120, "TRK123", 4, 1.5f) },
            { new Truck("GMC", "Sierra", 355, 115, "TRK678", 4, 1.5f) },
            { new Truck("Honda", "Ridgeline", 280, 110, "TRK901", 4, 1.4f) },
            { new Truck("Mercedes-Benz", "X-Class", 250, 110, "TRK234", 4, 1.6f) }
        };
        public Loader() { progress = 0; }
        public static async Task<List<ICarInterface>> load(string name_brand)
        {
            int counter = 1;
            List<ICarInterface> records = new List<ICarInterface>();
            Random random = new Random();
            int num = random.Next(10, 21);
            while (counter != num)
            {
                int choice = random.Next(0, 20);
                ICarInterface car = cars[choice];
                await Task.Delay(random.Next(0, 501));
                if (records.Count == 0) { records.Add(car); }
                if (records.Contains(car)) { continue; }
                else { records.Add(car); counter++; progress = (counter + 1) * 100 / num; }
            }
            progress = 0;
            return records;
        }
        public static int GetProgress()
        {
            return progress;
        }
    }
}
