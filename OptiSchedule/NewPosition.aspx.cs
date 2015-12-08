using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace OptiSchedule
{
    public partial class NewPosition : System.Web.UI.Page
    {
        DateTime sunStartTime, sunEndTime, monStartTime, monEndTime, tuesStartTime, tuesEndTime, wedStartTime, wedEndTime,
                thursStartTime, thursEndTime, friStartTime, friEndTime, satStartTime, satEndTime;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Variables for use to enter input to database.
            string positionName = txtPosType.Text;
            
            double sunTotalHours, monTotalHours, tuesTotalHours, wedTotalHours, thursTotalHours, friTotalHours, satTotalHours;
            

            if (Page.IsPostBack)
            {
                setMessageVisibility();

                // Since user has limited control over values selected, no real validation needed.
                sunStartTime =  convertTo24(ddlSunPosStartTime, ddlSunStartTimeOfDay);
                sunEndTime = convertTo24(ddlSunPosEndTime, ddlSunEndTimeOfDay);
                monStartTime = convertTo24(ddlMonPosStartTime, ddlMonStartTimeOfDay);
                monEndTime = convertTo24(ddlMonPosEndTime, ddlMonEndTimeOfDay);
                tuesStartTime = convertTo24(ddlTuesPosStartTime, ddlTuesStartTimeOfDay);
                tuesEndTime = convertTo24(ddlTuesPosEndTime, ddlTuesEndTimeOfDay);
                wedStartTime = convertTo24(ddlWedPosStartTime, ddlWedStartTimeOfDay);
                wedEndTime = convertTo24(ddlWedPosEndTime, ddlWedEndTimeOfDay);
                thursStartTime = convertTo24(ddlThursPosStartTime, ddlThursStartTimeOfDay);
                thursEndTime = convertTo24(ddlThursPosEndTime, ddlThursEndTimeOfDay);
                friStartTime = convertTo24(ddlFriPosStartTime, ddlFriStartTimeOfDay);
                friEndTime = convertTo24(ddlFriPosEndTime, ddlFriEndTimeOfDay);
                satStartTime = convertTo24(ddlSatPosStartTime, ddlSatStartTimeOfDay);
                satEndTime = convertTo24(ddlSatPosEndTime, ddlSatEndTimeOfDay);


                if (txtPosType.Text == null || txtPosType.Text == "")
                {
                    newPosValidation.Text = "<p><strong>*** Please enter a position name ***</strong></p>";
                    newPosValidation.Visible = true;
                }
                else if(txtPosType.Text.Length > 40)
                {
                    newPosValidation.Text = "<p><strong>*** Position Name must be 40 characters or fewer.***</strong></p>";
                    newPosValidation.Visible = true;
                }
                else if(!validOneDay())
                {
                    newPosValidation.Text = "<p><strong>*** Please select at least one day ***</strong></p>";
                    newPosValidation.Visible = true;
                }
                else if(isEqual(sunStartTime, sunEndTime, chkSunPos) || isEqual(monStartTime, monEndTime, chkMonPos) ||
                        isEqual(tuesStartTime, tuesEndTime, chkTuesPos) || isEqual(wedStartTime, wedEndTime, chkWedPos) ||
                        isEqual(thursStartTime, thursEndTime, chkThursPos) || isEqual(friStartTime, friEndTime, chkFriPos) ||
                        isEqual(satStartTime, satEndTime, chkSatPos))
                {
                    newPosValidation.Text = "<p><strong>*** Enter different start and end times. ***</strong><p>";
                    newPosValidation.Visible = true;
                    isEqualErrorMessage();
                }
                else
                {
                    decimal totalHours = 0m;
                    string dbEntry = "INSERT INTO Positions VALUES('" + positionName + "', ";

                    // Sunday info.
                    if (chkSunPos.Checked)
                    {
                        sunTotalHours = findHours(sunStartTime, sunEndTime);
                        printDailyAdded(lblSunPosValid, sunTotalHours);
                        totalHours += (decimal)sunTotalHours;
                        dbEntry = dbEntry + "'" + sunStartTime.ToString("HH:mm") + "', " + "'" + sunEndTime.ToString("HH:mm") + "', ";
                    }
                    else
                    {
                        dbEntry = dbEntry + "null, null, ";
                    }
                    // Monday info.
                    if(chkMonPos.Checked)
                    {
                        monTotalHours = findHours(monStartTime, monEndTime);
                        printDailyAdded(lblMonPosValid, monTotalHours);
                        totalHours += (decimal)monTotalHours;
                        dbEntry = dbEntry + "'" + sunStartTime.ToString("HH:mm") + "', " + "'" + sunEndTime.ToString("HH:mm") + "', ";
                    }
                    else
                    {
                        dbEntry = dbEntry + "null, null, ";
                    }
                    // Tuesday info.
                    if(chkTuesPos.Checked)
                    {
                        tuesTotalHours = findHours(tuesStartTime, tuesEndTime);
                        printDailyAdded(lblTuesPosValid, tuesTotalHours);
                        totalHours += (decimal)tuesTotalHours;
                        dbEntry = dbEntry + "'" + sunStartTime.ToString("HH:mm") + "', " + "'" + sunEndTime.ToString("HH:mm") + "', ";
                    }
                    else
                    {
                        dbEntry = dbEntry + "null, null, ";
                    }
                    // Wednesday info.
                    if(chkWedPos.Checked)
                    {
                        wedTotalHours = findHours(wedStartTime, wedEndTime);
                        printDailyAdded(lblWedPosValid, wedTotalHours);
                        totalHours += (decimal)wedTotalHours;
                        dbEntry = dbEntry + "'" + sunStartTime.ToString("HH:mm") + "', " + "'" + sunEndTime.ToString("HH:mm") + "', ";
                    }
                    else
                    {
                        dbEntry = dbEntry + "null, null, ";
                    }
                    // Thursday info.
                    if(chkThursPos.Checked)
                    {
                        thursTotalHours = findHours(thursStartTime, thursEndTime);
                        printDailyAdded(lblThursPosValid, thursTotalHours);
                        totalHours += (decimal)thursTotalHours;
                        dbEntry = dbEntry + "'" + sunStartTime.ToString("HH:mm") + "', " + "'" + sunEndTime.ToString("HH:mm") + "', ";
                    }
                    else
                    {
                        dbEntry = dbEntry + "null, null, ";
                    }
                    // Friday info.
                    if(chkFriPos.Checked)
                    {
                        friTotalHours = findHours(friStartTime, friEndTime);
                        printDailyAdded(lblFriPosValid, friTotalHours);
                        totalHours += (decimal)friTotalHours;
                        dbEntry = dbEntry + "'" + sunStartTime.ToString("HH:mm") + "', " + "'" + sunEndTime.ToString("HH:mm") + "', ";
                    }
                    else
                    {
                        dbEntry = dbEntry + "null, null, ";
                    }
                    // Saturday info.
                    if(chkSatPos.Checked)
                    {
                        satTotalHours = findHours(satStartTime, satEndTime);
                        printDailyAdded(lblSatPosValid, satTotalHours);
                        totalHours += (decimal)satTotalHours;
                        dbEntry = dbEntry + "'" + sunStartTime.ToString("HH:mm") + "', " + "'" + sunEndTime.ToString("HH:mm") + "', ";
                    }
                    else
                    {
                        dbEntry = dbEntry + "null, null, ";
                    }

                    // Complete the database entry string.
                    dbEntry = dbEntry + totalHours + ")";

                    // Add the entered data to the database.
                    addPosition(dbEntry);
                    
                    newPosValidation.Text = "<p><strong>You have added the position of " + txtPosType.Text + " with " + totalHours + " total hours weekly.</strong></p>";
                    newPosValidation.Visible = true;

                }
            }
        }

        // Function to commit changes to database.
        protected void addPosition(string newRecord)
        {
            // Create a database connection.
            SqlConnection dbConnection = new SqlConnection("Data Source=ghrtjql79x.database.windows.net;Database=optiScheduleDB;User ID=scheduleAdmin@ghrtjql79x; Password=GetItDone_16; Trusted_Connection=False;Encrypt=True;Connection Timeout=30");

            try
            {
                dbConnection.Open();
                dbConnection.ChangeDatabase("optiScheduleDB");
                SqlCommand outlookCommand = new SqlCommand(newRecord, dbConnection);
                outlookCommand.ExecuteNonQuery();
                Response.Write("<p>Successfully added record.</p>");
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number + ": " + exception.Message + "</p>");
            }

            dbConnection.Close();
        }

        // Function to make sure at least one day is checked.
        protected bool validOneDay()
        {
            return chkSunPos.Checked || chkMonPos.Checked || chkTuesPos.Checked || chkWedPos.Checked ||
                chkThursPos.Checked || chkFriPos.Checked || chkSatPos.Checked;
        }

        // Function to check if values have been entered
        /*protected bool dataEntered(CheckBox dayChecked, TextBox numPos)
        {
            // Convert to usable data.
            bool isChecked = dayChecked.Checked;
            string positions = numPos.Text;            

            if(isChecked)
            {
                if(positions == "" || positions == null)
                {
                    return false;
                }
            }            

            return true;
        }*/

        // Test to see if data is valid prior to testing if they're equal.
        /*protected bool isValid()
        {

            return dataEntered(chkSunPos, txtSunPosNumOpen) && 
                dataEntered(chkMonPos, txtMonPosNumOpen) && 
                dataEntered(chkTuesPos, txtTuesPosNumOpen) &&  
                dataEntered(chkWedPos, txtWedPosNumOpen) &&  
                dataEntered(chkThursPos, txtThursPosNumOpen) && 
                dataEntered(chkFriPos, txtFriPosNumOpen) && 
                dataEntered(chkSatPos, txtSatPosNumOpen);
           
        }*/

        // Test to make sure the value is an integer.
       /* protected bool isInteger(TextBox textBox, CheckBox check)
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
        }*/

        // Print messages for invalid position entry.
        /*protected void invalidPosErrorMessage()
        {

            if (chkSunPos.Checked && !isInteger(txtSunPosNumOpen, chkSunPos))
            {
                lblSunPosValid.Text = "<strong>*Enter a valid Integer for positions</strong>";
                lblSunPosValid.Visible = true;
            }
            if (chkMonPos.Checked && !isInteger(txtMonPosNumOpen, chkMonPos))
            {
                lblMonPosValid.Text = "<strong>*Enter a valid Integer for positions</strong>";
                lblMonPosValid.Visible = true;
            }
            if (chkTuesPos.Checked && !isInteger(txtTuesPosNumOpen, chkTuesPos))
            {
                lblTuesPosValid.Text = "<strong>*Enter a valid Integer for positions</strong>";
                lblTuesPosValid.Visible = true;
            }
            if (chkWedPos.Checked && !isInteger(txtWedPosNumOpen, chkWedPos))
            {
                lblWedPosValid.Text = "<strong>*Enter a valid Integer for positions</strong>";
                lblWedPosValid.Visible = true;
            }
            if (chkThursPos.Checked && !isInteger(txtThursPosNumOpen, chkThursPos))
            {
                lblThursPosValid.Text = "<strong>*Enter a valid Integer for positions</strong>";
                lblThursPosValid.Visible = true;
            }
            if (chkFriPos.Checked && !isInteger(txtFriPosNumOpen, chkFriPos))
            {
                lblFriPosValid.Text = "<strong>*Enter a valid Integer for positions</strong>";
                lblFriPosValid.Visible = true;
            }
            if (chkSatPos.Checked && !isInteger(txtSatPosNumOpen, chkSatPos))
            {
                lblSatPosValid.Text = "<strong>*Enter a valid Integer for positions</strong>";
                lblSatPosValid.Visible = true;
            }
        }*/

        // Individualized error messages for days where end times are equal.
        protected void isEqualErrorMessage()
        {
            if (isEqual(sunStartTime, sunEndTime, chkSunPos))
            {
                lblSunPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblSunPosValid.Visible = true;
            }
            if (isEqual(monStartTime, monEndTime, chkMonPos))
            {
                lblMonPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblMonPosValid.Visible = true;
            }
            if (isEqual(tuesStartTime, tuesEndTime, chkTuesPos))
            {
                lblTuesPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblTuesPosValid.Visible = true;
            }
            if (isEqual(wedStartTime, wedEndTime, chkWedPos))
            {
                lblWedPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblWedPosValid.Visible = true;
            }
            if (isEqual(thursStartTime, thursEndTime, chkThursPos))
            {
                lblThursPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblThursPosValid.Visible = true;
            }
            if (isEqual(friStartTime, friEndTime, chkFriPos))
            {
                lblFriPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblFriPosValid.Visible = true;
            }
            if (isEqual(satStartTime, satEndTime, chkSatPos))
            {
                lblSatPosValid.Text = "<strong>* Start and end times must be different.</strong>";
                lblSatPosValid.Visible = true;
            }
        }

        // Daily message for positions added and total hours.
        protected void printDailyAdded(Label dailyLabel, double dailyHours)
        {
            dailyLabel.Text = "Total Hours: " + dailyHours + "";
            dailyLabel.Visible = true;
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
            newPosValidation.Visible = false;
        }

        protected void resetForm()
        {
            // Clear all checkboxes.
            chkSunPos.Checked = false;
            chkMonPos.Checked = false;
            chkTuesPos.Checked = false;
            chkWedPos.Checked = false;
            chkThursPos.Checked = false;
            chkFriPos.Checked = false;
            chkSatPos.Checked = false;

            // Clear all textboxes.
            txtPosType.Text = "";

            // Reset dropdown boxes.
            ddlSunPosStartTime.SelectedIndex = 0;
            ddlSunStartTimeOfDay.SelectedIndex = 0;
            ddlSunPosEndTime.SelectedIndex = 0;
            ddlSunEndTimeOfDay.SelectedIndex = 0;
            ddlMonPosStartTime.SelectedIndex = 0;
            ddlMonStartTimeOfDay.SelectedIndex = 0;
            ddlMonPosEndTime.SelectedIndex = 0;
            ddlMonEndTimeOfDay.SelectedIndex = 0;
            ddlTuesPosStartTime.SelectedIndex = 0;
            ddlTuesStartTimeOfDay.SelectedIndex = 0;
            ddlTuesPosEndTime.SelectedIndex = 0;
            ddlTuesEndTimeOfDay.SelectedIndex = 0;
            ddlWedPosStartTime.SelectedIndex = 0;
            ddlWedStartTimeOfDay.SelectedIndex = 0;
            ddlWedPosEndTime.SelectedIndex = 0;
            ddlWedEndTimeOfDay.SelectedIndex = 0;
            ddlThursPosStartTime.SelectedIndex = 0;
            ddlThursStartTimeOfDay.SelectedIndex = 0;
            ddlThursPosEndTime.SelectedIndex = 0;
            ddlThursEndTimeOfDay.SelectedIndex = 0;
            ddlFriPosStartTime.SelectedIndex = 0;
            ddlFriStartTimeOfDay.SelectedIndex = 0;
            ddlFriPosEndTime.SelectedIndex = 0;
            ddlFriEndTimeOfDay.SelectedIndex = 0;
            ddlSatPosStartTime.SelectedIndex = 0;
            ddlSatStartTimeOfDay.SelectedIndex = 0;
            ddlSatPosEndTime.SelectedIndex = 0;
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
       /* protected double totalHoursPerDay(TextBox txtBox, double hours)
        {
            int numPos = Convert.ToInt32(txtBox.Text);
            double dailyHours = numPos * hours;
            return dailyHours;            
        }*/

        // Clear button functionality
        protected void clear_Click(object Source, EventArgs E)
        {
            resetForm();
            setMessageVisibility();
        }

        
    }
}