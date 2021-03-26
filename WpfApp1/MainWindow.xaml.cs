using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
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

        public static async void call()
        {
            Task<string> taskBData = GetBillingData(2015);
            string resBData = await taskBData;

            Task<string> taskCData = GetCustomerData();
            string resCData = await taskCData;
        }
        private static async Task<string> GetBillingData(int year)
        {
            string result = "";
            string billingUrl = "https://assessments.reliscore.com/api/billing/";

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(billingUrl + year + "/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string dataObjects = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            httpClient.Dispose();

            MessageBox.Show("GetBillingData");

            return result;
        }

        private static async Task<string> GetCustomerData()
        {
            string result = "";
            string CustomerUrl = "https://assessments.reliscore.com/api/customers/";

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(CustomerUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string dataObjects = response.Content.ReadAsStringAsync().Result;
            }
            httpClient.Dispose();

            MessageBox.Show("GetCustomerData");

            return result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            call();
            MessageBox.Show("I am Here");
        }
    }
}


