<%@ Page Title="Add/Update Position" Language="C#" AutoEventWireup="true" CodeBehind="NewPosition.aspx.cs" Inherits="OptiSchedule.NewPosition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Position</title>
    <link href="Content/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <div class="header">
        <h1>OptiSchedule</h1>
    </div>
    <div class="navbar">
        <ul class="nav-links">
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/">Update Schedule</a></li>
            <li><a runat="server" href="~/">Add Position</a></li>
            <li><a runat="server" href="~/NewStaffMember.aspx">Add Employee</a></li>
            <li><a runat="server" href="~/">Reports</a></li>
            <li><a runat="server" href="~/">Calendar</a></li>
        </ul>
        &nbsp;
    </div>
    
    <div class="main">
    <asp:ObjectDataSource ID="am_pm" runat="server" TypeName="OptiSchedule.Models.ddlTimeOfDay" SelectMethod ="GetAll" />
    <asp:ObjectDataSource ID="times" runat="server" TypeName="OptiSchedule.Models.ddlTimes" SelectMethod ="GetAll" />

    <h2>Add New Position</h2>
    <p><asp:Label ID="newPosValidation" runat="server" Visible="false"></asp:Label></p>
    <form ID="newPosition" runat="server">
        
        <p>Position Name<br />
        <asp:TextBox ID="txtPosType" runat="server"></asp:TextBox>
        </p>
        <p>Please enter all time values in 15 minute increments.</p>
        
        <table runat="server">
            <tr align="center">
                <th>Day</th><th>Start Time</th><th>End Time</th>
            </tr>
            <tr align="center">
                <td align="left"><asp:CheckBox ID="chkSunPos" Text="Sunday" runat="server"></asp:CheckBox></td>                
                <td>
                    <asp:DropDownList ID="ddlSunPosStartTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlSunStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td> 
                <td>
                    <asp:DropDownList ID="ddlSunPosEndTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlSunEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td>
                <td align="left"><asp:Label ID="lblSunPosValid" runat="server" Visible="false" /></td>
            </tr>
            <tr align="center">
                <td align="left"><asp:CheckBox ID="chkMonPos" Text="Monday" runat="server"></asp:CheckBox></td>
                <td>
                    <asp:DropDownList ID="ddlMonPosStartTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlMonStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td> 
                <td>
                    <asp:DropDownList ID="ddlMonPosEndTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlMonEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td> 
                <td align="left"><asp:Label ID="lblMonPosValid" runat="server" Visible="false" /></td>            
            </tr>
            <tr align="center">
                <td align="left"><asp:CheckBox ID="chkTuesPos" Text="Tuesday" runat="server"></asp:CheckBox></td>
                <td>
                    <asp:DropDownList ID="ddlTuesPosStartTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlTuesStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td> 
                <td>
                    <asp:DropDownList ID="ddlTuesPosEndTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlTuesEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td>
                <td align="left"><asp:Label ID="lblTuesPosValid" runat="server" Visible="false" /></td>             
            </tr>
            <tr align="center">
                <td align="left"><asp:CheckBox ID="chkWedPos" Text="Wednesday" runat="server"></asp:CheckBox></td>
                <td>
                    <asp:DropDownList ID="ddlWedPosStartTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlWedStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td> 
                <td>
                    <asp:DropDownList ID="ddlWedPosEndTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlWedEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td> 
                <td align="left"><asp:Label ID="lblWedPosValid" runat="server" Visible="false" /></td>            
            </tr>
            <tr align="center">
                <td align="left"><asp:CheckBox ID="chkThursPos" Text="Thursday" runat="server"></asp:CheckBox></td>
                <td>
                    <asp:DropDownList ID="ddlThursPosStartTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlThursStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td> 
                <td>
                    <asp:DropDownList ID="ddlThursPosEndTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlThursEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td>
                <td align="left"><asp:Label ID="lblThursPosValid" runat="server" Visible="false" /></td>             
            </tr>
            <tr align="center">
                <td align="left"><asp:CheckBox ID="chkFriPos" Text="Friday" runat="server"></asp:CheckBox></td>
                <td>
                    <asp:DropDownList ID="ddlFriPosStartTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlFriStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td> 
                <td>
                    <asp:DropDownList ID="ddlFriPosEndTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlFriEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td> 
                <td align="left"><asp:Label ID="lblFriPosValid" runat="server" Visible="false" /></td>            
            </tr>
            <tr align="center">
                <td align="left"><asp:CheckBox ID="chkSatPos" Text="Saturday" runat="server"></asp:CheckBox></td>
                <td>
                    <asp:DropDownList ID="ddlSatPosStartTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlSatStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td> 
                <td>
                    <asp:DropDownList ID="ddlSatPosEndTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
                    <asp:DropDownList ID="ddlSatEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
                </td>  
                <td align="left"><asp:Label ID="lblSatPosValid" runat="server" Visible="false" /></td>           
            </tr>
        </table> 
        <asp:Label ID="testLabel" runat="server" Visible="false" />   
    <p>
        <asp:Button ID="btnAddPosition" runat="server" Text="Add Position" Width="160px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="btnAddPosCancel" runat="server" Text="Clear" OnClick="clear_Click" />
    </p>

    </form>
    </div>
</body>
</html>
