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
using CATRA.MQTT.Broker;
using System.Reflection;
using System.Collections;
using System.Collections.Concurrent;
using MQTTnet;
using MQTTnet.Server;
using MQTTnet.Diagnostics;

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
        public class ConsoleLogger : IMqttNetLogger
        {
            readonly object _consoleSyncRoot = new();

            public bool IsEnabled => true;

            public void Publish(MqttNetLogLevel logLevel, string source, string message, object[]? parameters, Exception? exception)
            {
                var foregroundColor = ConsoleColor.White;
                switch (logLevel)
                {
                    case MqttNetLogLevel.Verbose:
                        foregroundColor = ConsoleColor.White;
                        break;

                    case MqttNetLogLevel.Info:
                        foregroundColor = ConsoleColor.Green;
                        break;

                    case MqttNetLogLevel.Warning:
                        foregroundColor = ConsoleColor.DarkYellow;
                        break;

                    case MqttNetLogLevel.Error:
                        foregroundColor = ConsoleColor.Red;
                        break;
                }

                if (parameters?.Length > 0)
                {
                    message = string.Format(message, parameters);
                }

                lock (_consoleSyncRoot)
                {
                    //Console.ForegroundColor = foregroundColor;
                    Debug.WriteLine(message);


                    if (exception != null)
                    {
                        Debug.WriteLine(message);
                        //logify(exception.Message);
                    }
                }
            }
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

        private async void btn_start_broker_Click(object sender, RoutedEventArgs e)
        {

            var mqttFactory = new MqttFactory(new ConsoleLogger());

            var mqttServerOptions = new MqttServerOptionsBuilder().WithDefaultEndpoint().WithDefaultEndpointPort(8880).Build();
            var mqttServer = mqttFactory.CreateMqttServer(mqttServerOptions);
            await mqttServer.StartAsync();

                //Console.WriteLine("Press Enter to exit.");
                //Console.ReadLine();

                // Stop and dispose the MQTT server if it is no longer needed!
                //await mqttServer.StopAsync();
            


        }

        








    }
}
