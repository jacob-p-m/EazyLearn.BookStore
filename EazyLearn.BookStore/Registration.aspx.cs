using EazyLearn.BookStore.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EazyLearn.BookStore
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.ServerClick += new EventHandler(this.SubmitButton_Click);
            btnCancel.ServerClick += new EventHandler(this.CancelButton_Click);

        }

        void CancelButton_Click(object sender, EventArgs e)
        {
            ClearBoxes();
        }

        void SubmitButton_Click(object sender, EventArgs e)
        {
            int numberOfRowsAffected;

            if (Check(txtName.Value))
            {
                ShowMessage("*Enter Name");
                return;
            }
            else if (Check(txtAddress.Value))
            {
                ShowMessage("*Enter Address");
                return;
            }
            else if (Check(txtEmail.Value))
            {
                ShowMessage("*Enter Email");
                return;
            }
            else if (Check(txtPhone.Value))
            {
                ShowMessage("*Enter Phone number");
                return;
            }
            else if (Check(txtState.Value))
            {
                ShowMessage("*Enter your State");
                return;
            }
            else if (Check(txtCity.Value))
            {
                ShowMessage("*Enter your city");
                return;
            }
            else if (Check(txtZipCode.Value))
            {
                ShowMessage("*Enter your zip code");
                return;
            }
            else if (Check(txtPassword.Value))
            {
                ShowMessage("*Enter Password");
                return;
            }
            else
            {
                DataTable dt;
                Customer objUser = new Customer();
                objUser.Email = txtEmail.Value;
                dt = objUser.GetUserPassword();

                if (dt.Rows.Count > 0)
                {
                    ShowMessage("*User already exists");
                    return;
                }
                else
                {
                    //------------------------
                    Customer obj = new Customer();
                    obj.CustomerName = txtName.Value;
                    obj.Address = txtAddress.Value;
                    obj.Email = txtEmail.Value;
                    obj.PhoneNumber = txtPhone.Value;
                    obj.City = txtCity.Value;
                    obj.State = txtState.Value;
                    obj.Zip = txtZipCode.Value;
                    obj.Password = txtPassword.Value;
                    numberOfRowsAffected = obj.InsertCustomerDetails();
                    if (numberOfRowsAffected > 0)
                    {
                        //creating new order row for the customer including order number
                        Order objOrder = new Order();
                        objOrder.UserEmail = txtEmail.Value.ToString();
                        objOrder.InsertOrderDetails();

                        ShowMessage("Successfully registration. Now Login to browse books");
                        ClearBoxes();

                   
                    }
                    else
                    {
                        ShowMessage("*Data not inserted");
                    }
                }

            }

        }

        void ShowMessage(string msg)
        {
            txtValidation.InnerText = msg;
        }

        public bool Check(string str)
        {
            if (str == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void ClearBoxes()
        {
            txtName.Value = "";
            txtAddress.Value = "";
            txtPhone.Value = "";
            txtEmail.Value = "";
            txtState.Value = "";
            txtCity.Value = "";
            txtZipCode.Value = "";
            txtPassword.Value = "";
        }
    }
}
