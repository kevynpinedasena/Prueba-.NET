<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Editores.aspx.cs" Inherits="CrudLibros.Pages.Editores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <%--<div class="mx-auto" style="width:300px">
            <h2>Listado de Editores</h2>
        </div>--%>

        <br />
        
        <div style="display:flex; flex-direction:row; align-items:center; gap:10px; justify-content:center">
            <asp:Button ID="btnVolver" runat="server"  CssClass="btn btn-primary form-control-ms" Text="Volver" OnClick="btnVolver_Click"/>
            <h1>Gestion Editores</h1>
        </div>
        
        <br />

                <div style="display:flex; flex-direction:column; justify-content:center; align-items:center; gap:10px;">

                    <div style="display:flex; flex-direction:row; gap:70px; width:426px;">
                        <asp:Label ID="lblIDEditor" runat="server" Text="ID Editor: " Visible="false" Width="126px"></asp:Label>
                        <asp:TextBox ID="txtIDEditor" runat="server" Visible="false" CssClass="form-control input-lg" Height="40px"></asp:TextBox>
                    </div>

                    <div style="display:flex; flex-direction:row; gap:28px">
                        <asp:Label ID="lbNombreEditor" runat="server" Text="Nombre Editor: " Width="190px"></asp:Label>
                        <asp:TextBox ID="txtNombreEditor" runat="server" CssClass="form-control input-lg" Height="40px"></asp:TextBox>
                    </div>

                    <div style="display:flex; flex-direction:row; gap:110px; width:427px;">
                        <asp:Label ID="lblSede" runat="server" Text="Sede: "></asp:Label>
                        <asp:TextBox ID="txtSede" runat="server" CssClass="form-control input-lg" Height="40px"></asp:TextBox>
                    </div>

                    <div>
                        <asp:Button ID="btnGuardarEditores" runat="server"  CssClass="btn form-control-ms btn-success" Text="Guardar Editor" OnClick="btnGuardarEditores_Click" />
                        <asp:Button ID="btnModificarEditores" runat="server"  CssClass="btn form-control-ms btn-primary" Text="Actualizar" Visible="false" OnClick="btnModificarEditores_Click"/>
                        <asp:Button ID="btnEliminarEditores" runat="server"  CssClass="btn form-control-ms btn-dark" Text="Eliminar" Visible="false" OnClick="btnEliminarEditores_Click"/>
                        <asp:Button ID="btnCancelarGuaEditores" runat="server"  CssClass="btn form-control-ms btn-danger" Text="Cancelar" OnClick="btnCancelarGuaEditores_Click"/>
                    </div>
                </div>
                
                <br />

                <div class="container row">
                    <div class="table small" style="margin-left:95px">
                          <asp:GridView ID="gvEditor" runat="server" AllowSorting="True" OnRowCommand="gvEditores_RowCommand" 
                              Width="95%" CssClass="table table-borderless table-hover" AutoGenerateColumns="False" DataKeyNames="idEditor" DataSourceID="dsEditor" >
                                <Columns>
                                    <asp:TemplateField HeaderText="Modificar" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:ImageButton CommandName="modificar" CommandArgument='<%# Eval("idEditor") + ";" + Eval("nombreEditor") + ";" + Eval("sedeEditor") %>' ID="imgBtnModificarAutor"
                                                CausesValidation="false" runat="server" ImageUrl="~/Imagenes/editar.png" Width="26px" CssClass="ms-3" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="idEditor" HeaderText="Id Editor" InsertVisible="False" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="nombreEditor" HeaderText="Nombre Editor" InsertVisible="False" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="sedeEditor" HeaderText="Sede Editor" ItemStyle-HorizontalAlign="Left" />
                                </Columns>
                           </asp:GridView>
                           <asp:SqlDataSource ID="dsEditor" runat="server" ConnectionString="<%$ ConnectionStrings:libros %>" SelectCommand="listaEditoresSelProc" SelectCommandType="StoredProcedure">
                           </asp:SqlDataSource>
                     </div>
                </div>
    </form>
</asp:Content>
