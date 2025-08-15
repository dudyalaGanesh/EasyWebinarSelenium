using System.Globalization;
using CsvHelper;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SeleniumProject.Utilities
{
    public class UserData
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public static class CsvUtils
    {
        public static UserData ReadUserData(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<UserData>().ToList();

            // Assuming only 1 record for simplicity
            return records.FirstOrDefault();
        }
    }
}