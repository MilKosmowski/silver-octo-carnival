namespace Central_pack
{
    public class ProductObject
    {
        public ProductObject(string settingsFilePath)
        {
        }

        public string SerialNumberFIS { get; set; }
        public string Barcode { get; set; }
        public string UK2 { get; set; }
        public string StatusFIS { get; set; }
        public string APNFromBarcode { get; set; }
    }
}