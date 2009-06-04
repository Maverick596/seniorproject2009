<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Title="Smart GreenHouse Solutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="intro grid_16">
        <div class="grid_6 alpha">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/tree.png" CssClass="grid_6 alpha" />
            <div class="tag">SGS is the only <span class="green">“Green”</span> environmental control system on the market!</div>
        </div>
        <div class="grid_10 omega">
            <ul class="checked">
                <h2 class="title">Why choose Smart Greenhouse Solutions?</h2>
                <li>Automated lighting control</li>
                <li>Automated temperature control</li>
                <li>Easy web access</li>
                <li>24 hour customer service</li>
                <li>Ability to add onto any SGS module</li>
                <li>3 year warranty</li>
            </ul>
            <ul class="checked">
                <h2 class="title">SGS Green Thumb Modules provide:</h2>
                <li>Maximum Reliability</li>
                <li>Easy controls</li>
                <li>Ease of installation</li>
                <li>Easy integration with existing Greenhouse control units</li>
                <li>Savings in up to 30% on Energy Bills</li>
            </ul>
        </div>
    </div>
    
    <div class="grid_16">
        <ul class="grid_5 prefix_1 alpha checked">
            <h2 class="title">Where to buy?</h2>
            <li>Convenient online ordering</li>
            <li>Units available at <span style="text-decoration:underline; color:Blue">select stores</span></li>
            <li>Conventions and Markets - <span style="text-decoration:underline; color:Blue">Find One</span></li>
        </ul>
        <div class="features grid_9 omega suffix_1">   
            <h2 class="title">Summer Savings</h2>
            <p>Now is the time to beat the heat! Purchase our temperature control units at 5% off during the months of July and August. Check back soon for our winter promotions.</p>
        </div>
    </div>
    
        
       
       <p class="grid_16 suffix_1 clearfix">
            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/meanGreens.png" CssClass="grid_2 prefix_1" />
           Learn more about how our SGS GreenThumb Modules can help your crop yields by playing our real time growing game – 
       <asp:HyperLink ID="HyperLink1" runat="server" Text="Mean Greens" NavigateUrl="~/MeanGreens.aspx" />
      </p>
    
    <div class="testimonials clearfix">
        <ul>
            <h2 class="title grid_14 suffix_1 prefix_1">What our Customer think</h2>
            <li class="grid_16">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/images/farmer1.png" CssClass="grid_2 prefix_1" />
                <p class="grid_11 suffix_1">“A few months ago, I purchased an all-in-one control unit from SGS. I have already noticed a vast improvement in my crop yields. When I first began using the system I had some questions which the customer service department quickly and completely assisted me with. This is an excellent company.  I will be recommending your product to friends.”<i>~Ima Grower </i></p>
            </li>
            <li class="grid_16">
                <asp:Image ID="Image5" runat="server" ImageUrl="~/images/farmer2.png" CssClass="grid_2 prefix_1" />
                <p class="grid_11 suffix_1">“I love being able to control my greenhouse from my computer. It is extremely helpful and allows me to spend more time focusing on my crops and not the complicated control units sold by other companies. The support I received during and after my purchase made me feel more confident in my decision to purchase this product. 
                Thank you Smart Greenhouse Solutions!” <i>~Billy Bob Basil</i></p>
            </li>
        </ul>
    </div>
</asp:Content>

