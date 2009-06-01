<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Title="Smart GreenHouse Solutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="960px" cellpadding="3" cellspacing="3">
        <tr>
            <td style="width:190px">
                <asp:Image ID="imgTree" runat="server" ImageUrl="~/images/tree.png" Width="190" Height="213" CssClass="grid_6" /><br />
            </td>
            <td valign="top" style="width:570px">
                <ul>
                    <h2 class="title">Why choose Smart Greenhouse Solutions?</h2>
                    <li>Automated lighting control</li>
                    <li>Automated temperature control</li>
                    <li>Easy web access</li>
                    <li>24 hour customer service</li>
                    <li>Ability to add onto any SGS module</li>
                    <li>3 year warranty</li>
                </ul>
                SGS is the only <span class="green">“Green”</span> environmental control system on the market!
            </td>
            <td valign="top" style="width:200px; text-align:right">
                Add us on FaceBook! <asp:HyperLink ID="hypLinkFacebook" runat="server" Text="(click here)" NavigateUrl="http://www.facebook.com/profile.php?id=1846000627&ref=profile" Target="_blank" />
                <br /><br />
                Add us on Twitter! <asp:HyperLink ID="lbTwitter" runat="server" Text="(click here)" NavigateUrl="http://twitter.com/SmartGreen" Target="_blank" />
                <br /><br />
                <table style="width:200px; text-align:center">
                    <tr>
                        <td>
                            Would you like product updates and special member discounts?
                            <asp:Image ID="imageGreenEnvelope" runat="server" ImageUrl="~/images/greenenvelope.png" Width="158" Height="111" /><br />
                            <asp:Label ID="Label1" runat="server" Text="Join Our Mailing List" ForeColor="Blue" Font-Underline="true" />
                        </td>
                    </tr>
                </table>
                
                <%--<h2 class="title">Would you like product updates and special member discounts?</h2>--%>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <span style="font-weight:bold; text-decoration:underline">Summer Savings</span><br />Now is the time to beat the heat! 
                Purchase our temperature control units at 5% off during the months of July and August.<br />
                Check back soon for our winter promotions.
            </td>
        </tr>
        </table>
        <table width="960px" cellpadding="3" cellspacing="3">
        <tr>
            <td style="vertical-align:text-top; width:500px">
                <ul>
                    <h2 class="title">SGS Green Thumb Modules provide:</h2>
                    <li>Maximum Reliability</li>
                    <li>Easy controls</li>
                    <li>Ease of installation</li>
                    <li>Easy integration with existing Greenhouse control units</li>
                    <li>Savings in up to 30% on Energy Bills</li>
                </ul>
            </td>
            <td style="text-align:left; vertical-align:text-top" valign="top">
                <ul>
                    <h2 class="title">Where to buy?</h2>
                    <li>Convenient online ordering</li>
                    <li>Units available at <span style="text-decoration:underline; color:Blue">select stores</span></li>
                    <li>Conventions and Markets - <span style="text-decoration:underline; color:Blue">Find One</span></li>
                </ul>
                <%--<h2 class="title">Would you like product updates and special member discounts?</h2>
                <asp:Image ID="imageGreenEnvelope" runat="server" ImageUrl="~/images/greenenvelope.png" Width="158" Height="111" /><br />
                <asp:Label ID="Label1" runat="server" Text="Join Our Mailing List" ForeColor="Blue" Font-Underline="true" />--%>
            </td>
        </tr>
        </table>
        <h2 class="title">Testimonials:</h2>
        <table width="960px" cellpadding="3" cellspacing="3">
        <tr>
            <td valign="top" style="width:282px; vertical-align:text-top;">
                <asp:Image ID="imgFarmer1" runat="server" ImageUrl="~/images/farmer1.png" />
            </td>
            <td valign="top" style="text-align:left; vertical-align:text-top;">    
                <span style="font-family:Viner Hand ITC">“A few months ago, I purchased an all-in-one control unit from SGS. I have already noticed a vast improvement in my crop yields.  
                When I first began using the system I had some questions which the customer service department quickly and completely assisted me with.   
                This is an excellent company.  I will be recommending your product to friends.”
                <i>~Ima Grower </i></span>
                <br /><br />
            </td>
            <td rowspan="2" valign="top" style="text-align:center">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/meanGreens.png" /><br />
                Learn more about how our SGS GreenThumb Modules can help your crop yields by playing our real time growing game – 
                <asp:LinkButton ID="lbMeanGreens" runat="server" Text="Mean Greens" onclick="lbMeanGreens_Click" />
            </td>
        </tr>
        <tr>
            <td valign="top" style="width:282px; vertical-align:text-top">
                <asp:Image ID="imgFarmer2" runat="server" ImageUrl="~/images/farmer2.png" />
            </td>
            <td valign="top" style="vertical-align:text-top">
                <span style="font-family:Lucida Handwriting">“I love being able to control my greenhouse from my computer.  
                It is extremely helpful and allows me to spend more time focusing on my crops and not the complicated control units sold by other companies. 
                The support I received during and after my purchase made me feel more confident in my decision to purchase this product. 
                Thank you Smart Greenhouse Solutions!” <i>~Billy Bob Basil</i></span>
            </td>
        </tr>
        </table>
        <table width="960px" cellpadding="3" cellspacing="3">
        <tr>
            <td style="vertical-align:text-top; text-align:center">
                
            </td>
            <td style="vertical-align:text-top; width:400px">
                
            </td>
            <td style="vertical-align:text-top; text-align:center">
                
            </td>
        </tr>
    </table>
    
    <%--<asp:Image ID="imgTree" runat="server" ImageUrl="~/images/tree.png" Width="190" Height="213" CssClass="grid_6" /><br />--%>
    <%--<ul class="grid_10 why">
        <h2 class="title">Why Choose Smart Greenhouse Solutions?</h2>
        <li>Automated lighting control</li>
        <li>Automated temperature control</li>
        <li>Easy web access</li>
        <li>24 hour customer service</li>
        <li>Ability to add onto any SGS module</li>
        <li>3 year warranty</li>
    </ul>--%>
    <%--<ul class="grid_16 features">
        <h2 class="title">SGS Green Thumb Modules provide:</h2>
        <li>Maximum Reliability</li>
        <li>Easy controls</li>
        <li>Ease of installation</li>
        <li>Easy integration with existing Greenhouse control units</li>
        <li>Savings in up to 30% on Energy Bills</li>
    </ul>--%>
</asp:Content>

