using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc.Model
{
    class SensorInfo
    {

        public string Name { get; set; }

        public byte[] StatusPhoto { get; set; }

        public byte[] BatteryPhoto { get; set; }

        public string Temperature { get; set; }

        public string Dampness { get; set; }

        public string StorageStatus { get; set; }

        public string RemainStorage { get; set; }
    }
}
