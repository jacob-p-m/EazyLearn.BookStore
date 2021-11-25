<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/UserInnerPage.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="EazyLearn.BookStore.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvCart_RowDataBound" OnSelectedIndexChanged="gvCart_SelectedIndexChanged">
		<Columns>
			<asp:BoundField DataField="Book Id" HeaderText="Book Id" />
			<asp:BoundField DataField="Book Title" HeaderText="Title" />
			<asp:BoundField DataField="Unit Price" HeaderText="Price" />
			<asp:BoundField DataField="Book Special Price" HeaderText="Special Price" />
			<asp:TemplateField HeaderText="Quantity">
				<ItemTemplate>
					<asp:DropDownList ID="ddlQuantity" runat="server" AutoPostBack="true" Width="60px">
					</asp:DropDownList>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="Total Amount" HeaderText="Total" />

		</Columns>
		<EmptyDataTemplate>
			No items in cart
		</EmptyDataTemplate>
	</asp:GridView>
</asp:Content>
