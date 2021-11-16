<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminInnerPage.Master" AutoEventWireup="true" CodeBehind="BookEdit.aspx.cs" Inherits="EazyLearn.BookStore.Admin.BookEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h3>Book Table</h3>
	<div>
		<asp:GridView PageSize="8" CellPadding="10"
			ID="gvBookList" runat="server" AutoGenerateColumns="False">
			<PagerStyle HorizontalAlign="Center" />

			<Columns>
				<asp:TemplateField HeaderText="Book Id">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("[Book Id]") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label1" runat="server" Text='<%# Bind("[Book Id]") %>'></asp:Label>
					</ItemTemplate>
					<HeaderStyle BackColor="#92B700" ForeColor="White" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Title">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("[Book Title]") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label2" runat="server" Text='<%# Bind("[Book Title]") %>'></asp:Label>
					</ItemTemplate>
					<HeaderStyle BackColor="#92B700" ForeColor="White" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Price">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("[Book Price]") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label3" runat="server" Text='<%# Bind("[Book Price]") %>'></asp:Label>
					</ItemTemplate>
					<HeaderStyle BackColor="#92B700" ForeColor="White" />
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Special">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("[Book Special Price]") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label4" runat="server" Text='<%# Bind("[Book Special Price]") %>'></asp:Label>
					</ItemTemplate>
					<HeaderStyle BackColor="#92B700" ForeColor="White" />
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
	</div>
</asp:Content>
