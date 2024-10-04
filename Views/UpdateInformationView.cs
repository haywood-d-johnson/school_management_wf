using school_management_app.Models;
using school_management_app.Services;
using school_management_app.Services.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace school_management_app.Views
{
    public partial class UpdateInformationView : Form
    {
        private UserModel _userModel;
        private readonly StudentModel _studentModel;
        private readonly TeacherModel _teacherModel;
        private AddressModel _addressModel;
        

        private readonly IAddressRepository _addressService;
        private readonly ICommonRepository _commonService;
        private readonly IUserRepository _userService;
        private DataSource _dataSource;

        String updateUserQueryForStudents = "UPDATE SCHOOLMANAGEMENT.USERS u SET u.EMAIL = '{0}', u.PHONE_NUMBER = '{1}' WHERE u.USER_ID = {2}";
        String updateAddressQueryForStudents = "UPDATE SCHOOLMANAGEMENT.ADDRESSES a SET a.STREET = '{0}', a.CITY = '{1}', a.STATE = '{2}', a.COUNTRY = '{3}' WHERE a.ADDRESS_ID = '{4}'";
        String updatePwdForStudents = "UPDATE SCHOOLMANAGEMENT.USERS u SET u.PASSWORD_HASH = '{0}' WHERE u.USER_ID = '{1}'";

        public UpdateInformationView(UserModel user, StudentModel studentModel, TeacherModel teacherModel)
        {
            InitializeComponent();

            _userModel = user;
            _studentModel = _userModel.ROLES == EnumService.UserRolesConstants.Student ?  studentModel : null;
            _teacherModel = _userModel.ROLES == EnumService.UserRolesConstants.Teacher ? teacherModel : null;
            
            _addressService = new AddressService();
            _commonService = new CommonService();
            _userService = new UserService();
            _dataSource = new DataSource();
        }

        private void UpdateStudentInformationView_Load(object sender, EventArgs e)
        {

            _addressModel = _addressService.GetAddressInfoFromAddressId(_userModel);

            lblName.Text = $"{_userModel.FIRST_NAME} {_userModel.LAST_NAME}";
            lblIDLabel.Text = _userModel.ROLES == EnumService.UserRolesConstants.Student ? "Student ID:" : "Teacher ID:";
            lblID.Text = _userModel.ROLES == EnumService.UserRolesConstants.Student ? _studentModel.STUDENT_ID.ToString() : _teacherModel.TEACHER_ID.ToString();
            lblDOB.Text = _userService.FormatDateToString(_userModel.DATE_OF_BIRTH);
            lblStatus.Text = _userModel.ROLES == EnumService.UserRolesConstants.Student ? _studentModel.STATUS.ToString() : _teacherModel.STATUS.ToString();

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
                btnPassword.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Save information? ", "Edit Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                bool allTextBoxesEmpty = Controls.OfType<TextBox>().Any(t => String.IsNullOrEmpty(t.Text));

                if (allTextBoxesEmpty)
                {
                    tbxPhoneNum.Text = String.IsNullOrEmpty(tbxPhoneNum.Text) ? _userService.FormatPhoneNumber(_userModel.PHONE_NUMBER.ToString()) : tbxPhoneNum.Text;
                    tbxCountry.Text = String.IsNullOrEmpty(tbxCountry.Text) ? _addressModel.COUNTRY.ToString() : tbxCountry.Text;
                    tbxAddrs.Text = String.IsNullOrEmpty(tbxAddrs.Text) ? _addressModel.STREET.ToString() : tbxAddrs.Text;
                    tbxCity.Text = String.IsNullOrEmpty(tbxCity.Text) ? _addressModel.CITY.ToString() : tbxCity.Text;
                    tbxState.Text = String.IsNullOrEmpty(tbxState.Text) ? _addressModel.STATE.ToString() : tbxState.Text;
                    tbxEmail.Text = String.IsNullOrEmpty(tbxEmail.Text) ? _userModel.EMAIL.ToString() : tbxEmail.Text;
                }

                bool validateUserModelUpdates = false, validateAddressModelUpdates = false;

                UserModel ValidateUserUpdateInfo = _userService.ValidateUpdateInfoForStudents(new UserModel() { EMAIL = tbxEmail.Text, PHONE_NUMBER = tbxPhoneNum.Text });
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
                    _dataSource.ExecuteQuery<UserModel>(String.Format(updateUserQueryForStudents, ValidateUserUpdateInfo.EMAIL, _userService.UnformatPhoneNumber(ValidateUserUpdateInfo.PHONE_NUMBER), _userModel.USER_ID));
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

            tbxPwd.Visible = false;
            tbxPwd.Text = String.Empty;

            tbxVPwd.Visible = false;
            tbxVPwd.Text = String.Empty;

            lblPwdLabel.Visible = false;
            lblVPwdLabel.Visible = false;

            btnSave.Visible = false;
            btnEdit.Visible = true;
            btnEdit.Enabled = true;
            btnSavePwd.Visible = false;
            btnPassword.Visible = true;
            btnPassword.Enabled = true;
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnSavePwd.Visible = true;
            btnPassword.Visible = false;

            tbxPwd.Visible = true;
            tbxVPwd.Visible = true;
            lblPwdLabel.Visible = true;
            lblVPwdLabel.Visible = true;
        }

        private void btnSavePwd_Click(object sender, EventArgs e)
        {
            if (tbxPwd.Text != tbxVPwd.Text)
            {
                MessageBox.Show("Password Mismatch. Please try again.", EnumService.StatusConstants.Error, MessageBoxButtons.OK);
                SetInformation();
            }
            else if (String.IsNullOrEmpty(tbxPwd.Text) || String.IsNullOrEmpty(tbxVPwd.Text))
            {
                SetInformation();
            }
            else
            {
                String hash = _commonService.HashPassword(tbxPwd.Text);
                _dataSource.ExecuteQuery<UserModel>(String.Format(updatePwdForStudents, _commonService.HashPassword(tbxPwd.Text), _userModel.USER_ID));

                MessageBox.Show("Password changed successfully!", EnumService.StatusConstants.Success, MessageBoxButtons.OK);
                SetInformation();
            }
        }
    }
}
