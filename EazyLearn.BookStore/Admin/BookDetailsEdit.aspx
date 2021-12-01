<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminInnerPage.Master" AutoEventWireup="true" CodeBehind="BookDetailsEdit.aspx.cs" Inherits="EazyLearn.BookStore.Admin.BookDetailsEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="adminForm">
		<h3>Edit Book details here</h3>

		<ul>
			<li>
				<label>
					Title :
				</label>
				<input type="text" id="txtTitle" runat="server" name="Title" />
			</li>

			<li>
				<label>
					Author :
				</label>
				<input type="text" id="txtAuthor" runat="server" name="Author">
			</li>
			<li>
				<label>
					Category :
				</label>
				<asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
			</li>
			<li>
				<label>
					Price :
				</label>
				<input type="number" id="txtPrice" runat="server" name="Price" />
			</li>
			<li>
				<label>
					Add Special Price :
				</label>
				<asp:DropDownList ID="ddlSpecialPriceStatus" runat="server" AutoPostBack="true">
				</asp:DropDownList>
			</li>
			<li>
				<label>
					Special Price :
				</label>
				<input type="number" id="txtSpecialPrice" runat="server" name="SpecialPrice" value="0.00" />
			</li>
			<li>
				<label>
					Description :
				</label>
				<textarea id="txtDescription" runat="server"></textarea>
			</li>
			<li>
				<label>
					Book Cover Page URL :
				</label>
				<textarea id="txtImageUrl" runat="server"></textarea>
			</li>
			<li>
				<label></label>
				<span>
					<input type="button" value="submit" name="submit" id="btnSubmit" runat="server" />
					<input type="button" class="can" value="Cancel" name="cancel" id="btnCancel" runat="server" />
				</span>
			</li>

		</ul>
		<div>

			<label id="txtValidation" runat="server"></label>
		</div>

	</div>
</asp:Content>
