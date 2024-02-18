<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="CrudNet.Pages.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width:250px">
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo" ></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
        <div class ="mb-3">
            <label class="form-label">Nombre</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbnombre"></asp:TextBox>
        </div>
         <div class ="mb-3">
            <label class="form-label">Edad</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbedad"></asp:TextBox>
        </div>
         <div class ="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbemail"></asp:TextBox>
        </div>
         <div class ="mb-3">
            <label class="form-label">Fecha Nacimiento</label>
            <asp:TextBox runat="server" TextMode="date" CssClass="form-control" ID="tbdate"></asp:TextBox>
        </div>
        <asp:Button runat="server" CssClass="btn btn-primary" ID="btncreate" Text="Create" Visible="false"/>
        <asp:Button runat="server" CssClass="btn btn-primary" ID="btnupdate" Text="Update" Visible="false"/>
        <asp:Button runat="server" CssClass="btn btn-primary" ID="btndelete" Text="Delete" Visible="false"/>
        <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="btnvolver" Text="Volver" Visible="false"/>
        </div>
    </form> 
</asp:Content>
