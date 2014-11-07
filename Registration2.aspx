<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration2.aspx.cs" Inherits="Registration2" %>

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
			width: 258px;
		}
		.style4
		{
			height: 23px;
			width: 258px;
		}
		.style5
		{
			width: 258px;
			height: 30px;
		}
		.style6
		{
			height: 30px;
		}
		.style7
		{
			width: 97px;
		}
		.style8
		{
			height: 30px;
			width: 97px;
		}
		.style9
		{
			height: 23px;
			width: 97px;
		}
		.style10
		{
			width: 258px;
			height: 26px;
		}
		.style11
		{
			width: 97px;
			height: 26px;
		}
		.style12
		{
			height: 26px;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    	<table class="style1">
			<tr>
				<td align="right" class="style3">
					Age:</td>
				<td class="style7">
					<asp:TextBox ID="txtAge" runat="server" Width="94px"></asp:TextBox>
				</td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td align="right" class="style3">
					Gender:</td>
				<td class="style7">
					<asp:DropDownList ID="ddlGender" runat="server">
						<asp:ListItem>Male</asp:ListItem>
						<asp:ListItem>Female</asp:ListItem>
						<asp:ListItem>Not disclosed</asp:ListItem>
					</asp:DropDownList>
				</td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td align="right" class="style5">
					Height:</td>
				<td class="style8">
					<asp:TextBox ID="txtHeightFeet" runat="server" Height="19px" Width="27px"></asp:TextBox>
&nbsp;ft
					<asp:TextBox ID="txtHeightInches" runat="server" Height="19px" Width="27px"></asp:TextBox>
					<asp:Label ID="Label1" runat="server" Text=" in "></asp:Label>
				</td>
				<td class="style6">
					<br />
				</td>
			</tr>
			<tr>
				<td align="right" class="style3">
					Weight:</td>
				<td class="style7">
					<asp:TextBox ID="txtWeight" runat="server" Height="19px" Width="27px"></asp:TextBox>
					<asp:Label ID="Label2" runat="server" Text=" lb "></asp:Label>
				</td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td class="style4">
				</td>
				<td class="style9">
				</td>
				<td class="style2">
				</td>
			</tr>
			<tr>
				<td align="right" class="style3">
					Rate each of the following on scale from 0 (not important) to 5 (extremely 
					important):</td>
				<td class="style7">
					&nbsp;</td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td class="style3">
					&nbsp;</td>
				<td class="style7">
					&nbsp;</td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td align="right" class="style4">
					Maximize Calorie Intake:</td>
				<td class="style9">
					<asp:TextBox ID="txtCalorieIntakeScore" runat="server" Width="54px"></asp:TextBox>
				</td>
				<td class="style2">
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
						ControlToValidate="txtCalorieIntakeScore" 
						ErrorMessage="Please enter importance for Calorie Intake" 
						style="color: #CC0000"></asp:RequiredFieldValidator>
					<br />
					<asp:RangeValidator ID="RangeValidator1" runat="server" BackColor="#CC0000" 
						ControlToValidate="txtCalorieIntakeScore" 
						ErrorMessage="Value needs to be in range 0 to 5" MaximumValue="5" 
						MinimumValue="0" style="color: #CC0000; background-color: #FFFFFF"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
				<td align="right" class="style4">
					Maximize Nutrition:</td>
				<td class="style9">
					<asp:TextBox ID="txtNutritionScore" runat="server" Width="54px"></asp:TextBox>
				</td>
				<td class="style2">
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
						ControlToValidate="txtNutritionScore" 
						ErrorMessage="Please enter importance for Nutrition" style="color: #CC0000"></asp:RequiredFieldValidator>
					<br />
					<asp:RangeValidator ID="RangeValidator2" runat="server" 
						ControlToValidate="txtNutritionScore" 
						ErrorMessage="Value needs to be in range 0 to 5" ForeColor="#CC0000" 
						MaximumValue="5" MinimumValue="0"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
				<td align="right" class="style10">
					Minimize Nausea:</td>
				<td class="style11">
					<asp:TextBox ID="txtNauseaScore" runat="server" Width="54px"></asp:TextBox>
				</td>
				<td class="style12">
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
						ControlToValidate="txtNauseaScore" 
						ErrorMessage="Please enter importance for Minimizing Nausea" 
						style="color: #CC0000"></asp:RequiredFieldValidator>
					<br />
					<asp:RangeValidator ID="RangeValidator3" runat="server" 
						ControlToValidate="txtNauseaScore" 
						ErrorMessage="Value needs to be in range 0 to 5" ForeColor="#CC0000" 
						MaximumValue="5" MinimumValue="0"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
				<td align="right" class="style3">
					Taste:</td>
				<td class="style7">
					<asp:TextBox ID="txtTasteScore" runat="server" Width="54px"></asp:TextBox>
				</td>
				<td>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
						ControlToValidate="txtTasteScore" 
						ErrorMessage="Please enter importance for Maximizing Taste" 
						style="color: #CC0000"></asp:RequiredFieldValidator>
					<br />
					<asp:RangeValidator ID="RangeValidator4" runat="server" 
						ControlToValidate="txtTasteScore" 
						ErrorMessage="Value needs to be in range 0 to 5" ForeColor="#CC0000" 
						MaximumValue="5" MinimumValue="0"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
				<td class="style3">
					&nbsp;</td>
				<td class="style7">
					&nbsp;</td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td class="style3">
					&nbsp;</td>
				<td class="style7">
					<asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
						Text="Submit" />
				</td>
				<td>
					&nbsp;</td>
			</tr>
		</table>
    
    </div>
    </form>
</body>
</html>
