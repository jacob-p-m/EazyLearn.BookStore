<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/LoginMasterPage.Master" AutoEventWireup="true"
	CodeBehind="Login.aspx.cs" Inherits="EazyLearn.BookStore.Admin.Login" %>

<%@ MasterType VirtualPath="~/Layout/LoginMasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="validation_area">
		<asp:Label ID="lblValidationMessage" runat="server" Text=""></asp:Label>
		<div>
			<asp:Label ID="Label1" runat="server" Text="You are in Admin Login now"></asp:Label>

		</div>

	</div>
</asp:Content>
