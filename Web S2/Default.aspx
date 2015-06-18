<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="Web_S2._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   <article><div class="col-md-12">
       <asp:Panel runat="server" CssClass="form-control">
           <asp:ListBox ID="lbArticles" runat="server" OnSelectedIndexChanged="lbArticles_OnSelectedIndexChanged" DataTextField="Title" DataValueField="id"></asp:ListBox><br/>

       <asp:Label runat="server" ID="lblHeader" Text="Title"></asp:Label><br/>
           <asp:TextBox ID="tbbody" runat="server"></asp:TextBox><br/>
           </asp:Panel>
       </div>
          </article> <asp:Panel runat="server"> 
             Comments :<br />
              <div class="col-md-12" >
             Place a Comment :<br />
             <br />
             Titel :
             <asp:TextBox ID="TextBox2" runat="server" Height="18px"></asp:TextBox>
             <br />
             <br />
             <asp:TextBox ID="TextBox1" runat="server" Height="104px" Width="665px"></asp:TextBox>
             <br />
             <br />
             <asp:Button ID="BtnComment" runat="server" OnClick="BtnComment_Click" Text="Place Comment" Width="119px" />
             <br />
             <br />

</div>
             <br />
             </asp:Panel>
         <br />
         <br />
         
</asp:Content>
