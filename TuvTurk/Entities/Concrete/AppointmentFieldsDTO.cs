using TuvTurk.Entities.Core;

namespace TuvTurk.Entities.Concrete
{
    public class AppointmentFieldDTO 
    {
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }        
        public string PlateNo { get; set; }   
        public string Ruhsat { get; set; }
        public string VehicleType { get; set; }
        public string InspectionType { get; set; }
        public string CityName { get; set; }
        public string StationName { get; set; }
        public double TotalPrice { get; set; }

        

    }
}