﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace OptiSchedule
{
    public partial class newstaffmember : System.Web.UI.Page
    {

        DateTime sunAvlStartTime, sunAvlEndTime, monAvlStartTime, monAvlEndTime, tuesAvlStartTime, tuesAvlEndTime, wedAvlStartTime, wedAvlEndTime,
            thursAvlStartTime, thursAvlEndTime, friAvlStartTime, friAvlEndTime, satAvlStartTime, satAvlEndTime;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Set focus on first textbox
            txtFirstName.Focus();

            //Variable Employee Name and Avl Hours.
            string fstName = txtFirstName.Text;
            string lstName = txtLastName.Text;
            string avlHours = txtHours.Text;

            int posHoursCheck;

            string positionInfo = "SELECT PositionName FROM Positions";
            pullPostion(positionInfo);

            if (Page.IsPostBack)
            {
                setMessageVisibility();

                sunAvlStartTime = convertTo24(ddlSunAvlStartTime, ddlSunStartTimeOfDay);
                sunAvlEndTime = convertTo24(ddlSunAvlEndTime, ddlSunEndTimeOfDay);
                monAvlStartTime = convertTo24(ddlMonAvlStartTime, ddlMonStartTimeOfDay);
                monAvlEndTime = convertTo24(ddlMonAvlEndTime, ddlMonEndTimeOfDay);
                tuesAvlStartTime = convertTo24(ddlTuesAvlStartTime, ddlTuesStartTimeOfDay);
                tuesAvlEndTime = convertTo24(ddlTuesAvlEndTime, ddlTuesEndTimeOfDay);
                wedAvlStartTime = convertTo24(ddlWedAvlStartTime, ddlWedStartTimeOfDay);
                wedAvlEndTime = convertTo24(ddlWedAvlEndTime, ddlWedEndTimeOfDay);
                thursAvlStartTime = convertTo24(ddlThursAvlStartTime, ddlThursStartTimeOfDay);
                thursAvlEndTime = convertTo24(ddlThursAvlEndTime, ddlThursEndTimeOfDay);
                friAvlStartTime = convertTo24(ddlFriAvlStartTime, ddlFriStartTimeOfDay);
                friAvlEndTime = convertTo24(ddlFriAvlEndTime, ddlFriEndTimeOfDay);
                satAvlStartTime = convertTo24(ddlSatAvlStartTime, ddlSatStartTimeOfDay);
                satAvlEndTime = convertTo24(ddlSatAvlEndTime, ddlSatEndTimeOfDay);

                if (fstName == null || fstName == "" ||
                  lstName == null || lstName == "" ||
                  avlHours == null || avlHours == "")
                {
                    newEmpValidation.Text = "<p><strong>***Please enter Employee Name and Avalaible Hours ***</strong></p>";
                    newEmpValidation.Visible = true;
                }
                else if (fstName == null || fstName == "")
                {
                    newEmpValidation.Text = "<p><strong>*** Employee First Name must be 15 characters or fewer.***</strong></p>";
                    newEmpValidation.Visible = true;
                }
                else if (lstName == null || lstName == "")
                {
                    newEmpValidation.Text = "<p><strong>*** Employee Last Name must be 20 characters or fewer.***</strong></p>";
                    newEmpValidation.Visible = true;
                }
                else if (!int.TryParse(avlHours, out posHoursCheck))
                {
                    newEmpValidation.Text = "<p><strong>*** Enter a valid integer value for Hours ***</strong></p>";
                    newEmpValidation.Visible = true;
                }
                else if (!validOneDay())
                {
                    newEmpValidation.Text = "<p><strong>*** Please select at least one day ***</strong></p>";
                    newEmpValidation.Visible = true;
                }

                else if (isEqual(sunAvlStartTime, sunAvlEndTime, chkSunday) || isEqual(monAvlStartTime, monAvlEndTime, chkMonday) ||
                    isEqual(tuesAvlStartTime, tuesAvlEndTime, chkTuesday) || isEqual(wedAvlStartTime, wedAvlEndTime, chkWednesday) ||
                    isEqual(thursAvlStartTime, thursAvlEndTime, chkThursday) || isEqual(friAvlStartTime, friAvlEndTime, chkFriday) ||
                    isEqual(satAvlStartTime, satAvlEndTime, chkSaturday))
                {
                    newEmpValidation.Text = "<p><strong>*** Enter different start and end times. ***</strong><p>";
                    newEmpValidation.Visible = true;
                    isEqualErrorMessage();
                }
                else
                {
                    Response.Write("<p><strong>Your position has been added</strong></p>");
                    nStaffMember.Visible = false;

                    string first_Name = txtFirstName.Text;
                    string last_Name = txtLastName.Text;
                    int available_hours = Convert.ToInt32(txtHours.Text);
                    string job = "(SELECT PositionID FROM Position WHERE positionname = positionid)";

                    string employeeInfo = "INSERT INTO employees VALUES('"
                    + first_Name + "', '"
                    + last_Name + "', '"
                    + available_hours + "', '"
                    + job + "')";

                    addEmployee(employeeInfo);

                    // Sunday info.
                    if (chkSunday.Checked)
                    {
                        DateTime start_time = sunAvlStartTime;
                        DateTime end_time = sunAvlEndTime;

                        string avlInfo = "INSERT INTO EmployeeAvailability VALUES((Select MAX(EmployeeID) from Employees),"
                            + 1 + ", '"
                            + start_time + "', '"
                            + end_time + "')";
                        addEmployee(avlInfo);
                    }

                    // Monday info.
                    if (chkMonday.Checked)
                    {
                        DateTime start_time = monAvlStartTime;
                        DateTime end_time = monAvlEndTime;

                        string avlInfo = "INSERT INTO EmployeeAvailability VALUES((Select MAX(EmployeeID) from Employees),"
                            + 2 + ", '"
                            + start_time + "', '"
                            + end_time + "')";
                        addEmployee(avlInfo);
                    }

                    if (chkTuesday.Checked)
                    {
                        DateTime start_time = tuesAvlStartTime;
                        DateTime end_time = tuesAvlEndTime;

                        string avlInfo = "INSERT INTO EmployeeAvailability VALUES((Select MAX(EmployeeID) from Employees),"
                            + 3 + ", '"
                            + start_time + "', '"
                            + end_time + "')";
                        addEmployee(avlInfo);
                    }

                    if (chkWednesday.Checked)
                    {
                        DateTime start_time = wedAvlStartTime;
                        DateTime end_time = wedAvlEndTime;

                        string avlInfo = "INSERT INTO EmployeeAvailability VALUES((Select MAX(EmployeeID) from Employees),"
                            + 4 + ", '"
                            + start_time + "', '"
                            + end_time + "')";
                        addEmployee(avlInfo);
                    }

                    if (chkThursday.Checked)
                    {
                        DateTime start_time = thursAvlStartTime;
                        DateTime end_time = thursAvlEndTime;

                        string avlInfo = "INSERT INTO EmployeeAvailability VALUES((Select MAX(EmployeeID) from Employees),"
                            + 5 + ", '"
                            + start_time + "', '"
                            + end_time + "')";
                        addEmployee(avlInfo);
                    }

                    if (chkFriday.Checked)
                    {
                        DateTime start_time = friAvlStartTime;
                        DateTime end_time = friAvlEndTime;

                        string avlInfo = "INSERT INTO EmployeeAvailability VALUES((Select MAX(EmployeeID) from Employees),"
                            + 6 + ", '"
                            + start_time + "', '"
                            + end_time + "')";
                        addEmployee(avlInfo);
                    }

                    if (chkSaturday.Checked)
                    {
                        DateTime start_time = satAvlStartTime;
                        DateTime end_time = satAvlEndTime;

                        string avlInfo = "INSERT INTO EmployeeAvailability VALUES((Select MAX(EmployeeID) from Employees),"
                            + 7 + ", '"
                            + start_time + "', '"
                            + end_time + "')";
                        addEmployee(avlInfo);
                    }

                    newEmpValidation.Text = "<p><strong>Employee " + last_Name + ", " + first_Name + " has been added and is avalaible to work " + available_hours + " hours.</strong></p>";
                    newEmpValidation.Visible = true;
                }

            }
        }

        protected void addEmployee(string newRecord)
        {
            // Create a database connection.
            SqlConnection dbConnection = new SqlConnection("Data Source=ghrtjql79x.database.windows.net;Database=optiScheduleDB;User ID=scheduleAdmin@ghrtjql79x; Password=GetItDone_16; Trusted_Connection=False;Encrypt=True;Connection Timeout=30");

            try
            {
                dbConnection.Open();
                dbConnection.ChangeDatabase("optiScheduleDB");
                SqlCommand outlookCommand = new SqlCommand(newRecord, dbConnection);
                Response.Write("<p>Successfully added employee record.</p>");
                outlookCommand.ExecuteNonQuery();

            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
            }

            dbConnection.Close();
        }

        // Function to pull Positions
        public void pullPostion(string positionList)
        {
            SqlConnection dbConnection = new SqlConnection("Data Source=ghrtjql79x.database.windows.net;Database=optiScheduleDB;User ID=scheduleAdmin@ghrtjql79x; Password=GetItDone_16; Trusted_Connection=False;Encrypt=True;Connection Timeout=30");
            dbConnection.Open();
            dbConnection.ChangeDatabase("optiScheduleDB");
            SqlCommand cmd = new SqlCommand(positionList, dbConnection);


            SqlDataReader ddlValues;
            ddlValues = cmd.ExecuteReader();

            ddlPosition.DataSource = ddlValues;
            ddlPosition.DataValueField = "PositionName";
            ddlPosition.DataTextField = "PositionName";
            ddlPosition.DataBind();

            cmd.Connection.Close();
            cmd.Connection.Dispose();
        } 

        // Function to make sure at least one day is checked.
        protected bool validOneDay()
        {
            return chkSunday.Checked || chkMonday.Checked || chkTuesday.Checked || chkWednesday.Checked ||
                chkThursday.Checked || chkFriday.Checked || chkSaturday.Checked;
        }

        // Function to check if values have been entered
        protected bool dataEntered(CheckBox dayChecked, TextBox numPos)
        {
            // Convert to usable data.
            bool isChecked = dayChecked.Checked;
            string fstName = txtFirstName.Text;
            string lstName = txtLastName.Text;
            string avlHours = txtHours.Text;

            if (isChecked)
            {
                if (fstName == null || fstName == "" ||
                 lstName == null || lstName == "" ||
                 avlHours == null || avlHours == "")
                {
                    return false;
                }
            }

            return true;
        }

        // Test to make sure the value is an integer.
        protected bool isInteger(TextBox textBox, CheckBox check)
        {
            int number = 0;
            if (check.Checked)
            {
                if (int.TryParse(textBox.Text, out number))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        // Individualized error messages for days where end times are equal.
        protected void isEqualErrorMessage()
        {
            if (isEqual(sunAvlStartTime, sunAvlEndTime, chkSunday))
            {
                lblSunPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblSunPosValid.Visible = true;
            }
            if (isEqual(monAvlStartTime, monAvlEndTime, chkMonday))
            {
                lblMonPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblMonPosValid.Visible = true;
            }
            if (isEqual(tuesAvlStartTime, tuesAvlEndTime, chkTuesday))
            {
                lblTuesPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblTuesPosValid.Visible = true;
            }
            if (isEqual(wedAvlStartTime, wedAvlEndTime, chkWednesday))
            {
                lblWedPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblWedPosValid.Visible = true;
            }
            if (isEqual(thursAvlStartTime, thursAvlEndTime, chkThursday))
            {
                lblThursPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblThursPosValid.Visible = true;
            }
            if (isEqual(friAvlStartTime, friAvlEndTime, chkFriday))
            {
                lblFriPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblFriPosValid.Visible = true;
            }
            if (isEqual(satAvlStartTime, satAvlEndTime, chkSaturday))
            {
                lblSatPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblSatPosValid.Visible = true;
            }
        }

        // Test to make sure that the start time and end times are different.
        protected bool isEqual(DateTime start, DateTime end, CheckBox dayChecked)
        {
            bool isChecked = dayChecked.Checked;
            int startHours = start.Hour;
            int startMinutes = start.Minute;
            int endHours = end.Hour;
            int endMinutes = end.Minute;

            if (isChecked)
            {
                if (startHours == endHours && startMinutes == endMinutes)
                    return true;
                return false;
            }
            return false;
        }

        // Function that sets all visible statuses to false for post-back purposes (refresh).
        protected void setMessageVisibility()
        {

            lblSunPosValid.Visible = false;
            lblMonPosValid.Visible = false;
            lblTuesPosValid.Visible = false;
            lblWedPosValid.Visible = false;
            lblThursPosValid.Visible = false;
            lblFriPosValid.Visible = false;
            lblSatPosValid.Visible = false;
            newEmpValidation.Visible = false;
        }

        protected void resetForm()
        {
            // Clear all checkboxes.
            chkSunday.Checked = false;
            chkMonday.Checked = false;
            chkTuesday.Checked = false;
            chkWednesday.Checked = false;
            chkThursday.Checked = false;
            chkFriday.Checked = false;
            chkSaturday.Checked = false;

            // Clear all textboxes.

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtHours.Text = "";

            // Reset dropdown boxes.
            ddlSunAvlStartTime.SelectedIndex = 0;
            ddlSunStartTimeOfDay.SelectedIndex = 0;
            ddlSunAvlEndTime.SelectedIndex = 0;
            ddlSunEndTimeOfDay.SelectedIndex = 0;
            ddlMonAvlStartTime.SelectedIndex = 0;
            ddlMonStartTimeOfDay.SelectedIndex = 0;
            ddlMonAvlEndTime.SelectedIndex = 0;
            ddlMonEndTimeOfDay.SelectedIndex = 0;
            ddlTuesAvlStartTime.SelectedIndex = 0;
            ddlTuesStartTimeOfDay.SelectedIndex = 0;
            ddlTuesAvlEndTime.SelectedIndex = 0;
            ddlTuesEndTimeOfDay.SelectedIndex = 0;
            ddlWedAvlStartTime.SelectedIndex = 0;
            ddlWedStartTimeOfDay.SelectedIndex = 0;
            ddlWedAvlEndTime.SelectedIndex = 0;
            ddlWedEndTimeOfDay.SelectedIndex = 0;
            ddlThursAvlStartTime.SelectedIndex = 0;
            ddlThursStartTimeOfDay.SelectedIndex = 0;
            ddlThursAvlEndTime.SelectedIndex = 0;
            ddlThursEndTimeOfDay.SelectedIndex = 0;
            ddlFriAvlStartTime.SelectedIndex = 0;
            ddlFriStartTimeOfDay.SelectedIndex = 0;
            ddlFriAvlEndTime.SelectedIndex = 0;
            ddlFriEndTimeOfDay.SelectedIndex = 0;
            ddlSatAvlStartTime.SelectedIndex = 0;
            ddlSatStartTimeOfDay.SelectedIndex = 0;
            ddlSatAvlEndTime.SelectedIndex = 0;
            ddlSatEndTimeOfDay.SelectedIndex = 0;
        }

        // Convert any PM time to 24 hour clock for calculations.
        protected DateTime convertTo24(DropDownList t, DropDownList ddl)
        {

            DateTime time = DateTime.Parse("" + t.Text + " " + ddl.Text + "");
            return time;

        }

        // Finds the difference in hours.
        protected double findHours(DateTime start, DateTime end)
        {
            TimeSpan difference;

            if (start > end)
            {
                end = end.AddHours(24);
                difference = end.Subtract(start);
                return difference.TotalHours;
            }

            difference = end.Subtract(start);
            return difference.TotalHours;
        }

        // Find total hours per day.
        protected double totalHoursPerDay(TextBox txtBox, double hours)
        {
            int numPos = Convert.ToInt32(txtBox.Text);
            double dailyHours = numPos * hours;
            return dailyHours;
        }

        // Clear button functionality
        protected void clear_Click(object Source, EventArgs E)
        {
            resetForm();
            setMessageVisibility();
        }

    }
}
