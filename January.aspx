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
                    <div class="section-title">
                        <h2>Import Excel as New Record</h2>
                        <p>Add new information by uploading file below. The file should follow the instructions below. </p>
                    </div>
                    <div class="card-excelupload">
                        <p>Please drag/upload file here.</p>
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
