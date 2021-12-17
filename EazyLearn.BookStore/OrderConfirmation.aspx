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
					<label>Shipping</label><br /><p>-----------</p><label>Total</label>
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
					<asp:TextBox ID="txtShippingAmount" runat="server" ReadOnly="true" Text="" Width="50" BorderStyle="None"></asp:TextBox><br />
						<asp:TextBox ID="txtBillAmount" runat="server" Text="" Width="100" ReadOnly="true" BorderStyle="None"></asp:TextBox>
					</FooterTemplate>
				</asp:TemplateField>
			</Columns>
			<EmptyDataTemplate>
				No Order
			</EmptyDataTemplate>
			
		<HeaderStyle BackColor="#4287f5" ForeColor="White" />
		</asp:GridView>
	<asp:Button ID="btnShopping" runat="server" Text="Continue Shopping" onClick ="btnShopping_Click"/>
</asp:Content>
