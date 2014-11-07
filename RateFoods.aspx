<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RateFoods.aspx.cs" Inherits="RateFoods" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    	<br />
		<br />
		Rate each food kind on the scale from 1 to 10. 1 - intolerable, 10 - extremely 
		likeable. You will have a chance to do more detailed food raiting on the next 
		page.<br />
&nbsp;<asp:ListView ID="ListView3" runat="server" DataSourceID="SqlDataSource2">
			<AlternatingItemTemplate>
				<tr style="">
					<td>
						<asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
					</td>
					<td>
						<asp:Label ID="FoodKindLabel" runat="server" Text='<%# Eval("FoodKind") %>' />
					</td>
					<td>
						<asp:Label ID="ScoreLabel" runat="server" Text='<%# Eval("Score") %>' />
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
						<asp:TextBox ID="FoodKindTextBox" runat="server" 
							Text='<%# Bind("FoodKind") %>' />
					</td>
					<td>
						<asp:TextBox ID="ScoreTextBox" runat="server" Text='<%# Bind("Score") %>' />
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
						<asp:TextBox ID="FoodKindTextBox" runat="server" 
							Text='<%# Bind("FoodKind") %>' />
					</td>
					<td>
						<asp:TextBox ID="ScoreTextBox" runat="server" Text='<%# Bind("Score") %>' />
					</td>
				</tr>
			</InsertItemTemplate>
			<ItemTemplate>
				<tr style="">
					<td>
						<asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
					</td>
					<td>
						<asp:Label ID="FoodKindLabel" runat="server" Text='<%# Eval("FoodKind") %>' />
					</td>
					<td>
						<asp:Label ID="ScoreLabel" runat="server" Text='<%# Eval("Score") %>' />
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
										FoodKind</th>
									<th runat="server">
										Score</th>
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
						<asp:Label ID="FoodKindLabel" runat="server" Text='<%# Eval("FoodKind") %>' />
					</td>
					<td>
						<asp:Label ID="ScoreLabel" runat="server" Text='<%# Eval("Score") %>' />
					</td>
				</tr>
			</SelectedItemTemplate>
		</asp:ListView>
		<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
			ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
			SelectCommand="SELECT [FoodKind], [Score] FROM [FoodKinds]" UpdateCommand="UPDATE FoodKinds SET Score=@Score   WHERE FoodKind = @FoodKind 
">
			<UpdateParameters>
				<asp:Parameter Name="Score" />
				<asp:Parameter Name="FoodKind" />
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
