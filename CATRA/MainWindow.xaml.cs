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
using System.Threading;
using System.Net;
using CATRA.helper;
using System.Diagnostics;

namespace CATRA
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
       








        private string logify(String logstring) { 
        
        return LoggingHelper.logify(logstring);
        }

        private void btn_checkadmins_Click(object sender, RoutedEventArgs e)
        {
            MethodContainer.DoCheckAdmins(tb_log);
        }
        private void btn_provision_Click(object sender, RoutedEventArgs e)
        {
            MethodContainer.DoProvision(tb_log);
        }

        private void btn_unprovision_Click(object sender, RoutedEventArgs e)
        {
            MethodContainer.DoUnProvision(tb_log);
        }


    }
}
