<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Autores.aspx.cs" Inherits="CrudLibros.Pages.Autores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
       <%-- <div class="mx-auto" style="width:300px">
            <h2>Listado de Libros</h2>
        </div>--%>

        <br />
        
        <div style="display:flex; flex-direction:row; align-items:center; justify-content:center; gap:5px; width:100%">
            <asp:Button ID="btnVolver" runat="server"  CssClass="btn btn-primary form-control-ms" Text="Volver" OnClick="btnVolver_Click"/>
            <h1>Gestion Autores</h1>
        </div>
        <br />
                <div style="display:flex; flex-direction:column; align-items:center; gap:10px;">

                    <div style="display:flex; flex-direction:row; gap:60px; width:388px;">
                        <asp:Label ID="lblIdAutor" runat="server" Text="ID Autor: " Visible="false" Width="99px"></asp:Label>
                        <asp:TextBox ID="txtIDAutor" runat="server" Visible="false" CssClass="form-control input-lg" Height="40px"></asp:TextBox>
                    </div>

                    <div style="display:flex; flex-direction:row; gap:18px">
                        <asp:Label ID="lbNombreAutor" runat="server" Text="Nombre Autor: " Width="162px"></asp:Label>
                        <asp:TextBox ID="txtNombreAutor" runat="server" CssClass="form-control input-lg" Height="40px"></asp:TextBox>
                    </div>

                    <div style="display:flex; flex-direction:row; gap:19px">
                        <asp:Label ID="lbApellidoAutor" runat="server" Text="Apellido Autor: " Width="163px"></asp:Label>
                        <asp:TextBox ID="txtApellidoAutor" runat="server" CssClass="form-control input-lg" Height="40px"></asp:TextBox>
                    </div>

                     <div>
                        <asp:Button ID="btnGuardarAutores" runat="server"  CssClass="btn form-control-ms btn-success" Text="Guardar Actores" OnClick="btnGuardarAutores_Click" />
                        <asp:Button ID="btnModificarAutor" runat="server"  CssClass="btn form-control-ms btn-primary" Text="Actualizar" Visible="false" OnClick="btnModificarAutor_Click"/>
                        <asp:Button ID="btnEliminarAutores" runat="server"  CssClass="btn form-control-ms btn-dark" Text="Eliminar" Visible="false" OnClick="btnEliminarAutores_Click"/>
                        <asp:Button ID="btnCancelarGuaAutor" runat="server"  CssClass="btn form-control-ms btn-danger" Text="Cancelar" OnClick="btnCancelarGuaAutor_Click"/>
                    </div>
                </div>

                <br />

                <div class="container row">
                    <div class="table small" style="margin-left:95px">
                          <asp:GridView ID="gvAutores" runat="server" AllowSorting="True" OnRowCommand="gvAutores_RowCommand" 
                              Width="95%" CssClass="table table-borderless table-hover" AutoGenerateColumns="False" DataKeyNames="idAutor" DataSourceID="dsAutores" >
                                <Columns>
                                    <asp:TemplateField HeaderText="Modificar" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:ImageButton CommandName="modificar" CommandArgument='<%# Eval("idAutor") + ";" + Eval("nombreAutor") + ";" + Eval("apellidoAutor") %>' ID="imgBtnModificarAutor"
                                                CausesValidation="false" runat="server" ImageUrl="~/Imagenes/editar.png" Width="26px" CssClass="ms-3"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="idAutor" HeaderText="Id Autor" InsertVisible="False" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="nombreAutor" HeaderText="Nombre Autor" InsertVisible="False" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="apellidoAutor" HeaderText="Apellidos Autor" ItemStyle-HorizontalAlign="Left" />
                                </Columns>
                           </asp:GridView>
                           <asp:SqlDataSource ID="dsAutores" runat="server" ConnectionString="<%$ ConnectionStrings:libros %>" SelectCommand="listaAutoresSelProc" SelectCommandType="StoredProcedure">
                           </asp:SqlDataSource>
                     </div>
                </div>
    </form>
</asp:Content>
