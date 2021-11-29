<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/UserInnerPage.Master" AutoEventWireup="true" CodeBehind="OrderItems.aspx.cs" Inherits="EazyLearn.BookStore.OrderItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h2>Order Details</h2>
	<p>
		<asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False" ShowFooter="True" CellPadding="10">
			<Columns>
				<asp:BoundField DataField="Book Id" HeaderText="Book Id" />
				<asp:BoundField DataField="Book Title" HeaderText="Title" />
				<asp:BoundField DataField="Quantity" HeaderText="Quantity" />
				<asp:BoundField DataField="Unit Price" HeaderText="Price" />
				<asp:TemplateField HeaderText="Total">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("[Total Amount]") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label1" runat="server" Text='<%# Bind("[Total Amount]") %>'></asp:Label>
					</ItemTemplate>
					<FooterTemplate>
						<asp:TextBox ID="txtBillAmount" runat="server" Text=""></asp:TextBox>
					</FooterTemplate>
				</asp:TemplateField>
			</Columns>
			<EmptyDataTemplate>
				No Order
			</EmptyDataTemplate>
			
		<HeaderStyle BackColor="#92B700" ForeColor="White" />
		</asp:GridView>
	</p>
</asp:Content>
