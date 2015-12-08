<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newstaffmember.aspx.cs" Inherits="OptiSchedule.newstaffmember" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Staff Member</title>
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
            <li><a runat="server" href="~/NewPosition.aspx">Add Position</a></li>
            <li><a runat="server" href="~/">Add Employee</a></li>
            <li><a runat="server" href="~/">Reports</a></li>
            <li><a runat="server" href="~/">Calendar</a></li>
        </ul>
        &nbsp;
    </div>

    <div class="main">
    <asp:ObjectDataSource ID="am_pm" runat="server" TypeName="OptiSchedule.Models.ddlTimeOfDay" SelectMethod ="GetAll" />
    <asp:ObjectDataSource ID="times" runat="server" TypeName="OptiSchedule.Models.ddlTimes" SelectMethod ="GetAll" />
    <h2>Add New Staff Member</h2>

    <p><asp:Label ID="newEmpValidation" runat="server" Visible="False"></asp:Label></p>

    <form ID="nStaffMember" runat="server">

    <p>Employee First Name: <br />
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>

    </p>
    <p>Employee Last Name: <br />
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>

    </p>
    <p>Position: <br />
        <asp:DropDownList ID="ddlPosition" runat="server" /> &nbsp;&nbsp;&nbsp; 
        
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/newposition.aspx"> Add Position Here </asp:HyperLink>


    </p>
    <p>Available Hours Per Week: <br />
        <asp:TextBox ID="txtHours" runat="server"></asp:TextBox>

    </p>
    
    <table style="max-width:100%">

      <tr align="center" >
        <td><asp:Label ID="Label1"  Text="Days Available:" runat="server"></asp:Label></td>
        <td><asp:Label ID="lblFrom"  Text="From" runat="server"></asp:Label></td> 
        <td><asp:Label ID="lblTo"  Text="To" runat="server"></asp:Label></td>
      </tr>

      <tr >
        <td><asp:CheckBox ID="chkSunday" Text="Sunday" runat="server"></asp:CheckBox></td>
        <td>
            <asp:DropDownList ID="ddlSunAvlStartTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlSunStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td> 
        <td>
            <asp:DropDownList ID="ddlSunAvlEndTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlSunEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td>
        <td align="left"><asp:Label ID="lblSunPosValid" runat="server" Visible="false" /></td>
      </tr>
        
      <tr>
        <td><asp:CheckBox ID="chkMonday"  Text="Monday" runat="server"></asp:CheckBox></td>
        <td>
            <asp:DropDownList ID="ddlMonAvlStartTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlMonStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td> 
        <td>
            <asp:DropDownList ID="ddlMonAvlEndTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlMonEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td>
        <td align="left"><asp:Label ID="lblMonPosValid" runat="server" Visible="false" /></td> 
      </tr>

      <tr>
        <td><asp:CheckBox ID="chkTuesday" Text="Tuesday" runat="server"></asp:CheckBox></td>
        <td>
            <asp:DropDownList ID="ddlTuesAvlStartTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlTuesStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td> 
        <td>
            <asp:DropDownList ID="ddlTuesAvlEndTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlTuesEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td>
         <td align="left"><asp:Label ID="lblTuesPosValid" runat="server" Visible="false" /></td> 
      </tr>

      <tr>
        <td><asp:CheckBox ID="chkWednesday" Text="Wednesday" runat="server"></asp:CheckBox></td>
        <td>
            <asp:DropDownList ID="ddlWedAvlStartTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlWedStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td> 
        <td>
            <asp:DropDownList ID="ddlWedAvlEndTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlWedEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td>
        <td align="left"><asp:Label ID="lblWedPosValid" runat="server" Visible="false" /></td>   
      </tr>

      <tr>
        <td><asp:CheckBox ID="chkThursday" Text="Thursday" runat="server"></asp:CheckBox></td>
        <td>
            <asp:DropDownList ID="ddlThursAvlStartTime"  DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlThursStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td> 
        <td>
            <asp:DropDownList ID="ddlThursAvlEndTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlThursEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td>
        <td align="left"><asp:Label ID="lblThursPosValid" runat="server" Visible="false" /></td>
      </tr>

      <tr>
        <td><asp:CheckBox ID="chkFriday" Text="Friday" runat="server"></asp:CheckBox></td>
        <td>
            <asp:DropDownList ID="ddlFriAvlStartTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlFriStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td> 
        <td>
            <asp:DropDownList ID="ddlFriAvlEndTime"  DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlFriEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td>
        <td align="left"><asp:Label ID="lblFriPosValid" runat="server" Visible="false" /></td>
      </tr>

      <tr>
        <td><asp:CheckBox ID="chkSaturday" Text="Saturday" runat="server"></asp:CheckBox></td>
        <td>
            <asp:DropDownList ID="ddlSatAvlStartTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlSatStartTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td> 
        <td>
            <asp:DropDownList ID="ddlSatAvlEndTime" DataSourceID ="times" runat="server" DataTextField="Name" DataValueField="Id" />
            <asp:DropDownList ID="ddlSatEndTimeOfDay" DataSourceID ="am_pm" runat="server" DataTextField="Name" DataValueField ="Id" />
        </td>
        <td align="left"><asp:Label ID="lblSatPosValid" runat="server" Visible="false" /></td>  
      </tr>

    </table>     
          
    <p>
        <asp:Button ID="AddStaffMemberButton" runat="server" Text="Add Staff Member" 
            Width="160px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="CancelButton" runat="server" Text="Cancel" 
            UseSubmitBehavior="False" />
    </p>
    </form>
    </div>
</body>
</html>