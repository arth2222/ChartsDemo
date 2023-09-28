<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="superGrid.aspx.cs" Inherits="ChartsDemo.superGrid"  EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" >
                 <Columns>
      
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="SendMail"
                    Text="SendMail" CommandArgument='<%# Eval("pid") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
