using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Lab_3
{
    public interface ICarInterface
    {
        string NameBrand { get; set; }
        string NameModel { get; set; }
        int Power { get; set; }
        int MaxSpeed { get; set; }
        string Type { get; set; }
        string RegNumber { get; set; }
    }
}
