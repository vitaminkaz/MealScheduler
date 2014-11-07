<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RateFoods2.aspx.cs" Inherits="RateFoods2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    	Please adjust food scores based on your preferences. 1 - extremely dislike, 10 - 
		extremely like<br />
		<asp:ListView ID="ListView2" runat="server" 
			DataSourceID="SqlDataSource1">
			<AlternatingItemTemplate>
				<tr style="">
					<td>
						<asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
					</td>
					<td>
						<asp:Label ID="FoodLabel" runat="server" Text='<%# Eval("Food") %>' />
					</td>
					<td>
						<asp:Label ID="FoodScoreLabel" runat="server" Text='<%# Eval("FoodScore") %>' />
					</td>
				</tr>
			</AlternatingItemTemplate>
			<EditItemTemplate>
				<tr style="">
					<td>
						<asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
							Text="Update" />
						<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
							Text="Cancel" />
					</td>
					<td>
						<asp:TextBox ID="FoodTextBox" runat="server" Text='<%# Bind("Food") %>' />
					</td>
					<td>
						<asp:TextBox ID="FoodScoreTextBox" runat="server" 
							Text='<%# Bind("FoodScore") %>' />
					</td>
				</tr>
			</EditItemTemplate>
			<EmptyDataTemplate>
				<table runat="server" style="">
					<tr>
						<td>
							No data was returned.</td>
					</tr>
				</table>
			</EmptyDataTemplate>
			<InsertItemTemplate>
				<tr style="">
					<td>
						<asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
							Text="Insert" />
						<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
							Text="Clear" />
					</td>
					<td>
						<asp:TextBox ID="FoodTextBox" runat="server" Text='<%# Bind("Food") %>' />
					</td>
					<td>
						<asp:TextBox ID="FoodScoreTextBox" runat="server" 
							Text='<%# Bind("FoodScore") %>' />
					</td>
				</tr>
			</InsertItemTemplate>
			<ItemTemplate>
				<tr style="">
					<td>
						<asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
					</td>
					<td>
						<asp:Label ID="FoodLabel" runat="server" Text='<%# Eval("Food") %>' />
					</td>
					<td>
						<asp:Label ID="FoodScoreLabel" runat="server" Text='<%# Eval("FoodScore") %>' />
					</td>
				</tr>
			</ItemTemplate>
			<LayoutTemplate>
				<table runat="server">
					<tr runat="server">
						<td runat="server">
							<table ID="itemPlaceholderContainer" runat="server" border="0" style="">
								<tr runat="server" style="">
									<th runat="server">
									</th>
									<th runat="server">
										Food</th>
									<th runat="server">
										FoodScore</th>
								</tr>
								<tr ID="itemPlaceholder" runat="server">
								</tr>
							</table>
						</td>
					</tr>
					<tr runat="server">
						<td runat="server" style="">
						</td>
					</tr>
				</table>
			</LayoutTemplate>
			<SelectedItemTemplate>
				<tr style="">
					<td>
						<asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
					</td>
					<td>
						<asp:Label ID="FoodLabel" runat="server" Text='<%# Eval("Food") %>' />
					</td>
					<td>
						<asp:Label ID="FoodScoreLabel" runat="server" Text='<%# Eval("FoodScore") %>' />
					</td>
				</tr>
			</SelectedItemTemplate>
		</asp:ListView>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
			ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
			SelectCommand="SELECT [Food], [FoodScore] FROM [Food]" 
			UpdateCommand="UPDATE Food SET FoodScore = @FoodScore  WHERE Food=@Food">
			<UpdateParameters>
				<asp:Parameter Name="FoodScore" />
				<asp:Parameter Name="Food" />
			</UpdateParameters>
		</asp:SqlDataSource>
    
    </div>
    <p>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Done" 
		Width="82px"  />
    </p>
    </form>
</body>
</html>
