using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Gacha_Simulate
{
    class ReadData
    {
        private string DatabaseFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArknightDatabase.txt");
        private string RawDataBase = "";

        public ReadData()
        {
           
        }

        private void ReadFile()
        {
            RawDataBase = File.ReadAllText(DatabaseFilePath);
        }
    }
  
}
