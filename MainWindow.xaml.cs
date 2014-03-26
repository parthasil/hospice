using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data.SqlClient;



namespace Hospice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void lbColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BrowserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private List<Patient> LoadCollectionData()
        {
            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient()
            {
                ID = 101,
                Name = "Mahesh Chand",
                Status = "Active",
                DOB = new DateTime(1975, 2, 23)
                
            });
            patients.Add(new Patient()
            {
                ID = 201,
                Name = "Mike Gold",
                Status = "Active",
                DOB = new DateTime(1982, 4, 12)
               
            });
            patients.Add(new Patient()
            {
                ID = 244,
                Name = "Mathew Cochran",
                Status = "Expired",
                DOB = new DateTime(1985, 9, 11)
                
            });
            return patients;
        }

        private void BtnPatientSearch_Click(object sender, RoutedEventArgs e)
        {

            string connectionString =
                "Data Source=MUSIC-PC-WIN7\\SQLEXPRESS;Initial Catalog=hospiceDB;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                             "SELECT * FROM dbo.Patient", connection))
                {
                    connection.Open();
                    //string result = (string)command.ExecuteScalar();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MessageBox.Show( String.Format("{0} {1} {2}",
                            reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                        }
                    }
                    //MessageBox.Show("Region = " + result);
                }
            }
            BrowserDataGrid.ItemsSource = LoadCollectionData();
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = PatientTab.SelectedIndex;
            PatientTab.SelectedIndex = selectedIndex + 1;
            //MyTabControl.SelectedItem = MyTabItem
            //MyTabItem.IsSelected = True
        }

        private void Btn_ShowHide(object sender, RoutedEventArgs e)
        {
            PatientTab.Items.Remove(TabCurrentProblem);
        }

        private void BtnTest_Enable(object sender, RoutedEventArgs e)
        {
            //PatientTab.Items.Add(TabCurrentProblem);
            TabCurrentProblem.IsEnabled = false;
            PatientName.IsEnabled = false;

            EnablellPatientCtrl(false);
        }

        private void EnablellPatientCtrl(bool enable)
        {
            PatientName.IsEnabled = enable;
            PatientAddress.IsEnabled = enable;
            PatientTelephone.IsEnabled = enable;
            PatientCellphone.IsEnabled = enable;
            PatientNextOfKin.IsEnabled = enable;
            PatientSex.IsEnabled = enable;
            PatientAge.IsEnabled = enable;
            HospitalNumber.IsEnabled = enable;
            PatientReferredByHospital.IsEnabled = enable;
            PatientReferredBySelf.IsEnabled = enable;
            PatientReferredByOther.IsEnabled = enable;
            PatientReferredByOtherText.IsEnabled = enable;
            PatientDistanceFromOffice.IsEnabled = enable;
            PatientReferralDate.IsEnabled = enable;
            PatientFirstVisitDate.IsEnabled = enable;
        }
    }

    public class Patient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Status { get; set; }
        //public bool IsMVP { get; set; }
    }
}
