using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZ.Repository.Interfaces;
using WZ.Services.Interfaces;

namespace WZ.Services
{
    public class AddressServices : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressServices(IAddressRepository addressRepository)
        {
            this._addressRepository = addressRepository;
        }

    }
}
