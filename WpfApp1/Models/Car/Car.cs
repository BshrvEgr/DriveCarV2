using System.Collections.Generic;
using System.Linq;

namespace WpfApp1.Models.Car
{
    public class Car
    {
        public string CarId { get; set; }
        public string CarDescription { get; set; }
        public string MainImageCar { get; set; }
        public string Images { get; set; }
        public string PricePerDay { get; set; }
        public string Availability { get; set; }
        public string CarPassportId { get; set; }
        public string CarName { get; set; }
        public string CarBrand { get; set; }
        public string CarCategory { get; set; }
        public string CarPower { get; set; }
        public string CountryOfOrigin { get; set; }
        public string DateRelease { get; set; }

        public List<string> Imgs => Images.Split(';').Where(i => i != "").ToList();
    }
}
