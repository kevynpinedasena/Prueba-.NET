<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CrudLibros.Pages.Index" %>
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
        
        <asp:Button ID="btnCrearAutores" runat="server"  CssClass="btn btn-success form-control-ms" Text="Gestion Autores" Visible="true" OnClick="btnCrearAutores_Click"/>
        <asp:Button ID="btnCrearEditores" runat="server"  CssClass="btn btn-success form-control-ms"  Text="Gestion Editores" Visible="true" OnClick="btnCrearEditores_Click"/>

        <h1 style="text-align:center">Gestion Libros</h1>
        <br />

        <div class="contenedorTabla" style="width:100%; display:flex; flex-direction:column; align-items:center; justify-content:center; gap:5px;">

            <div style="display:flex; flex-direction:row; gap:10px;">
                <div style="width:50%; text-align:left">
                    <asp:Label ID="lblISBN" runat="server" Text="ISBN Libros: "></asp:Label>
                </div>

                <div style="width:30%">
                    <asp:TextBox ID="txtISBN" runat="server" Width="300px" onkeypress="javascript:return solonumeros(event)" CssClass="form-control input-lg"></asp:TextBox>
                </div>
            </div>

            <div style="display:flex; flex-direction:row; gap:10px;">
                <div style="width:50%; text-align:left">
                    <asp:Label ID="lblTitulo" runat="server" Text="Titulo Libro: "></asp:Label>
                </div>

                <div style="width:30%">
                    <asp:TextBox ID="txtTitulo" runat="server" Width="300px" CssClass="form-control input-lg"></asp:TextBox>
                </div>
            </div>

            <div style="display:flex; flex-direction:row; gap:10px;">

                <div style="width:50%; text-align:left">
                    <asp:Label ID="lblSipnosis" runat="server" Text="Sipnosis Libro: "></asp:Label>
                </div>

                <div style="width:30%">
                    <asp:TextBox ID="txtSipnosis" runat="server" Width="300px" CssClass="form-control input-lg"></asp:TextBox>
                </div>
            </div>

            <div style="display:flex; flex-direction:row; gap:10px;">
                <div style="width:50%; text-align:left">
                    <asp:Label ID="lblNPaginas" runat="server" Text="Numero de Paginas: "></asp:Label>
                </div>

                <div style="width:30%">
                    <asp:TextBox ID="txtNPaginas" runat="server" Width="300px" onkeypress="javascript:return solonumeros(event)" CssClass="form-control input-lg"></asp:TextBox>
                </div>
            </div>

            <div style="display:flex; flex-direction:row; gap:10px;">
                <div style="width:50%; text-align:left">
                    <asp:Label ID="lblDDLAutores" runat="server" Text="ID Autores: "></asp:Label>
                </div>

                <div style="width:30%">
                    <asp:DropDownList ID="ddlIdAutores" runat="server" CssClass="form-control" Width="300px" DataSourceID="dsAutores" DataValueField="idAutor" DataTextField="nombre"></asp:DropDownList>
                    <asp:SqlDataSource ID="dsAutores" runat="server" ConnectionString="<%$ ConnectionStrings:libros %>" SelectCommand="ddlIdAutores" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </div> 
           </div>

            <div style="display:flex; flex-direction:row; gap:10px;">
                <div style="width:50%; text-align:left">
                    <asp:Label ID="lblDDLIdEditores" runat="server" Text="ID Editores: "></asp:Label>
                </div>

                <div style="width:30%">
                    <asp:DropDownList ID="ddlIdEditores" runat="server" CssClass="form-control" Width="300px" DataSourceID="dsEditores" DataValueField="idEditor" DataTextField="nombre"></asp:DropDownList>
                    <asp:SqlDataSource ID="dsEditores" runat="server" ConnectionString="<%$ ConnectionStrings:libros %>" SelectCommand="ddlIdEditores" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </div>
            </div>

            <div>
                <asp:Button ID="btnGuardarLibro" runat="server"  CssClass="btn btn-success form-control-ms" Text="Guardar Libro" Visible="true" OnClick="btnGuardarLibro_Click"/>
                <asp:Button ID="btnActualizarLibro" runat="server"  CssClass="btn btn-primary form-control-ms" Text="Actualizar" Visible="false" OnClick="btnActualizarLibro_Click"/>
                <asp:Button ID="btnEliminarLibro" runat="server"  CssClass="btn btn-danger form-control-ms" Text="Eliminar" Visible="false" OnClick="btnEliminarLibro_Click"/>
                <asp:Button ID="btnCancelarLibro" runat="server"  CssClass="btn btn-danger form-control-ms" Text="Cancelar" Visible="true" OnClick="btnCancelarLibro_Click"/>
            </div>

        </div>

        <br />
        
        <div class="container row">
                        <div class="table small" style="margin-left:95px">
                              <asp:GridView ID="gvLibros" runat="server" AllowSorting="True" Width="95%" CssClass="table table-borderless table-hover"
                                     AutoGenerateColumns="False" DataKeyNames="ISBN" DataSourceID="dsLibros" OnRowCommand="gvLibros_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Modificar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgBtnModiLibros" runat="server" CommandArgument='<%# Eval("ISBN") + ";" + Eval("tituloLibro") + ";" + Eval("sipnosis") + ";" + Eval("numeroPaginas") + ";" + Eval("idAutor") + ";" + Eval("idEditor") %>'
                                                    CommandName="modificar" CausesValidation="false" ImageUrl="~/Imagenes/editar.png" Width="26px" CssClass="ms-3"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ISBN" HeaderText="ISBN" InsertVisible="False" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="tituloLibro" HeaderText="Titulo Libro" InsertVisible="False" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="sipnosis" HeaderText="Sipnosis" InsertVisible="False" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="numeroPaginas" HeaderText="Numero Paginas" InsertVisible="False" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="nombreAutor" HeaderText="Nombre Autor" InsertVisible="False" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="apellidoAutor" HeaderText="Apellidos Autor" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="nombreEditor" HeaderText="Nombre Editor" InsertVisible="False" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="sedeEditor" HeaderText="Sede Editor" InsertVisible="False" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="idAutor" HeaderText="ID Autor" InsertVisible="False" ItemStyle-HorizontalAlign="Center" Visible="false"/>
                                        <asp:BoundField DataField="idEditor" HeaderText="ID Editor" InsertVisible="False" ItemStyle-HorizontalAlign="Center" Visible="false"/>
                                    </Columns>
                               </asp:GridView>
                               <asp:SqlDataSource ID="dsLibros" runat="server" ConnectionString="<%$ ConnectionStrings:libros %>" SelectCommand="listaLibrosSelProc" SelectCommandType="StoredProcedure">
                               </asp:SqlDataSource>
                         </div>
                    </div> 
    </form>
    <script>
        function solonumeros(e) {
 
            var key;
 
            if (window.event) // IE
            {
                key = e.keyCode;
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                key = e.which;
            }
 
            if (key < 48 || key > 57) {
                return false;
            }
 
            return true;
        }
 
    </script>
</asp:Content>
