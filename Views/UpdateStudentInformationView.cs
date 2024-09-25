using school_management_app.Models;
using school_management_app.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_management_app.Views
{
    public partial class UpdateStudentInformationView : Form
    {
        private readonly UserModel _userModel;
        private readonly StudentModel _studentModel;
        private AddressModel _addressModel;

        private readonly IAddressRepository _addressService;

        public UpdateStudentInformationView(UserModel user, StudentModel studentModel)
        {
            InitializeComponent();

            _userModel = user;
            _studentModel = studentModel;
        }

        private void UpdateStudentInformationView_Load(object sender, EventArgs e)
        {
            _addressModel = _addressService.GetAddressInfoFromAddressId(_userModel);
        }
    }
}
