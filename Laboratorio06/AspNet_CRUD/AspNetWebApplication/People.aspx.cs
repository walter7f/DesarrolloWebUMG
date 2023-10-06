using System;
using System.Web.UI.WebControls;
using AspNetWebApplication.Core.Repositories;

namespace AspNetWebApplication
{
    public partial class People : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void BindGridView()
        {
            var uow = new UnitOfWork();
            var data = uow.PersonRepository.Read();
            GridView1.DataSource = data;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();

            pnlPersonList.Visible = false;
            pnlPerson.Visible = true;

            var uow = new UnitOfWork();
            int personId = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
            var selectedPerson = uow.PersonRepository.ReadById(personId);
            if (selectedPerson != null)
            {
                txtId.Text = selectedPerson.PersonId.ToString();
                txtCode.Text = selectedPerson.Code;
                txtFirstName.Text = selectedPerson.FirstName;
                txtLastName.Text = selectedPerson.LastName;
                txtPhone.Text = selectedPerson.Phone;
                txtAddress.Text = selectedPerson.Address;
                txtBloodType.Text = selectedPerson.BloodType;
            }
            else
            {
                ClearForm();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var personId = Convert.ToInt32(GridView1.DataKeys[rowIndex]["PersonId"]);
            var uow = new UnitOfWork();
            uow.PersonRepository.Delete(personId);

            //var deletePerson = uow.PersonRepository.ReadById(personId);
            //uow.PersonRepository.Delete(deletePerson);
            //uow.Save();

            BindGridView();
        }

        protected void btnAddPerson_Click(object sender, EventArgs e)
        {
            ClearForm();
            pnlPersonList.Visible = false;
            pnlPerson.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var uow = new UnitOfWork();
            var personId = Convert.ToInt32(txtId.Text);
            var person = new PersonItem
            {
                Code = txtCode.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text,
                BloodType = txtBloodType.Text
            };

            if(personId > 0)
            {
                person.PersonId = personId;
                uow.PersonRepository.Update(person);
            }
            else
            {
                uow.PersonRepository.Create(person);
            }

            ClearForm();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            GridView1.EditIndex = -1;
            txtId.Text = "0";
            txtCode.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtBloodType.Text = string.Empty;

            pnlPerson.Visible = false;
            pnlPersonList.Visible = true;
            BindGridView();
        }
    }
}