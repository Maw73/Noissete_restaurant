<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.Master" AutoEventWireup="true" CodeBehind="ClientAccount.aspx.cs" Inherits="Project_client_template.ClientAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <h2>Account settings</h2>
        <div class="row account">
        <div class="row">
            <h3>Personal information</h3>
        </div>
        <div class="row margins flex1">
            <div class="col span-1-of-10 labels">
                <asp:Label CssClass="left-label" Text="Name" runat="server"/>
            </div>
            <div class="col span-2-of-10">
                 <asp:TextBox CssClass="name" type="text" ID="name" name="name" runat="server"/>
            </div>
            <div class="col span-3-of-10">
                <asp:TextBox CssClass="surname" type="text" ID="surname" name="surname" runat="server"/>
            </div>
        </div>
        <div class="row margins">
            <div class="col span-1-of-10">
                <asp:Label CssClass="left-label" Text="Email" runat="server"/>
            </div>
            <div class="col span-2-of-10">
                <asp:TextBox CssClass="email" type="text" ID="email" name="name" runat="server"/>
            </div>
        </div>
        <div class="row margins">
            <div class="col span-1-of-10 birthday-boxes">
                <asp:Label Text="Birthday" runat="server"/>
            </div>
            <div class="col span-2-of-10">
                <asp:TextBox CssClass="birthday1 birthday" type="text" ID="day" name="day" runat="server"/>
                <asp:TextBox CssClass="birthday2 birthday" type="text" ID="month" name="month" runat="server"/>
                <asp:TextBox CssClass="birthday3 birthday" type="text" ID="year" name="year" runat="server"/>
            </div>
        </div>
        
        <div class="row">
            <asp:Button class="btn full-btn" Text="Update" ID="update_btn1" OnClick="Update_Button1" runat="server"/>
        </div>
        <div class="row">
            <h3 class="bf">Change your password</h3>
        </div>
        <div class="row margins">
            <div class="col span-1-of-10">
                <asp:Label class="left-label" Text="Password" runat="server"/>
            </div>
            <div class="col span-2-of-10">
                 <asp:TextBox CssClass="name" type="password" ID="current_pass" name="current_pass" PlaceHolder="Current password" runat="server"/>
            </div>
            <div class="col span-3-of-10">
                <asp:TextBox CssClass="surname" type="password" ID="new_pass" name="new_pass" PlaceHolder="New password" runat="server"/>
            </div>
        </div>
        <div class="row">
            <asp:Button class="btn full-btn" Text="Update" ID="update_btn2" OnClick="Update_Button2" runat="server"/>
        </div>
         <div class="row">
            <h3 class="bf">Your details</h3>
        </div>
        <div class="row margins">
                <textarea name="other_details" ID="other_details" runat="server" ></textarea>
        </div>
        
        <div class="row">
            <asp:Button class="btn full-btn" Text="Update" ID="update_btn3" OnClick="Update_Button3" runat="server"/>
        </div>
        <div class="row">
            <div class="col span-1-of-3">
                <asp:Button class="full-blue btn1" Text="Logout" ID="logout" OnClick="Logout_Button" runat="server"/>
            </div>
            <div class="col span-2-of-3">
                <asp:Button class="full-blue btn2" Text="Delete account" ID="delete" OnClick="Delete_Button" runat="server"/>
            </div>
        </div>
            </div>
    </section>
</asp:Content>
