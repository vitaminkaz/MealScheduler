<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<style type="text/css">
		.style1
		{
			width: 100%;
		}
		.style2
		{
			height: 23px;
		}
		.style3
		{
			text-align: right;
		}
		.style4
		{
			height: 23px;
			text-align: right;
		}
		.style5
		{
			height: 10px;
			text-align: right;
		}
		.style6
		{
			height: 10px;
		}
		.style7
		{
			text-align: right;
			height: 30px;
		}
		.style8
		{
			height: 30px;
		}
		.style9
		{
			width: 193px;
		}
		.style10
		{
			height: 10px;
			width: 193px;
		}
		.style11
		{
			height: 30px;
			width: 193px;
		}
		.style12
		{
			height: 23px;
			width: 193px;
		}
		#btnReset
		{
			width: 58px;
		}
	</style>
	<script language="javascript" type="text/javascript">
// <![CDATA[

		function btnReset_onclick() {

		}

// ]]>
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    	<table class="style1">
			<tr>
				<td class="style3">
					UserName:</td>
				<td class="style9">
					<asp:TextBox ID="txtUserName" runat="server" Width="180px"></asp:TextBox>
				</td>
				<td>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
						ControlToValidate="txtUserName" ErrorMessage="User Name is required." 
						ForeColor="#CC0000"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="style5">
					Email:</td>
				<td class="style10">
					<asp:TextBox ID="txtEmail" runat="server" Width="180px"></asp:TextBox>
				</td>
				<td class="style6">
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
						ControlToValidate="txtEmail" ErrorMessage="Email is required." 
						ForeColor="#CC0000"></asp:RequiredFieldValidator>
					<br />
					<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
						ControlToValidate="txtEmail" ErrorMessage="Invalid email format." 
						ForeColor="#CC0000" 
						ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
				</td>
			</tr>
			<tr>
				<td class="style3">
					Password:</td>
				<td class="style9">
					<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
				</td>
				<td>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
						ControlToValidate="txtPassword" ErrorMessage="Password is required." 
						ForeColor="#CC0000"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td class="style7">
					Confirm Password:</td>
				<td class="style11">
					<asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" 
						Width="180px"></asp:TextBox>
					<br />
				</td>
				<td class="style8">
					<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
						ControlToValidate="txtConfirmPassword" ErrorMessage="Retype password." 
						ForeColor="#CC0000"></asp:RequiredFieldValidator>
					<br />
					<asp:CompareValidator ID="CompareValidator1" runat="server" 
						ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" 
						ErrorMessage="Passwords do not match." ForeColor="#CC0000"></asp:CompareValidator>
				</td>
			</tr>
			<tr>
				<td class="style4">
				</td>
				<td class="style12">
					<asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
						Text="Submit" />
					<input id="btnReset" type="reset" value="Reset" onclick="return btnReset_onclick()" /></td>
				<td class="style2">
				</td>
			</tr>
			<tr>
				<td class="style2">
				</td>
				<td class="style12">
				</td>
				<td class="style2">
				</td>
			</tr>
			<tr>
				<td>
					&nbsp;</td>
				<td class="style9">
					&nbsp;</td>
				<td>
					&nbsp;</td>
			</tr>
		</table>
    
    </div>
    </form>
</body>
</html>
