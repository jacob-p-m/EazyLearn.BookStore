<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/UserInnerPage.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="EazyLearn.BookStore.BookDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h2>Book Details</h2>
	<asp:Image ID="imgBook" runat="server" ImageUrl="" Width="200" Height="300" />
	<div id="bookSection" runat="server">

	<label>Book Id : </label><asp:Label ID="lblBookId" runat="server" Text=""></asp:Label><br />
	<asp:Label ID="lblBookName" runat="server" Text="" Font-Bold></asp:Label><br />
	<asp:Label ID="lblBookPrice" runat="server" Text="" Font-Bold></asp:Label><br />
	<asp:Label ID="lblBookSpecialPrice" runat="server" Text="" Font-Italic></asp:Label><br />
	<br />
	<asp:Label ID="lblBookDescription" runat="server" Text="" ></asp:Label><br />
	<asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click"></asp:Button><br />
	</div>
</asp:Content>
