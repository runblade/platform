// Original Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// This application uses the Azure IoT Hub device SDK for .NET
// For samples see: https://github.com/Azure/azure-iot-sdk-csharp/tree/master/iothub/device/samples
// Modified by Sunil Raman for Runblade NEGOTIATOR
// Modifications licensed as Creative Commons CC-BY-NC

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
//using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace simulated_device
{
    class SimulatedDevice
    {
        //Some legacy code from Azure IoT example, just for reference
        private readonly static string s_connectionString = "{Your device connection string here}";
    
        //Simulation data (human-readable stuff, to be used for, well, the simulations)
        
        //PLACEMENT
        private static string[] placementDescExamples = {"Theatre sign", "Cafe FOH", "Mall OLED", "Highway MegaLED", "Transparent AR"};
        private static string[] placementCondExamples = {"MORNING RUSH HOUR", "LUNCHTIME", "EVENING", "WEEKEND NIGHT", "CLOSING TIME", "SPORTS TEAM WIN", "SPECIAL EVENT", "BAD WEATHER", "DANGEROUS CONDITIONS", "CRISIS"};
        
        //CREATIVE
        private static string[] creativeDescExamples = {"Nike-Football-Flex", "Uniqlo-Mens-Tops", "KFC-Rushhour-Promo", "Cool-Refreshing-Beverage", "Disney-Movie-SW10", "Latest-Trendy-Gizmo", "Must-Have-App", "Hyped-Sports-Event", "Government-Federal-Warning", "InformX-Generic"};
        private static string[] creativeCondExamples = {"Minors excluded", "Prefer e-wallet users", "Mandatory state info", "Weather-dependent", "Interactive only", "Time-sensitive", "Fraud-detect flagged"};

        //Utility "global" variables
        private readonly static int SimulationSpeed = 1000; //Miliseconds
        private static Random rand = new Random();
        private static int outputItems = 0;  
        
        //Simulate device telemetry to understand what is happening at device evironment
        //Not sure if location and time should be here as it should pull from API anyway!
        private class DeviceTelemetry 
        {
            public string dID;
            public double dTemperatureCelcius, dBrightness, dTrafficAutomotive, dTrafficHuman, dTrafficOther;  
            public string dCrunchHash; //Runblade CRUNCHER integrity check  
            public void setDeviceTelemetry(double d1, double d2, double d3, double d4, double d5) 
            {
                dID = Guid.NewGuid().ToString().Substring(20).ToUpper();
                dTemperatureCelcius = d1;   //Environmental monitoring
                dBrightness = d2;           //Environment and device monitoring
                dTrafficAutomotive = d3;
                dTrafficHuman = d4;
                dTrafficOther = d5;
                //dCrunchHash = Guid.NewGuid().ToString();
                dCrunchHash =  SimulateCryptography();
            }
        }

        //Simulate placement asks (ad space offers to advertisers)
        private class PlacementAsk 
        {
            public string pID, pDescription, pConditions;   //Human-readable stuff
            public decimal pAskMinAUD, pAskIdealAUD;        //The maths
            public string pCrunchHash;                      //Runblade CRUNCHER integrity check
        
            public void setPlacementAsk (decimal askMin, decimal askIdeal) 
            {
                //Shuffle array
                placementDescExamples = placementDescExamples.OrderBy(x => rand.Next()).ToArray();  
                placementCondExamples = placementCondExamples.OrderBy(x => rand.Next()).ToArray();    
                pID = Guid.NewGuid().ToString().Substring(20).ToUpper();
                pDescription = placementDescExamples[0];
                pConditions = placementCondExamples[0];
                pAskMinAUD = askMin;
                pAskIdealAUD = askIdeal;
                pCrunchHash = SimulateCryptography();
            }
        }

        //Simulate creative bids (ads which advertisers want to display)
        private class CreativeBid 
        {
            public string cID, cDescription, cConditions;   //Human-readable stuff
            public decimal cBidMaxAUD, cBidIdealAUD;        //The maths
            public string cCrunchHash;                      //Runblade CRUNCHER integrity check

            public void setCreativeBid (decimal bidMax, decimal bidIdeal) 
            {
                //Shuffle array
                creativeDescExamples = creativeDescExamples.OrderBy(x => rand.Next()).ToArray();  
                creativeCondExamples = creativeCondExamples.OrderBy(x => rand.Next()).ToArray();    
                cID = Guid.NewGuid().ToString().Substring(20).ToUpper();
                cDescription = creativeDescExamples[0];
                cConditions = creativeCondExamples[0];
                cBidMaxAUD = bidMax;
                cBidIdealAUD = bidIdeal;
                cCrunchHash = SimulateCryptography();
            }
        }

        //Simulate DEVICE feed
        private static void SendDevicesToCloudNonAsync()
        {
            DeviceTelemetry deviceDataChunk = new DeviceTelemetry();          
            while (true)
            {
                outputItems++;
                //Arbitrary simulations
                deviceDataChunk.setDeviceTelemetry(
                    rand.NextDouble() * 5 + 15, 
                    rand.NextDouble() * 5, 
                    Math.Round(rand.NextDouble() * 25000), 
                    Math.Round(rand.NextDouble() * 15000), 
                    rand.NextDouble() * 0.015
                );            
                // Create JSON message
                var messageStringFromNestedClass = JsonConvert.SerializeObject(deviceDataChunk, Formatting.Indented);
                Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageStringFromNestedClass);
                //Just some fancy screen stuff
                //if (outputItems % 10 == 0) 
                //    Console.Clear();
                //This was for async version
                //await Task.Delay(1000);
                // Sleep for x seconds
                System.Threading.Thread.Sleep(SimulationSpeed);
            }
        }

        //Simulate PLACEMENT feed
        private static void SendPlacementsToCloudNonAsync()
        {
            PlacementAsk placementDataChunk = new PlacementAsk();
            while (true) 
            {
                outputItems++;
                //Arbitrary simulations
                placementDataChunk.setPlacementAsk(
                    Decimal.Parse((rand.NextDouble() * 5).ToString()), 
                    Decimal.Parse((rand.NextDouble() * 5).ToString())
                    );  
                // Create JSON message
                var messageStringFromNestedClass = JsonConvert.SerializeObject(placementDataChunk, Formatting.Indented);
                Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageStringFromNestedClass);
                //Just some fancy screen stuff
                //if (outputItems % 10 == 0) 
                //    Console.Clear();
                //This was for async version
                //await Task.Delay(1000);
                // Sleep for x seconds
                System.Threading.Thread.Sleep(SimulationSpeed);
            }
        }

        //Simulate CREATIVE feed
        private static void SendCreativesToCloudNonAsync()
        {
            CreativeBid creativeDataChunk = new CreativeBid();
            while (true) 
            {
                outputItems++;
                //Arbitrary simulations
                creativeDataChunk.setCreativeBid(
                    Decimal.Parse((rand.NextDouble() * 5).ToString()), 
                    Decimal.Parse((rand.NextDouble() * 5).ToString())
                    );  
                // Create JSON message
                var messageStringFromNestedClass = JsonConvert.SerializeObject(creativeDataChunk, Formatting.Indented);
                Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageStringFromNestedClass);
                //Just some fancy screen stuff
                //if (outputItems % 10 == 0) 
                //    Console.Clear();
                //This was for async version
                //await Task.Delay(1000);
                // Sleep for x seconds
                System.Threading.Thread.Sleep(SimulationSpeed);
            }
        }

        private static string SimulateCryptography()
        {
            HashAlgorithm algorithm = SHA256.Create();
            byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
            return Convert.ToBase64String(hash);
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("\n\nIoT Hub Quickstarts #1 - Simulated device (RB-NEGOTIATOR). Ctrl-C to exit.");

            if (args != null && args.Length > 0) 
            {
                if (args[0] == "DEVICE")        
                    SendDevicesToCloudNonAsync();
                else if (args[0] == "PLACEMENT")
                    SendPlacementsToCloudNonAsync();
                else if (args[0] == "CREATIVE")
                    SendCreativesToCloudNonAsync();
		else Console.WriteLine("Oops, you can only choose from DEVICE, PLACEMENT, CREATIVE...");
	    }
            else
            {
                Console.WriteLine("Oops, you need to choose a feed to simulate (DEVICE, PLACEMENT, CREATIVE)...");
            }
        }
    }
}
