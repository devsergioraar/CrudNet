<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CrudNet.Pages.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width:300px">
            <h2>Listado de Registros</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-lg-end">
                    <asp:Button runat="server" ID="btncreate" class="btn btn-success form-control" Text="Create"/>
                </div>
            </div>
        </div>
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvusuarios" class="table table-borderless table-hover">
                    <Columns>
                       <asp:TemplateField HeaderText="Opciones">
                           <ItemTemplate>
                               <asp:Button runat="server" Text="Read" class="btn form-control btn-info" ID="btnread"/>
                               <asp:Button runat="server" Text="Update" class="btn form-control btn-info" ID="btnupdate"/>
                               <asp:Button runat="server" Text="Delete" class="btn form-control btn-info" ID="btndelete"/>
                           </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
