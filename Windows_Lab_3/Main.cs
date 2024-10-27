using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Windows_Lab_3
{
    public partial class Main : Form
    {
        Dictionary<string, List<ICarInterface>> BDSourse = new Dictionary<string, List<ICarInterface>>();
        private BindingSource bindingSource = new BindingSource();
        private List<ICarInterface> cars = new List<ICarInterface>();

        private string LastType;
        private int IndexLast; 
        public Main()
        {
            InitializeComponent();
            MainDataGridView.AutoGenerateColumns = false;
            bindingSource.DataSource = cars;
            MainDataGridView.DataSource = bindingSource;
            UploadData();
            InitTestCarsData();
            IndexLast = cars.Count + 1;

            Timer.Interval = 100;
        }
        private void InitTestCarsData()
        {
            cars.Add(new PassengerCar("Toyota", "Camry", 200, 240, "ABC123", "Toyota Media", 5));
            cars.Add(new Truck("Ford", "F-150", 400, 180, "XYZ456", 4, 1.5f));
            cars.Add(new PassengerCar("Honda", "Civic", 150, 220, "DEF789", "Honda Media", 5));
            cars.Add(new Truck("Chevrolet", "Silverado", 350, 190, "GHI012", 4, 1.8f));
            cars.Add(new PassengerCar("BMW", "3 Series", 250, 250, "JKL345", "BMW Media", 5));
            cars.Add(new PassengerCar("Mercedes-Benz", "C-Class", 220, 240, "MNO678", "Mercedes Media", 5));
            cars.Add(new PassengerCar("Nissan", "Rogue", 170, 200, "PQR901", "Nissan Media", 5));
            cars.Add(new Truck("Ram", "1500", 395, 180, "STU234", 4, 2.0f));
            cars.Add(new PassengerCar("Volkswagen", "Golf", 180, 210, "VWX567", "Volkswagen Media", 5));
            cars.Add(new PassengerCar("Subaru", "Outback", 175, 200, "YZA890", "Subaru Media", 5));
            cars.Add(new PassengerCar("Hyundai", "Santa Fe", 190, 210, "BCD123", "Hyundai Media", 5));
            cars.Add(new PassengerCar("Kia", "Sorento", 185, 205, "EFG456", "Kia Media", 5));
            cars.Add(new Truck("GMC", "Sierra", 355, 185, "HIJ789", 4, 2.5f));
            cars.Add(new Truck("Toyota", "Tacoma", 280, 175, "KLM012", 4, 1.6f));
            cars.Add(new PassengerCar("Audi", "A4", 240, 250, "NOP345", "Audi Media", 5));
            cars.Add(new PassengerCar("Lexus", "ES", 215, 230, "QRS678", "Lexus Media", 5));
            cars.Add(new PassengerCar("Mazda", "CX-5", 187, 210, "TUV901", "Mazda Media", 5));
            cars.Add(new Truck("Dodge", "Ram", 400, 180, "WXY234", 4, 2.0f));
            cars.Add(new Truck("Jeep", "Wrangler", 270, 160, "ZAB567", 4, 1.8f));
            cars.Add(new PassengerCar("Porsche", "911", 450, 300, "CDE890", "Porsche Media", 2));
            cars.Add(new PassengerCar("Tesla", "Model S", 670, 322, "FGH123", "Tesla Media", 5));
            cars.Add(new PassengerCar("Chrysler", "Pacifica", 287, 200, "IJK456", "Chrysler Media", 7));
            cars.Add(new Truck("Land Rover", "Defender", 395, 200, "LMN789", 4, 2.2f));
            cars.Add(new PassengerCar("Buick", "Enclave", 310, 200, "OPQ012", "Buick Media", 7));
        } // тест значения
        private void UploadData()
        {
            MainDataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Наименование марки", DataPropertyName = "NameBrand" });
            MainDataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Наименование модели", DataPropertyName = "NameModel"});
            MainDataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Мощность л.с.", DataPropertyName = "Power" });
            MainDataGridView.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Масимальная скорость", DataPropertyName = "MaxSpeed" });
            MainDataGridView.Columns.Add(new DataGridViewComboBoxColumn { HeaderText = "Тип", DataPropertyName = "Type", DataSource = new List<string> { "Passenger car", "Truck" }});
        } // столбцы
        private void Form1_Load(object sender, EventArgs e) // старт
        {
            bindingSource.ResetBindings(false); // ???
            UpdateAllRowColors();
            MainDataGridView.CellValueChanged += DataGridView_CellValueChanged; // повторная привязка?

            MainDataGridView.CurrentCellDirtyStateChanged += (s, args) =>       // ???
            {
                if (MainDataGridView.IsCurrentCellDirty) // ???
                {
                    MainDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit); // ???
                }
            };
        }
        private void UpdateAllRowColors() 
        {
            for (int i = 0; i < MainDataGridView.Rows.Count; i++)
            {
                MainDataGridView.Rows[i].Tag = cars[i].NameBrand;
                UpdateRowColor(i);
            }
        } // установка цвета на старте
        private void UpdateRowColor(int index_row)
        {
            string value = MainDataGridView.Rows[index_row].Cells[4].Value as string;

            if (value == "Truck")
            {
                MainDataGridView.Rows[index_row].DefaultCellStyle.BackColor = Color.Orange;
            }
            else if (value == "Passenger car")
            {
                MainDataGridView.Rows[index_row].DefaultCellStyle.BackColor = Color.Gray;
            }
        }  // цвет
        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) 
        {
            if (e.ColumnIndex == MainDataGridView.Columns[4].Index)
            {
                UpdateRowColor(e.RowIndex);
            }

            object cellValue = MainDataGridView[e.ColumnIndex, e.RowIndex].Value;

            ICarInterface car = cars[e.RowIndex];

            if (car.Type != LastType && IndexLast == e.RowIndex)
            {
                if (LastType == "Passenger car")
                {
                    cars[e.RowIndex] = new Truck(car.NameBrand, car.NameModel, car.Power, car.MaxSpeed, car.RegNumber);
                }
                else if (LastType == "Truck")
                {
                    cars[e.RowIndex] = new PassengerCar(car.NameBrand, car.NameModel, car.Power, car.MaxSpeed, car.RegNumber);
                }
            }
            MainDataGridView.CurrentCell = null;
        } // изменения
        private void MainDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DialogResult answer = MessageBox.Show("Хотите внести изменения?", "", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes) { if (e.ColumnIndex == 4) { IndexLast = e.RowIndex;  LastType = MainDataGridView[e.ColumnIndex, e.RowIndex].Value as string; } }
            else if (answer == DialogResult.No) { MainDataGridView.CurrentCell = null; }
        }      // начало изменения
        private void MainDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DialogResult answer = MessageBox.Show("Перейти к таблице марок?", "", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                        Form form = new BrandTable(MainDataGridView.SelectedRows[0].Tag as string, cars, MainDataGridView.SelectedRows[0].Cells[4].Value as string);
                        form.ShowDialog();
                }
            }
        }   // таблица марок
        private void MainDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void MainDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private async void LoadButton_Click(object sender, EventArgs e)
        {
            Timer.Start();
            if (MainDataGridView.SelectedRows != null)
            {
                string name = MainDataGridView.SelectedRows[0].Cells[0].Value as string;
                if (BDSourse.ContainsKey(name))
                {
                    foreach (var car in BDSourse) { cars.AddRange(BDSourse[name]); }
                }
                else 
                {
                    List<ICarInterface> list = await Loader.load(MainDataGridView.SelectedRows[0].Cells[0].Value as string);
                    BDSourse.Add(name, list);
                    cars.AddRange(list);
                }
            }
            else { MessageBox.Show("Вы не выбрали марку"); return; }
            Timer.Stop();
            ProgressBar.Value = 0;
            MessageBox.Show("Данные загружены");
            bindingSource.ResetBindings(false);
            UpdateAllRowColors();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ProgressBar.Value = Loader.GetProgress();
        }
    }
}
