<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminInnerPage.Master" AutoEventWireup="true" CodeBehind="CategoryManagement.aspx.cs" Inherits="EazyLearn.BookStore.Admin_Pages.CategoryManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<%--<form id="form1" runat="server">--%>

	<h3>Category Table</h3>
	<div>

		<asp:GridView
			ID="gvCategory"
			runat="server"
			ShowFooter="True" AutoGenerateColumns="False"
			OnSelectedIndexChanged="gvCategory_SelectedIndexChanged" Width="503px"
			ShowHeaderWhenEmpty="True" Height="75px" OnRowEditing="gvCategory_RowEditing"
			OnRowUpdating="gvCategory_RowUpdating" OnRowUpdated="gvCategory_RowUpdated"
			OnRowCommand="gvCategory_RowCommand" OnRowDeleting="gvCategory_RowDeleting"
			CssClass="category-table"
			AllowPaging="True" OnRowCancelingEdit="gvCategory_RowCancelingEdit"
			OnPageIndexChanging="gvCategory_PageIndexChanging" PageSize="8" CellPadding="10">
			<PagerStyle HorizontalAlign="Center" />
			<Columns>
				<asp:TemplateField HeaderText="Sl No.">
					<ItemTemplate>
						<%#Container.DataItemIndex+1 %>
					</ItemTemplate>
					<HeaderStyle BackColor="#92B700" ForeColor="White" />
				</asp:TemplateField>
				<asp:TemplateField AccessibleHeaderText="Category Id" HeaderText="Category Id">
					<EditItemTemplate>
						<asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("[Category Id]") %>'></asp:Label>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label1" runat="server" Text='<%# Bind("[Category Id]") %>'></asp:Label>
					</ItemTemplate>
					<HeaderStyle BackColor="#92B700" ForeColor="White" VerticalAlign="Middle" />
				</asp:TemplateField>
				<asp:TemplateField AccessibleHeaderText="Category Name" HeaderText="Category Name">
					<EditItemTemplate>
						<asp:TextBox ID="txtCategoryName" runat="server" Text='<%# Bind("[Category Name]") %>'></asp:TextBox>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:Label ID="Label2" runat="server" Text='<%# Bind("[Category Name]") %>'></asp:Label>
					</ItemTemplate>
					<FooterTemplate>
					</FooterTemplate>
					<HeaderStyle BackColor="#92B700" />
					<HeaderStyle BackColor="#92B700" ForeColor="White" VerticalAlign="Middle" />

				</asp:TemplateField>
				<asp:TemplateField HeaderText="Options">
					<EditItemTemplate>
						<asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="False" CommandArgument='<%# Eval("[Category Id]") %>' CommandName="Update" Text="Update"></asp:LinkButton>
						&nbsp;<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
					</EditItemTemplate>
					<ItemTemplate>
						<asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
						&nbsp;<asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this entry?');" CausesValidation="False" CommandArgument='<%# Eval("[Category Id]") %>' CommandName="Delete" Text="Delete"></asp:LinkButton>
					</ItemTemplate>
					<HeaderStyle BackColor="#92B700" ForeColor="White" />
				</asp:TemplateField>
			</Columns>
			<EmptyDataTemplate>
				No records found
			</EmptyDataTemplate>
		</asp:GridView>
		<div class="search-area">

			<asp:TextBox ID="txtInsert" runat="server" CausesValidation="true"></asp:TextBox>
			<asp:Button ID="btnInsert" runat="server" Text="add" OnClick="btnInsert_Click1" />
		</div>
		<br />
		<div class="validation_area">
			<asp:RequiredFieldValidator ID="rfvtxtInsert" runat="server" ErrorMessage="*Required a valid Category Name" ControlToValidate="txtInsert">
			</asp:RequiredFieldValidator>
		</div>




	</div>
	<%--</form>--%>
</asp:Content>
