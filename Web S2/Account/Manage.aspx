<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Web_S2.Account.Manage" %>
<%@ Import Namespace="Web_S2.Account" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                        <h4>Change your password</h4>
                         <div class="form-horizontal">
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Old Pw</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                            <br />
                            <asp:Label ID="lblPass" runat="server" Text="The old password is incorrect." CssClass="text-danger" Visible="false"></asp:Label>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">new Pw</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBox1" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Change Password" OnClick="Changepass" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
