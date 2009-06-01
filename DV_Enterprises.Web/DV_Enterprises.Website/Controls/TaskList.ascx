<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TaskList.ascx.cs" Inherits="Controls.TaskList" %>
<h4 class="title"><asp:Literal ID="litTaskTitle" runat="server" /></h4>
<asp:GridView ID="gvwTasks" runat="server" AutoGenerateColumns="false" CssClass="task_list" OnRowDeleting="gvwTasks_RowDeleting">
    <Columns>
        <asp:BoundField HeaderText="Start Time" DataField="StartTime" DataFormatString="{0:t}" HtmlEncode="false" />
        <asp:BoundField HeaderText="Interval" DataField="Interval" DataFormatString="{0:f}" HtmlEncode="false" />
        <asp:CommandField HeaderText="Remove" ShowDeleteButton=true />
    </Columns>
</asp:GridView>

<asp:LinkButton ID="btnAddTask" runat="server" Text="add new" onclick="btnAddTask_Click" />
<asp:Literal ID="litSectionID" runat="server" Visible ="false" />
<asp:Literal ID="litTaskTypeID" runat="server" Visible ="false" />

<asp:Panel ID="pnlAddTask" runat="server" CssClass="form">
    <fieldset>
        <legend>New Task</legend>
        <ol>
            <li>
                <label>Start at:</label>
                <asp:DropDownList ID="ddlStartTimeHours" runat="server" >
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                 :
                <asp:DropDownList ID="ddlStartTimeMinutes" runat="server" >
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>55</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlStartTimeAmPm" runat="server" >
                    <asp:ListItem>am</asp:ListItem>
                    <asp:ListItem>pm</asp:ListItem>
                </asp:DropDownList>
            </li>
            <li>
                <label>Interval</label>
                <asp:DropDownList ID="ddlInterval" runat="server" >
                    <asp:ListItem Value="5">5 min</asp:ListItem>
                    <asp:ListItem Value="10">10 min</asp:ListItem>
                    <asp:ListItem Value="15">15 min</asp:ListItem>
                    <asp:ListItem Value="20">20 min</asp:ListItem>
                    <asp:ListItem Value="25">25 min</asp:ListItem>
                    <asp:ListItem Value="30">30 min</asp:ListItem>
                    <asp:ListItem Value="35">35 min</asp:ListItem>
                    <asp:ListItem Value="40">40 min</asp:ListItem>
                    <asp:ListItem Value="45">45 min</asp:ListItem>
                    <asp:ListItem Value="50">50 min</asp:ListItem>
                    <asp:ListItem Value="55">55 min</asp:ListItem>
                    <asp:ListItem Value="60">60 min</asp:ListItem>
                    <asp:ListItem Value="90">90 min</asp:ListItem>
                    <asp:ListItem Value="120">120 min</asp:ListItem>
                </asp:DropDownList>
            </li>
        </ol>
    </fieldset>
    <fieldset class="buttons">
        <ol>
            <li>
                <asp:Button ID="btnSaveTask" runat="server" Text="Save" 
                    onclick="btnSaveTask_Click" />
            </li>
        </ol>
    </fieldset>
</asp:Panel>