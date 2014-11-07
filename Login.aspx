<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<style type="text/css">
		.style1
		{
			font-size: x-large;
		}
		.style2
		{
			width: 100%;
		}
		.style3
		{
			width: 157px;
		}
		.style4
		{
			width: 164px;
		}
		.style5
		{
			width: 157px;
			height: 31px;
			font-size: small;
		}
		.style6
		{
			width: 164px;
			height: 31px;
		}
		.style7
		{
			height: 31px;
		}
		.style8
		{
			width: 157px;
			font-size: small;
		}
		.style9
		{
			font-size: small;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
    	Login Page<br />
		<table class="style2">
			<tr>
				<td align="right" class="style8">
					User Name:</td>
				<td class="style4">
					<asp:TextBox ID="txtLoginUsername" runat="server" style="font-size: small" 
						Width="180px"></asp:TextBox>
				</td>
				<td>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
						ControlToValidate="txtLoginUsername" CssClass="style9" 
						ErrorMessage="Please Enter Username" ForeColor="#CC0000"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td align="right" class="style5">
					Password:</td>
				<td class="style6">
					<asp:TextBox ID="txtLoginPassword" runat="server" style="font-size: small" 
						Width="180px" TextMode="Password"></asp:TextBox>
				</td>
				<td class="style7">
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
						ControlToValidate="txtLoginPassword" CssClass="style9" 
						ErrorMessage="Please Enter Password" ForeColor="#CC0000"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="style3">
					&nbsp;</td>
				<td class="style4">
					<asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" 
						Text="Log In" />
				</td>
				<td>
					<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Registration.aspx" 
						style="font-size: small">New User Register Here</asp:HyperLink>
				</td>
			</tr>
			<tr>
				<td class="style3">
					&nbsp;</td>
				<td class="style4">
					&nbsp;</td>
				<td>
					&nbsp;</td>
			</tr>
		</table>
    
    </div>
    </form>
</body>
</html>
