using LibraryUWP.Models;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUWP.Services
{

    public static class DeviceService
    {
        private static readonly Random rnd = new Random();

        public static async Task SendMessageAsync(DeviceClient deviceClient)
        {

            while (true)
            {
                var data = new TemperatureModel()
                {
                    Temperature = rnd.Next(20, 30),
                    Humidity = rnd.Next(30, 50)
                };

                // mdl ska konvertera i json format
                var json = JsonConvert.SerializeObject(data);

                //skicka mdl=payload/ Message-från  Microsoft.Azure.Devices.Client;

                var payload = new Message(Encoding.UTF8.GetBytes(json));// Bytes 0 eller 1
                await deviceClient.SendEventAsync(payload);//använda message/ async = await /det skicka mdl i molnet


                await Task.Delay(30 * 1000);
            }
        }

    }
}
