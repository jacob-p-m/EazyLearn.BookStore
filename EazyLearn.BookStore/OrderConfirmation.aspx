<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/UserInnerPage.Master" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="EazyLearn.BookStore.OrderConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h3>Order Summary</h3>
	<asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False" ShowFooter="True" CellPadding="10" GridLines="None">
			<Columns>
				<asp:BoundField DataField="Book Id" HeaderText="Book Id" />
				<asp:BoundField DataField="Book Title" HeaderText="Title" />
				<asp:BoundField DataField="Quantity" HeaderText="Quantity" />
				<asp:TemplateField HeaderText="Price">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("[Unit Price]") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label2" runat="server" Text='<%# Bind("[Unit Price]") %>'></asp:Label>
					</ItemTemplate>
					<FooterTemplate>
						Total
					</FooterTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Total">
					<EditItemTemplate>
						<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("[Total Amount]") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label1" runat="server" Text='<%# Bind("[Total Amount]") %>'></asp:Label>
					</ItemTemplate>
					<FooterTemplate>
						<asp:TextBox ID="txtBillAmount" runat="server" Text="" Width="100" ReadOnly="true" ></asp:TextBox>
					</FooterTemplate>
				</asp:TemplateField>
			</Columns>
			<EmptyDataTemplate>
				No Order
			</EmptyDataTemplate>
			
		<HeaderStyle BackColor="#4287f5" ForeColor="White" />
		</asp:GridView>
</asp:Content>
