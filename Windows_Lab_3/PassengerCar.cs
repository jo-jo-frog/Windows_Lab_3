using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Lab_3
{
    public class PassengerCar : ICarInterface
    {
        public string NameBrand { get; set; }
        public string NameModel { get; set; }
        public int Power { get; set; }
        public int MaxSpeed { get; set; }
        public string Type { get; set; }
        public string RegNumber { get; set; }
        public string MediaName { get; set; }
        public int QuantityAirBag { get; set; } 

        public PassengerCar(string name_b, string name_m, int power, int m_speed, string m_regnumber, string m_media, int m_quantity)
        {
            NameBrand = name_b;
            NameModel = name_m;
            Power = power;
            MaxSpeed = m_speed;
            Type = "Passenger car";
            RegNumber = m_regnumber;
            MediaName = m_media;
            QuantityAirBag = m_quantity;
        }

        public PassengerCar(string name_b, string name_m, int power, int m_speed, string m_regnumber) 
        {
            NameBrand = name_b;
            NameModel = name_m;
            Power = power;
            MaxSpeed = m_speed;
            Type = "Passenger car";
            RegNumber = m_regnumber;
            MediaName = "Nothing";
            QuantityAirBag = 0;
        }
    }
}
