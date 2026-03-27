using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab8.Utilities
{
    public class JsonHelper
    {
        // Hàm này không dùng <dynamic>, trả về Dictionary cực kỳ ổn định
        public static Dictionary<string, string> ReadData(string fileName, string caseId)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", fileName);
            string jsonContent = File.ReadAllText(path);

            // Đọc toàn bộ file thành một Dictionary lớn
            var allData = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonContent);

            // Trả về đúng CaseId mình cần (ví dụ: TC_UP_01)
            return allData[caseId];
        }
    }
}