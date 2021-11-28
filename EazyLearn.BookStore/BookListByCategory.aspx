<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/UserInnerPage.Master" AutoEventWireup="true" CodeBehind="BookListByCategory.aspx.cs" Inherits="EazyLearn.BookStore.BookListByCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	
	<asp:Label ID="lblCategoryName" runat="server" Text=""></asp:Label><br />
	<asp:GridView ID="gvBookListByCategoryId" runat="server" 
		PageSize="8" CellPadding="10" AutoGenerateColumns="False"
		ShowHeaderWhenEmpty="True" OnRowDataBound="gvBookListByCategoryId_RowDataBound">
			<PagerStyle HorizontalAlign="Center" />
				<HeaderStyle BackColor="#92B700" />
					<HeaderStyle BackColor="#92B700" ForeColor="White" VerticalAlign="Middle" />
		<Columns>
							<asp:TemplateField HeaderText="Sl No.">
					<ItemTemplate>
						<%#Container.DataItemIndex+1 %>
					</ItemTemplate>
					<HeaderStyle BackColor="#92B700" ForeColor="White" />
				</asp:TemplateField>
			<asp:BoundField DataField="Book Title" HeaderText="Title" />
			<asp:BoundField DataField="Book Author" HeaderText="Author" />
			<asp:BoundField DataField="Book Price" HeaderText="Price" />
							<asp:TemplateField HeaderText="Special Price">
								<EditItemTemplate>
									<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("[Book Special Price]") %>'></asp:TextBox>
								</EditItemTemplate>
								<ItemTemplate>
									<asp:Label ID="lblSpecialPrice" runat="server" Text='<%# Bind("[Book Special Price]") %>'></asp:Label>
								</ItemTemplate>
							</asp:TemplateField>
			<asp:BoundField DataField="Book Description" HeaderText="Summary" />
							<asp:HyperLinkField Text="Details" DataNavigateUrlFields="Book Id" DataNavigateUrlFormatString="~/BookDetails.aspx?bookId={0}"/>
		</Columns>
		<EmptyDataTemplate>
			No Books in this category
		</EmptyDataTemplate>
		<HeaderStyle BackColor="#92B700" ForeColor="White" />

	</asp:GridView>
	
</asp:Content>
