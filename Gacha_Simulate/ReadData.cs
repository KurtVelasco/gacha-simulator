using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Gacha_Simulate
{
    class ReadData
    {
        private string DatabaseFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArknightDatabase.txt");
        private string RawDataBase = "";
        public dynamic OperatorDatabase = "";

        public ReadData()
        {
            ReadFile();
            ConvertDynamic();
        }

        private void ReadFile()
        {
            RawDataBase = File.ReadAllText(DatabaseFilePath);
        }
        private void ConvertDynamic()
        {
            OperatorDatabase = JsonConvert.DeserializeObject(RawDataBase);
            RawDataBase = String.Empty;
        }
        public void ClearDynamic()
        {
            OperatorDatabase = String.Empty;
        }
    }
  
}
