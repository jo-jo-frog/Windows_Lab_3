using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Lab_3
{
    public class Truck : ICarInterface
    {
        public string NameBrand { get; set; }
        public string NameModel { get; set; }
        public int Power { get; set; }
        public int MaxSpeed { get; set; }
        public string Type { get; set; }
        public string RegNumber { get; set; }
        public int WhellsNumber { get; set; }
        public float Volume { get; set; } 

        public Truck (string name_b, string name_m, int power, int m_speed, string m_regNumber, int m_whells, float m_volume)
        {
            NameBrand = name_b;
            NameModel = name_m;
            Power = power;
            MaxSpeed = m_speed;
            Type = "Truck";
            RegNumber = m_regNumber;
            WhellsNumber = m_whells;
            Volume = m_volume;
        }

        public Truck(string name_b, string name_m, int power, int m_speed, string m_regnumber)
        {
            NameBrand = name_b;
            NameModel = name_m;
            Power = power;
            MaxSpeed = m_speed;
            Type = "Truck";
            RegNumber = m_regnumber;
            WhellsNumber = 4;
            Volume = 0f;
        }
    }
}
