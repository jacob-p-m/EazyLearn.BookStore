<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminInnerPage.Master" AutoEventWireup="true" CodeBehind="BookEdit.aspx.cs" Inherits="EazyLearn.BookStore.Admin.BookEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h3>Book Table</h3>
	<div>
		<asp:GridView ID="gvBookList" runat="server" AutoGenerateColumns="False" OnRowEditing="gvBookList_RowEditing1" PageSize="8" CellPadding="10" AllowPaging="True" OnPageIndexChanging="gvBookList_PageIndexChanging" OnRowDeleting="gvBookList_RowDeleting" OnSelectedIndexChanged="gvBookList_SelectedIndexChanged">
			<PagerStyle HorizontalAlign="Center" />
			<Columns>
				<asp:BoundField DataField="Book Id" HeaderText="Book Id" />
				<asp:BoundField DataField="Book Title" HeaderText="Book Title" />
				<asp:BoundField DataField="Category Name" HeaderText="Category " />
				<asp:CommandField CausesValidation="False" ShowCancelButton="False" ShowEditButton="True" />
				<asp:CommandField ShowDeleteButton="True" />
			</Columns>
			<EmptyDataTemplate>
				No Books
			</EmptyDataTemplate>
			<HeaderStyle BackColor="#92B700" ForeColor="White" />
		</asp:GridView>
	</div>
</asp:Content>
