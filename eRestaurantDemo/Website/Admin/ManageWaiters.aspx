<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageWaiters.aspx.cs" Inherits="Admin_ManageWaiters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row col-md-12">
        <h1>Manage Waiters
            <span class="glyphicon glyphicon-glass"></span>
        </h1>
    </div>

     <asp:ObjectDataSource 
        ID="WaitersDataSource" 
        runat="server"
        TypeName="eRestaurant.Framework.BLL.RestaurantAdminController" 
        SelectMethod="ListAllWaiters"
        DataObjectTypeName="eRestaurant.Framework.Entities.Waiter" 
        OldValuesParameterFormatString="original_{0}" 
        UpdateMethod="UpdateWaiter"
        DeleteMethod="DeleteWaiter"
        InsertMethod="AddWaiter" 
        OnDeleted="ProcessExceptions" 
        OnInserted="ProcessExceptions" 
        OnUpdated="ProcessExceptions">
    </asp:ObjectDataSource>

     <asp:Label 
        ID="MessageLabel" 
        runat="server">
    </asp:Label>

</asp:Content>

