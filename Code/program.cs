using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Simulating incoming requests with IP addresses
        var incomingRequests = new List<string> { "192.168.1.101", "192.168.1.100", "203.0.113.0", "10.0.0.5" };

        // Process each request and check for malicious activity
        foreach (var requestIp in incomingRequests)
        {
            ProcessRequest(requestIp);
        }

        Console.WriteLine("Requests have been processed. Check log for details.");
    }

    // Simulates processing a request
    static void ProcessRequest(string userIp)
    {
        if (IsMaliciousUser(userIp))
        {
            // Log malicious attempt, do not notify the user
            LogMaliciousAttempt(userIp);
        }
        else
        {
            Console.WriteLine($"Request from IP: {userIp} processed successfully.");
        }
    }

    // Checks if the user is considered malicious based on IP
    static bool IsMaliciousUser(string userIp)
    {
        // Example list of known malicious IPs
        var maliciousIpList = new List<string> { "192.168.1.100", "203.0.113.0" }; // Example malicious IPs
        return maliciousIpList.Contains(userIp);
    }

    // Logs the malicious attempt into a file or console (simulating a log system)
    static void LogMaliciousAttempt(string userIp)
    {
        // Logging to console for demo, could be a file or external logging system
        var logEntry = $"Malicious attempt detected from IP: {userIp} at {DateTime.Now}";
        Console.WriteLine(logEntry);

        // Optionally, log to a file
        File.AppendAllText("malicious_traffic_log.txt", logEntry + Environment.NewLine);
    }
}
