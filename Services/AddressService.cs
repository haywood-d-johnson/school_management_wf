using Org.BouncyCastle.Asn1.Crmf;
using school_management_app.Models;
using school_management_app.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Services
{
    public class AddressService : IAddressRepository
    {
        private readonly DataSource _dataSource;

        public AddressService()
        {
            _dataSource = new DataSource();
        }

        public AddressModel GetAddressInfoFromAddressId(UserModel user)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"SELECT * FROM SCHOOLMANAGEMENT.ADDRESSES a WHERE a.ADDRESS_ID = {user.ADDRESS_ID}");

            List<AddressModel> addrs = _dataSource.ExecuteQueryAndConvertToList<AddressModel>(query.ToString());

            return addrs.FirstOrDefault();
        }

        public AddressModel ValidateAddressModelForStudents(AddressModel address)
        {
            bool validate =  address.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(string))
                .Any(p => String.IsNullOrEmpty((String)p.GetValue(address)));

            if (!validate)
            {
                return new AddressModel() { RESPONSE_STATUS = EnumService.StatusConstants.Error, RESPONSE_MESSAGE = "Invalid address information" };
            }
            else
            {
                address.RESPONSE_STATUS = EnumService.StatusConstants.Success;
                address.RESPONSE_MESSAGE = "Address Valid";

                return address;
            }
        }
    }
}
