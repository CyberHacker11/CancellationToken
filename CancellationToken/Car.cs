namespace CancellationToken
{
    public class Car
    {
        public Car(string model, string vendor, short year, string imagePath)
        {
            Model = model;
            Vendor = vendor;
            Year = year;
            ImagePath = imagePath;
        }
        public override string ToString() => $"Model: {Model} Vendor: {Vendor} Year: {Year} ImagePath: {ImagePath}";

        public string Model { get; set; }
        public string Vendor { get; set; }
        public short Year { get; set; }
        public string ImagePath { get; set; }
    }
}
