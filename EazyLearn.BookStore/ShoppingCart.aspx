<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/UserInnerPage.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="EazyLearn.BookStore.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<h1>Shopping Cart</h1>
	<label>Order No. </label>
	<asp:Label ID="lblOrderId" runat="server" Text="" Font-Bold></asp:Label>
	<asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvCart_RowDataBound"
		OnSelectedIndexChanged="gvCart_SelectedIndexChanged" OnRowDeleting="gvCart_RowDeleting" OnRowCommand="gvCart_RowCommand"
		CellPadding="10" ShowFooter="True">
		<Columns>
			<asp:TemplateField HeaderText="Book Id">
				<EditItemTemplate>
					<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("[Book Id]") %>'></asp:TextBox>
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="lblBookId" runat="server" Text='<%# Bind("[Book Id]") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField DataField="Book Title" HeaderText="Title" />
			<asp:BoundField DataField="Book Price" HeaderText="Price" />
			<asp:TemplateField HeaderText="Special Price">
				<EditItemTemplate>
					<asp:TextBox ID="txtSpecialPrice" runat="server" Text='<%# Bind("[Book Special Price]") %>'></asp:TextBox>
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="lblSpecialPrice" runat="server" Text='<%# Bind("[Book Special Price]") %>'></asp:Label>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Quantity">
				<ItemTemplate>
					<asp:DropDownList ID="ddlQuantity" runat="server" AutoPostBack="true" Width="60px" OnSelectedIndexChanged="gvCart_SelectedIndexChanged">
					</asp:DropDownList>
				</ItemTemplate>
			
				<FooterTemplate>
					<label>Shipping</label><br /><p>-----------</p><label>Total</label>
				</FooterTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Total">
				<EditItemTemplate>
					<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("[Total Amount]") %>'></asp:TextBox>
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Label1" runat="server" Text='<%# Bind("[Total Amount]") %>'></asp:Label>
				</ItemTemplate>
			
				<FooterTemplate>
					<asp:TextBox ID="txtShippingAmount" runat="server" ReadOnly="true" Text="" Width="50"></asp:TextBox><br />
					<asp:TextBox ID="txtBillAmount" runat="server" ReadOnly="true" Text="0" Width="100"></asp:TextBox>

				</FooterTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<ItemTemplate>
					<asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this book?');" CausesValidation="False" CommandArgument='<%# Eval("[Book Id]") %>' CommandName="Delete" Text="Delete"></asp:LinkButton>

				</ItemTemplate>
				<FooterTemplate>
					<asp:Button ID="btnCheckout" runat="server" Text="Checkout"
						OnClientClick="return confirm('Are you sure you want to proceed to checkout?');"
						OnClick="btnCheckout_Click" Width="120" />

				</FooterTemplate>
			</asp:TemplateField>
		</Columns>
		<EmptyDataTemplate>
			No items in cart
		</EmptyDataTemplate>

		<HeaderStyle BackColor="#92B700" ForeColor="White" />
	</asp:GridView>
</asp:Content>
