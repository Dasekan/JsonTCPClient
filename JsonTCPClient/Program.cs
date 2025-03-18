using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

public class Program
{
    private static void Main()
    {
        string serverIp = "127.0.0.1";
        int serverPort = 5000; 

        try
        {
            using (TcpClient client = new TcpClient(serverIp, serverPort))
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                
                Console.WriteLine("Enter method (Random, Add, Subtract):");
                string method = Console.ReadLine();

                Console.WriteLine("Enter first number:");
                int num1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter second number:");
                int num2 = int.Parse(Console.ReadLine());

                
                var request = new { method, Tal1 = num1, Tal2 = num2 };
                string requestJson = JsonSerializer.Serialize(request);

                
                writer.WriteLine(requestJson);
                writer.Flush();

                
                string responseJson = reader.ReadLine();
                Console.WriteLine("Server response: " + responseJson);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}