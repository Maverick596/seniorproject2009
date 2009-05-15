<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Title="Smart GreenHouse Solutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="grid_8 alpha">
        <asp:Image ID="imgPlantJar" runat="server" ImageUrl="~/images/plantJar.png" Width="100px" Height="100px"/>
        
        <ul>
            <h3 class="title">Why Choose Smart Greenhouse Solutions?</h3>
            <li>Automated lighting control</li>
            <li>Automated temperature control</li>
            <li>Easy web access</li>
            <li>24 hour customer service</li>
            <li>Ability to add onto any SGS module</li>
            <li>3 year warranty</li>
        </ul>
        
        <ul>
            <p>(Promotion Coming Soon)</p>
        </ul>
        
        (Insert Photo Here)
    </div>
    <div class="grid_8 omega">
        (Insert Photo Here)
    
        <ul>
            <h3 class="title">SGS Green Thumb Modules provide:</h3>
            <li>Maximum Reliability</li>
            <li>Easy controls</li>
            <li>Ease of installation</li>
            <li>Easy integration with existing Greenhouse control units</li>
            <li>Savings in up to 30% on Energy Bills</li>
        </ul>
        
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/hands.png" Width="100px" Height="150px" />
        
        <h3 class="title">Testimonials</h3>
        
        <p class="testimonials">“A few months ago, I purchased an all-in-one control unit from SGS. I have already noticed a vast improvement in my crop yields.  
        When I first began using the system I had some questions which the customer service department quickly and completely assisted me with.   
        This is an excellent company.  I will be recommending your product to friends.”<br />
        <span>- Ima Grower</span>
        </p>
        
    </div>
</asp:Content>

