using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common;
using Microsoft.Azure.Devices.Common.Exceptions;

namespace IOTSimulator
{
    public class Program
    {
        private static RegistryManager registryManager1;
        static string connectionString = CloudConfigurationManager.GetSetting("connectionString");
        static string[] devicesIdList = CloudConfigurationManager.GetSetting("deviceList").Split(",".ToCharArray());
        public static void Main(string[] args)
        {

            registryManager1 = RegistryManager.CreateFromConnectionString(connectionString);
            
            AddDevice().Wait();
            Console.ReadLine();
        }


        private static async Task AddDevice()
        {
            Device device;
            try
            {
                device = await registryManager1.GetDeviceAsync("iotdev1");
                Console.WriteLine("working");
            }
            catch (Exception)
            {

            }
            //foreach (var deviceId in devicesIdList)
            //{
            //    try
            //    {
            //        var device1 = new Device(deviceId);
            //        device = registryManager.GetDeviceAsync("iotdev1").Result;
            //        device = registryManager.AddDeviceAsync(device1).Result;
            //    }
            //    catch (DeviceAlreadyExistsException)
            //    {
            //        device = registryManager.GetDeviceAsync(deviceId).Result;
            //    }
            //    Console.WriteLine("Generated device key: {0}", device.Authentication.SymmetricKey.PrimaryKey);
            //}


        }
    }
}
