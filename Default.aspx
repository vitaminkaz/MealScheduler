<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
	
	<div>
	<asp:GridView EnableTheming="True" runat="server" DataKeyNames= "id" 
			DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" 
			AutoGenerateColumns="False">
	<Columns>
	<asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
			ReadOnly="True" SortExpression="id" />
	<asp:BoundField DataField="UserName" HeaderText="UserName" 
			SortExpression="UserName" />
	<asp:BoundField DataField="FirstName" HeaderText="FirstName" 
			SortExpression="FirstName" />
		<asp:BoundField DataField="LastName" HeaderText="LastName" 
			SortExpression="LastName" />
		<asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" 
			SortExpression="EmailAddress" />
		<asp:BoundField DataField="Password" HeaderText="Password" 
			SortExpression="Password" />
	</Columns>
	</asp:GridView>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
			ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
			SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
	</div>
	
</asp:Content>
