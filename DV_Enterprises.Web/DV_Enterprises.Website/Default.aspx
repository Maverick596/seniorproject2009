<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Title="Smart GreenHouse Solutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="text-align:center">
<table width="800px" cellpadding="0" cellspacing="0">
    <tr>
        <td style="text-align:center; width:400px" valign="middle">
            <asp:Image ID="imgPlantJar" runat="server" ImageUrl="~/images/plantJar.png" Width="100px" Height="100px" />  
        </td>
        <td style="text-align:center; width:400px" valign="middle">
            (Insert Product Photo here)
        </td>
    </tr>
    <tr>
        <td style="text-align:center">
            <h4 class="title">Why Choose Smart Greenhouse Solutions?</h4>
        </td>
        <td style="text-align:center">
        <h4 class="title">SGS Green Thumb Modules provide:</h4>
        </td>
    </tr>
    <tr>
        <td style="text-align:left; width:400px">
            <ul>
                <li>Automated lighting control</li>
                <li>Automated temperature control</li>
                <li>Easy web access</li>
                <li>24 hour customer service</li>
                <li>Ability to add onto any SGS module</li>
                <li>3 year warranty</li>
            </ul>
        </td>
        <td style="text-align:left; width:400px">
            <ul>
                <li>Maximum Reliability</li>
                <li>Easy controls</li>
                <li>Ease of installation</li>
                <li>Easy integration with existing <br /> Greenhouse control units</li>
                <li>Savings in up to 30% on Energy Bills</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td style="text-align:center; width:400px" valign="middle">
              (Promotion Coming Soon)
        </td>
        <td style="text-align:center; width:400px" valign="middle">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/hands.png" Width="100px" Height="150px" />
        </td>
    </tr>
    <tr>
        <td style="text-align:center; width:400px" valign="middle">
              (Insert Product Photo here)
        </td>
        <td style="text-align:left; width:400px" valign="top">
        <div style="text-align:center"><h4 class="title">Testimonials:</h4></div>
        <br />
        “A few months ago, I purchased an all-in-one control unit from SGS. I have already noticed a vast improvement in my crop yields.  
        When I first began using the system I had some questions which the customer service department quickly and completely assisted me with.   
        This is an excellent company.  I will be recommending your product to friends.”<br />
<div style="text-align:right"><i>~Ima Grower</i></div>

        </td>
    </tr>
</table>
</div>
</asp:Content>

