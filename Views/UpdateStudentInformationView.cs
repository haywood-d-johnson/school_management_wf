using school_management_app.Models;
using school_management_app.Services;
using school_management_app.Services.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace school_management_app.Views
{
    public partial class UpdateStudentInformationView : Form
    {
        private UserModel _userModel;
        private readonly StudentModel _studentModel;
        private AddressModel _addressModel;

        private readonly IAddressRepository _addressService;
        private readonly ICommonRepository _commonService;
        private readonly IUserRepository _userService;
        private DataSource _dataSource;

        String updateUserQueryForStudents = "UPDATE SCHOOLMANAGEMENT.USERS u SET u.EMAIL = '{0}', u.PHONE_NUMBER = '{1}', u.PASSWORD_HASH = '{2}' WHERE u.USER_ID = {3}";
        String updateAddressQueryForStudents = "UPDATE SCHOOLMANAGEMENT.ADDRESSES a SET a.STREET = '{0}', a.CITY = '{1}', a.STATE = '{2}', a.COUNTRY = '{3}' WHERE a.ADDRESS_ID = '{4}'";
        public UpdateStudentInformationView(UserModel user, StudentModel studentModel)
        {
            InitializeComponent();

            _userModel = user;
            _studentModel = studentModel;
            
            _addressService = new AddressService();
            _commonService = new CommonService();
            _userService = new UserService();
            _dataSource = new DataSource();
        }

        private void UpdateStudentInformationView_Load(object sender, EventArgs e)
        {

            _addressModel = _addressService.GetAddressInfoFromAddressId(_userModel);

            lblName.Text = $"{_userModel.FIRST_NAME} {_userModel.LAST_NAME}";
            lblStudentID.Text = _studentModel.STUDENT_ID.ToString();
            lblDOB.Text = _userService.FormatDateToString(_userModel.DATE_OF_BIRTH);
            lblStatus.Text = _studentModel.STATUS.ToString();

            btnSave.Visible = false;

            SetInformation();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to edit information? ", "Edit Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                tbxPhoneNum.Text = String.Empty;
                tbxPhoneNum.Enabled = true;
                tbxEmail.Text = String.Empty;
                tbxEmail.Enabled = true;
                tbxCountry.Text = String.Empty;
                tbxCountry.Enabled = true;
                tbxAddrs.Text = String.Empty;
                tbxAddrs.Enabled = true;
                tbxCity.Text = String.Empty;
                tbxCity.Enabled = true;
                tbxState.Text = String.Empty;
                tbxState.Enabled = true;

                btnEdit.Visible = false;
                btnSave.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Save information? ", "Edit Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                bool allTextBoxesEmpty = Controls.OfType<TextBox>().All(t => String.IsNullOrEmpty(t.Text));

                if (!allTextBoxesEmpty)
                {
                    tbxPhoneNum.Text = String.IsNullOrEmpty(tbxPhoneNum.Text) ? _userService.FormatPhoneNumber(_userModel.PHONE_NUMBER.ToString()) : tbxPhoneNum.Text;
                    tbxCountry.Text = String.IsNullOrEmpty(tbxCountry.Text) ? _addressModel.COUNTRY.ToString() : tbxCountry.Text;
                    tbxAddrs.Text = String.IsNullOrEmpty(tbxAddrs.Text) ? _addressModel.STREET.ToString() : tbxAddrs.Text;
                    tbxCity.Text = String.IsNullOrEmpty(tbxCity.Text) ? _addressModel.CITY.ToString() : tbxCity.Text;
                    tbxState.Text = String.IsNullOrEmpty(tbxState.Text) ? _addressModel.STATE.ToString() : tbxState.Text;
                    tbxEmail.Text = String.IsNullOrEmpty(tbxEmail.Text) ? _userModel.EMAIL.ToString() : tbxEmail.Text;
                    tbxPwd.Text = String.IsNullOrEmpty(tbxPwd.Text) ? _commonService.Decrypt(_userModel.PASSWORD_HASH.ToString()) : tbxPwd.Text;
                }

                bool validateUserModelUpdates = false, validateAddressModelUpdates = false;

                UserModel ValidateUserUpdateInfo = _userService.ValidateUpdateInfoForStudents(new UserModel() { EMAIL = tbxEmail.Text, PHONE_NUMBER = tbxPhoneNum.Text, PASSWORD_HASH = tbxPwd.Text });
                if (ValidateUserUpdateInfo.RESPONSE_STATUS == EnumService.StatusConstants.Success) 
                {
                    validateUserModelUpdates = true;
                }

                AddressModel ValidateAddressModel = _addressService.ValidateAddressModelForStudents(new AddressModel() { 
                    COUNTRY = tbxCountry.Text,
                    STREET = tbxAddrs.Text,
                    CITY = tbxCity.Text,
                    STATE = tbxState.Text,
                });
                if (ValidateAddressModel.RESPONSE_STATUS == EnumService.StatusConstants.Success)
                {
                    validateAddressModelUpdates = true;
                }

                if (validateUserModelUpdates && validateAddressModelUpdates)
                {
                    // Update User Model and retreive
                    _dataSource.ExecuteQuery<UserModel>(String.Format(updateUserQueryForStudents, ValidateUserUpdateInfo.EMAIL, _userService.UnformatPhoneNumber(ValidateUserUpdateInfo.PHONE_NUMBER), _commonService.Encrypt(_userModel.PASSWORD_HASH), _userModel.USER_ID));
                    _userModel = _userService.GetById(_userModel.USER_ID);

                    // Update address model and retreive
                    _dataSource.ExecuteQuery<UserModel>(
                        String.Format(updateAddressQueryForStudents, ValidateAddressModel.STREET, ValidateAddressModel.CITY, ValidateAddressModel.STATE, ValidateAddressModel.COUNTRY, _addressModel.ADDRESS_ID));
                    _addressModel = _addressService.GetAddressInfoFromAddressId(_userModel);

                    btnSave.Visible = false;
                    btnEdit.Visible = true;
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    if (!validateUserModelUpdates) sb.Append($"{ValidateUserUpdateInfo.RESPONSE_MESSAGE}");
                    if (!validateUserModelUpdates && !validateAddressModelUpdates) sb.Append(", ");
                    if (!validateAddressModelUpdates) sb.Append(ValidateAddressModel.RESPONSE_MESSAGE);

                    MessageBox.Show(sb.ToString(), "Invalid Information", MessageBoxButtons.OK);
                }

                SetInformation();
            }
        }

        private void SetInformation()
        {

            tbxPhoneNum.Text = _userService.FormatPhoneNumber(_userModel.PHONE_NUMBER.ToString());
            tbxPhoneNum.Enabled = false;
            tbxEmail.Text = _userModel.EMAIL.ToString();
            tbxEmail.Enabled = false;
            tbxCountry.Text = _addressModel.COUNTRY.ToString();
            tbxCountry.Enabled = false;
            tbxAddrs.Text = _addressModel.STREET.ToString();
            tbxAddrs.Enabled = false;
            tbxCity.Text = _addressModel.CITY.ToString();
            tbxCity.Enabled = false;
            tbxState.Text = _addressModel.STATE.ToString();
            tbxState.Enabled = false;
            tbxPwd.Text = _commonService.Decrypt(_userModel.PASSWORD_HASH);
            tbxPwd.Enabled = false;
        }
    }
}
