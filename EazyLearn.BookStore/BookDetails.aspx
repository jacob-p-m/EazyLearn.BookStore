<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/UserInnerPage.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="EazyLearn.BookStore.BookDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<label>Book Id : </label><asp:Label ID="lblBookId" runat="server" Text=""></asp:Label><br />
	<label>Book Name : </label><asp:Label ID="lblBookName" runat="server" Text=""></asp:Label><br />
	<label>Book Price : </label><asp:Label ID="lblBookPrice" runat="server" Text=""></asp:Label><br />
	<label>Special Price : </label><asp:Label ID="lblBookSpecialPrice" runat="server" Text=""></asp:Label><br />
	<label>Description</label><br />
	<asp:Label ID="lblBookDescription" runat="server" Text=""></asp:Label><br />
	<asp:LinkButton ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click"></asp:LinkButton><br />
</asp:Content>
