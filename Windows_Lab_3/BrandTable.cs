using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Lab_3
{
    public partial class BrandTable : Form
    {
        string TagBrand;
        string CarType;
        List<ICarInterface> TempCars;
        public BrandTable(string NameBrand, List<ICarInterface> list, string type) 
        {
            TempCars = list;
            TagBrand = NameBrand;
            CarType = type;
            //DataGridBrand.AllowUserToAddRows = false;
            InitializeComponent();
        }
        private void UploadData()
        {
            if (CarType == "Passenger car")
            {
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Наименование марки" } );
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Наименование модели" });
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Мощность л.с." });
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Масимальная скорость" });
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Тип" });
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Регистрационный номер" });
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Медиа проигрыватель" });
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Количество подушек безопасности" });
            }
            else if (CarType == "Truck")
            {
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Наименование марки" });
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Наименование модели" });
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Мощность л.с." });
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Масимальная скорость" });
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Тип" });
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Регистрационный номер" });
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Количество колес" });
                DataGridBrand.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Вместимость, м^3" });
            }
        }
        private void IntiTestInfo()
        {
            foreach (var car in TempCars)
            {
                if (car.NameBrand == TagBrand && car.Type == CarType)
                {
                    if (car.Type == "Truck") { DataGridBrand.Rows.Add(car.NameBrand, car.NameModel, car.Power, car.MaxSpeed, car.Type, (car as Truck).RegNumber, (car as Truck).WhellsNumber, (car as Truck).Volume); }
                    else if (car.Type == "Passenger car") { DataGridBrand.Rows.Add(car.NameBrand, car.NameModel, car.Power, car.MaxSpeed, car.Type, (car as PassengerCar).RegNumber, (car as PassengerCar).MediaName, (car as PassengerCar).QuantityAirBag); }
                }
            }     
        }

        private void BrandTable_Load(object sender, EventArgs e)
        {          
            UploadData();
            IntiTestInfo();
        }
    }
}
