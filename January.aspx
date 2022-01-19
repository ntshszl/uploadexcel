<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="January.aspx.cs" Inherits="GIT_.January" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div id="content-wrapper" class="d-flex flex-column">
            <!-- Main Content -->
            <div id="content" class="mt-5 ml-5 mr-5">
                <h4>
                    <center>
                        January
                    </center>
                </h4>
                <hr />
                <h6>Choose a file with .CSV format</h6>
                <div class="container">
                        <div class="excel-fileupload">
                            <asp:FileUpload class="btn bt-primary" ID="FileUploadExcel" runat="server" />
                            <asp:Button class="btn btn-success" ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload File"/>
                            <asp:Label ID="UploadLabel" runat="server" Text=" "></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
