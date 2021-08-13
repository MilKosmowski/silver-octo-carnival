using CustomExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Central_pack
{
    public sealed class CartonObject
    {
        private static CartonObject instance = null;
        private static readonly object padlock = new object();

        CartonObject() { }

        public static CartonObject Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CartonObject();
                    }
                    return instance;
                }
            }
        }

        public string PartNumber1P
        {
            get
            {
                if (string.IsNullOrEmpty(PartNumber1P))
                    return "";
                else
                    return PartNumber1P;
            }

            set { }
        }
        public string QuantityQ
        {
            get
            {
                if (string.IsNullOrEmpty(QuantityQ))
                    return "";
                else
                    return QuantityQ;
            }

            set { }
        }
        public string SerialNumber3S
        {
            get
            {
                if (string.IsNullOrEmpty(SerialNumber3S))
                    return "";
                else
                    return SerialNumber3S;
            }

            set { }
        }
        public string StatusFIS
        {
            get
            {
                if (string.IsNullOrEmpty(StatusFIS))
                    return "";
                else
                    return StatusFIS;
            }

            set { }
        }
        public List<ProductObject> PackedProducts { get; set; }
        public int PackedAmount
        {
            get
            {
                if (MyExtensions.IsEmpty(PackedProducts))
                    return 0;
                else
                    return PackedProducts.Count;
            }
        }

    }
}
