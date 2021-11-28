<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/UserInnerPage.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="EazyLearn.BookStore.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<p>Order No.</p>
	<asp:Label ID="lblOrderId" runat="server" Text=""></asp:Label>
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
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Total">
				<EditItemTemplate>
					<asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("[Total Amount]") %>'></asp:TextBox>
				</EditItemTemplate>
				<ItemTemplate>
					<asp:Label ID="Label1" runat="server" Text='<%# Bind("[Total Amount]") %>'></asp:Label>
				</ItemTemplate>
				<FooterTemplate>
					<asp:TextBox ID="txtBillAmount" runat="server" ReadOnly="true" Text="0"></asp:TextBox>
				</FooterTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<ItemTemplate>
						<asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this book?');" CausesValidation="False" CommandArgument='<%# Eval("[Book Id]") %>' CommandName="Delete" Text="Delete"></asp:LinkButton>

				</ItemTemplate>
			</asp:TemplateField>
  		</Columns>
		<EmptyDataTemplate>
			No items in cart
		</EmptyDataTemplate>
		
		<HeaderStyle BackColor="#92B700" ForeColor="White" />
	</asp:GridView>

</asp:Content>
