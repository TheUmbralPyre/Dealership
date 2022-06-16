using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Entities.Enums.Cars
{
    public enum Brand
    {
        Volkswagen,
        Opel,
        Audi,
        Mercedes,
        Smart,
        BMW,
        Mini,
        Porsche,
        Peugeot,
        Renault,
        Citroen,
        DS,
        Jaguar,
        [Display(Name = "Land Rover")]
        LandRover,
        Vauxhall,
        Subaru,
        Mitsubishi,
        Nissan,
        Infiniti,
        Toyota,
        Lexus,
        Suziki,
        Mazda,
        Honda,
        Acura,
        Ford,
        Chevrolet,
        Jeep,
        GMC,
        Buick,
        Dodge,
        RAM,
        Cadillac,
        Lincoln,
        Chrysler,
        Tesla,
        Lucid,
        Rivian
    }
}
