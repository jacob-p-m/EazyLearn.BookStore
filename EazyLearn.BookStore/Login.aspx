<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/LoginMasterPage.Master" AutoEventWireup="true"
	CodeBehind="Login.aspx.cs" Inherits="EazyLearn.BookStore.Login" %>

<%@ MasterType VirtualPath="~/Layout/LoginMasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="validation_area">
		<asp:Label ID="lblValidationMessage" runat="server" Text="*Login to proceed"></asp:Label>
		<div>
			<asp:LinkButton ID="lblAdminLogin" runat="server" Text="Click here if you are Admin" OnClick="lblAdminLogin_Click"></asp:LinkButton>
		</div>

	</div>
</asp:Content>
