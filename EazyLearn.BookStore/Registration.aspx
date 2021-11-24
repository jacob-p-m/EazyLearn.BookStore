<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="EazyLearn.BookStore.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Registration</title>
	<link rel="stylesheet" href="Styles/style.css" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<div class="registration-table-container">

			<div class="adminForm">
				<h3>Enter details here</h3>

				<ul>
					<li>
						<label>
							Name :
						</label>
						<input type="text" id="txtName" runat="server" name="Name" />
					</li>

					<li>
						<label>
							Address :
						</label>
						<textarea id="txtAddress" runat="server" name="Address"></textarea>
					</li>
					<li>
						<label>
							Phone :
						</label>
						<input type="number" id="txtPhone" runat="server" name="Phone" />
					</li>
					<li>
						<label>
							Email :
						</label>
						<input type="email" id="txtEmail" runat="server" name="Email" />
					</li>
					<li>
						<label>
							State :
						</label>
						<input type="text" id="txtState" runat="server" name="State" />
					</li>
					<li>
						<label>
							City :
						</label>
						<input type="text" id="txtCity" runat="server" name="City" />
					</li>
					<li>
						<label>
							Zip Code :
						</label>
						<input type="number" id="txtZipCode" runat="server" name="Zip Code" />
					</li>
					<li>
						<label>
							Password :
						</label>
						<input type="password" id="txtPassword" runat="server" name="Password" />
					</li>
					<li>
						<label></label>
						<span>
							<input type="button" value="submit" name="submit" id="btnSubmit" runat="server" />
							<input type="button" class="can" value="Cancel" name="cancel" id="btnCancel" runat="server" />
						</span>
					</li>
					<li>
						<label id="txtValidation" runat="server"></label>
						<a href="Login.aspx">Back to Login</a>
					</li>
				</ul>
			</div>
		</div>
	</form>
</body>
</html>
