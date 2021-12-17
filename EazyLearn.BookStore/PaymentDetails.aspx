<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/UserInnerPage.Master" AutoEventWireup="true" CodeBehind="PaymentDetails.aspx.cs" Inherits="EazyLearn.BookStore.PaymentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<p>Order No. </p>
	<asp:Label ID="lblOrderId" runat="server" Text="" Font-Bold></asp:Label>	

	<p>Order Total </p>
	<asp:Label ID="lblOrderTotal" runat="server" Text="" Font-Bold></asp:Label>

	<h3>Credit Card Details</h3>

	<p>Card Type</p>
	<asp:DropDownList ID="ddlCardType" runat="server"></asp:DropDownList>

	<p>Card Number</p>
	<asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
	<asp:RequiredFieldValidator ID="rfvCardNumber" runat="server" ControlToValidate="txtCardNumber" ErrorMessage="*Card Number Required"></asp:RequiredFieldValidator>

	<p>Expiry Month</p>
	<asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>

	<p>Expiry Year</p>
	<asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
	
	<p>CVV</p>
	<asp:TextBox ID="txtCvv" runat="server" TextMode="Password"></asp:TextBox>
	<asp:RequiredFieldValidator ID="rfvCvv" ControlToValidate="txtCvv" ErrorMessage="*Enter the secret code" runat="server"></asp:RequiredFieldValidator><br />

	<asp:Label ID="lblValidation" runat="server" Text=""></asp:Label><br />
	<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"  Text="Submit"/><br />

</asp:Content>
