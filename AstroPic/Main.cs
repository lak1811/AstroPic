using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Data.Analysis;
using System.Collections.Generic;

namespace NasaApodProject;
//This file is for using the data from the DF and getting necessary data from it, as well as validifying the records.

public class ListExtraction
{
    static async Task Main(string[] args)
    {
        var presentList = await FetchAndProcessData();
        
        if (presentList != null)
            //This can be used if the user wants to print the result
        {
            //Console.WriteLine("---------------------------RESULT--------------------------------------");
            //Console.WriteLine($"Copyright: {presentList[0]}");
            //Console.WriteLine($"Date: {presentList[1]}");
            //Console.WriteLine($"Title: {presentList[2]}");
            //Console.WriteLine($"Explanation: {presentList[3]}");
            //Console.WriteLine($"HdUrl: {presentList[4]}");
            //Console.WriteLine($"MediaType: {presentList[5]}");
            //Console.WriteLine($"ServiceVersion: {presentList[6]}");
            //Console.WriteLine($"Url: {presentList[7]}");
        }
        else
        {
            Console.WriteLine("No valid row found.");
        }
    }

    public static async Task<List<string>> FetchAndProcessData()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            //TO THE USER OF THIS APPLICATION, PUT YOUR API KEY WHERE IT SAYS "PUTYOURAPIKEYHERE". This API key can be generated 
            //Here https://api.nasa.gov/
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://api.nasa.gov/planetary/apod?api_key=PUTYOURAPIKEYHERE!!!!!!&count=99")
        };

        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();

        // Manually deserialize JSON response
        JArray jsonArray = JArray.Parse(body);

        var dataframe = new Dataframe();
        var df = dataframe.GetDataFrames(jsonArray);

        bool foundValidRow = false;
        int attempts = 0;

        while (attempts < 99 && !foundValidRow)
        {
            Console.WriteLine($"Iteration {attempts + 1}");
            System.Threading.Thread.Sleep(500);
            Random rng = new Random();

            int maximum = Convert.ToInt32(df.Rows.Count);
            int index = rng.Next(0, maximum);

            Console.WriteLine($"Index: {index}");

            bool allColumnsNotEmpty = true;

            // Check if the index is within the valid range
            if (index >= 0 && index < df.Rows.Count)
            {
                foreach (var col in df.Columns)
                {
                    var value = col[index].ToString();
                    

                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Empty value found");
                        allColumnsNotEmpty = false;
                        break;
                    }
                }

                if (allColumnsNotEmpty)
                {
                    foundValidRow = true;
                    return GetRowValues(df, index);
                }
                else
                {
                    Console.WriteLine("Invalid row with empty columns found.");
                }
            }
            else
            {
                Console.WriteLine("Index out of bounds");
            }

            attempts++;

        }


        return null;

    }

    // Method to extract values from a DataFrame row and return them as a list
    public static List<string> GetRowValues(DataFrame df, int index)
    {
        List<string> presentList = new List<string>();

        foreach (var col in df.Columns)
        {

            presentList.Add(col[index].ToString());

        }

        return presentList;
    }
}
