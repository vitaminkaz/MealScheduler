<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConstructDinner.aspx.cs" Inherits="ConstructDinner" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
		<style type="text/css">
		.style1
		{
			width: 100%;
		}
		.style3
		{
			}
		.style7
		{
				width: 206px;
			}
			.style8
			{
				height: 26px;
			}
			.style9
			{
				width: 206px;
				height: 26px;
			}
		</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    	<table class="style1">
			<tr>
				<td align="center" class="style3" colspan="3">
					&nbsp;</td>
			</tr>

			<tr>
				<td align="right" class="style3">
					&nbsp;</td>
				<td class="style7">
					&nbsp;</td>
				<td>
					&nbsp;</td>
			</tr>

			<tr>
				<td align="right" class="style3">
					<asp:RadioButton ID="radRecipe" runat="server" Checked="True" 
						Text="Meal Based on Recipe" GroupName="gr1" />
				</td>
				<td class="style7">
					<asp:RadioButton ID="radFood" runat="server" 
						 Text="Meal Based on Food Item" GroupName="gr1" />
				</td>
				<td>
					<asp:Button ID="btnLoadMainCourses" runat="server" 
						onclick="btnLoadMainCourses_Click" Text="Load Main Courses" />
				</td>
			</tr>

			<tr>
				<td align="right" class="style3">
					&nbsp;</td>
				<td class="style7">
					&nbsp;</td>
				<td>
					&nbsp;</td>
			</tr>

			<tr>
				<td align="right" class="style3">
					Main Course:</td>
				<td class="style7">
					<asp:DropDownList ID="ddlMainCourse" runat="server" AutoPostBack="True" 
						onselectedindexchanged="ddlMainCourse_SelectedIndexChanged">
						
					</asp:DropDownList>
				</td>
				<td>
					&nbsp;</td>
			</tr>

			<tr>
				<td align="right" class="style8">
					Side:</td>
				<td class="style9">
					<asp:DropDownList ID="ddlSide" runat="server" 
					onselectedindexchanged="ddlSideTest_SelectedIndexChanged" AutoPostBack="True" >
					
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td align="right" class="style3">
					Second Side:
				</td>
				<td class="style7">
					<asp:DropDownList ID="ddlSide2" runat="server" AutoPostBack="True" 
						onselectedindexchanged="ddlSide2_SelectedIndexChanged" >
					
					</asp:DropDownList>
				</td>
			</tr>

			<tr>
				<td align="right" class="style3">
					Dessert:</td>
				<td class="style7">
					<asp:DropDownList ID="ddlDessert" runat="server" AutoPostBack="True" 
						onselectedindexchanged="ddlDessert_SelectedIndexChanged">
						
					</asp:DropDownList>
				</td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td align="right" class="style3">
				Beverage:</td>
				<td class="style7">
					<asp:DropDownList ID="ddlBeverage" runat="server">
					
					</asp:DropDownList>
				</td>
				<td>
					&nbsp;</td>
			</tr>
		</table>
    
    </div>
   
    </form>
</body>
</html>
