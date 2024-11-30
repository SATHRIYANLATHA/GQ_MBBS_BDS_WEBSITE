using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using pmcdll;
using System.Data.SqlClient;
using System.Net;


public partial class Covid19TestResultMsg : System.Web.UI.Page
{
    public string upldfilename = "";
    public int noofrecords = 0;
    Class1 cls = new Class1();
    AppData ap = new AppData();
    public DataTable gbldt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {            
            noofrecords = Convert.ToInt32(hdn_noofrecords.Value);
            upldfilename = hdn_upldfilename.Value;
        }
        else
        {
            labupderror.Text = "";
        }
    }

    protected void buttImport_Click(object sender, EventArgs e)
    {
        
        string strFolder;
        string stmpdatetime, tmpfilename, tmpfileext, newfilename, strFileName, strFilePath="";
        string[] filenamearr;
        string[] stringSeparators = new string[] { "." };
        Boolean filesaved = false;
        lab_excelerrormsg.Text = "";
        panel_excelerrormsg.Visible = false;
        //strFolder = Server.MapPath("./" + "Covid19TestResUpload" + "/ ");
        strFolder = Server.MapPath("./PMC/" + ap.UploadFileLocation + "/ ");
        stmpdatetime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        if (UsrupdFile.HasFile)  //fileupload control contains a file  
        {
            try
            {
                //UsrupdFile.SaveAs("Covid19TestResUpload\\" + UsrupdFile.FileName);          // file path where you want to upload  
                upldfilename = UsrupdFile.FileName;
                hdn_upldfilename.Value = upldfilename;
                filenamearr = UsrupdFile.FileName.Split(stringSeparators, StringSplitOptions.None);
                tmpfilename = filenamearr[0];
                tmpfileext = filenamearr[1].ToLower();
                newfilename = "COVID19_" + tmpfilename + "_" + stmpdatetime + "." + tmpfileext;
                if (tmpfileext == "xls" || tmpfileext == "xlsx")
                {
                    //if (UsrupdFile.va != "")
                    //{

                    //}
                        newfilename = newfilename.Replace(" ", "");
                    strFileName = newfilename;
                    strFilePath = strFolder + strFileName;
                    UsrupdFile.PostedFile.SaveAs(strFilePath);
                    filesaved = true;
                    //labupderror.Text = "File Uploaded Sucessfully !! " + UsrupdFile.PostedFile.ContentLength + "mb";     // get the size of the uploaded file  
                    labupderror.Text = "Uploaded File Name :  " + UsrupdFile.PostedFile.FileName;
                }
                else
                {
                    labupderror.Text = "File Format not supported, please upload .xls or. xlsx file only";
                }
            }
            catch (Exception ex)
            {
                labupderror.Text = "File Not Uploaded!!" + ex.Message.ToString();
            }
        }

        else
        {
            labupderror.Text = "Please Select the File and Upload Again";
        }

        //Create a new DataTable.
        DataTable dt = new DataTable();
      

        if (filesaved==true) 
        {
            //result_panel.Visible = true;
            //input_panel.Visible = false;

            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(strFilePath, false))
            {
                //Read the first Sheet from Excel file.
                Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                //Get the Worksheet instance.
                Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

                //Fetch all the rows present in the Worksheet.
                IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
                
                //Loop through the Worksheet rows.
                foreach (Row row in rows)
                {
                    //Use the first row to add columns to DataTable.
                    if (row.RowIndex.Value == 1)
                    {
                        foreach (Cell cell in row.Descendants<Cell>())
                        {
                            dt.Columns.Add(GetValue(doc, cell));
                        }
                    }
                    else
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;
                        foreach (Cell cell in row.Descendants<Cell>())
                        {                           
                            dt.Rows[dt.Rows.Count - 1][i] = GetValue(doc, cell);
                            i++;
                        }
                    }
                }

                // Check for valid inputs 
                Boolean errorExists = false;
                string[] xlcols = { " LAB No", " Patient Name", " Age and Gender", " Address", " Mobile number"," Hospital", " Date of Receiving", " Date of Dispatch", " Result", " SRF ID" };
                string err = "";
                long res1;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    for (int j=0; j<=dt.Columns.Count-1; j++)
                    {
                        if (dt.Rows[i][j].ToString() == "")
                        {
                            err = err + ("<b>Row " + Convert.ToString(i + 1) + " Column " + Convert.ToString(j + 1) + "</b> : " +  xlcols[j] + " should not be empty <br>");
                            errorExists = true;                         
                        }
                        else
                        {
                            if (j == 4)
                            {
                                if (long.TryParse(dt.Rows[i][j].ToString(), out res1))
                                {
                                    if(dt.Rows[i][j].ToString().Length !=10)
                                    {
                                        err = err + ("<b>Row " + Convert.ToString(i + 1) + " Column " + Convert.ToString(j + 1) + "</b> : " + xlcols[j] + " seems to be incorrect<br>");
                                    }
                                }
                                else
                                {
                                    err = err + ("<b>Row " + Convert.ToString(i + 1) + " Column " + Convert.ToString(j + 1) + "</b> : " + xlcols[j] + " should be Numeric<br>");
                                }
                            }
                            if ((j == 6) || (j == 7))
                            {
                                if (dt.Rows[i][j].ToString().Length != 10)
                                {
                                    err = err + ("<b>Row " + Convert.ToString(i + 1) + " Column " + Convert.ToString(j + 1) + "</b> : " + xlcols[j] + " check the date <br>");
                                }
                            }
                        }                        
                    }
                   
                    
                }
                lab_excelerrormsg.Text = err;

                if (errorExists == true)
                {
                    panel_excelerrormsg.Visible = true;
                    return;
                }
                else
                {
                    result_panel.Visible = true;
                    input_panel.Visible = false;
                }


                GridView1.DataSource = dt;
                GridView1.DataBind();
                noofrecords = dt.Rows.Count;
                hdn_noofrecords.Value = Convert.ToString(noofrecords);
            }

            

            string s1 = "";
            char spliter ;
            string gstring = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= dt.Columns.Count - 1; j++)
                    {
                        if ((j == 6) || (j == 7))
                        {
                            spliter = '.';
                            if (dt.Rows[i][j].ToString().IndexOf(".") >0) 
                            {
                                spliter = '.';
                            }
                            else if (dt.Rows[i][j].ToString().IndexOf("-") > 0)
                            {
                                spliter = '-';
                            }
                            else if (dt.Rows[i][j].ToString().IndexOf("/") > 0)
                            {
                                spliter = '/';
                            }
                            string[] subs = dt.Rows[i][j].ToString().Split(spliter);
                            s1 = subs[1] + "/" + subs[0] + "/" + subs[2];
                            dt.Rows[i][j] = s1;
                        }
                        if (j == 2)
                        {
                            dt.Rows[i][j] = dt.Rows[i][j].ToString().Replace(" ","");
                        }
                        if (j <= dt.Columns.Count - 2)
                        {
                            gstring = gstring + dt.Rows[i][j].ToString() + "|";
                        }
                        else
                        {
                            gstring = gstring + dt.Rows[i][j].ToString();
                        }
                    }
                    gstring = gstring + "~";
                }                
                hdn_xlrawdata.Value = gstring;
                gbldt = dt;

            }

        }
    }



    private string GetValue(SpreadsheetDocument doc, Cell cell)
    {
        string value = "";
        try
        {
            value = cell.CellValue.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            }
            else if (cell.DataType == null) // number & dates.
            {
                int styleIndex = (int)cell.StyleIndex.Value;
                CellFormat cellFormat = doc.WorkbookPart.WorkbookStylesPart.Stylesheet.CellFormats.ChildElements[int.Parse(cell.StyleIndex.InnerText)] as CellFormat;
                uint formatId = cellFormat.NumberFormatId.Value;

                if (formatId == (uint)Formats.DateShort || formatId == (uint)Formats.DateLong)
                {
                    double oaDate;
                    if (double.TryParse(cell.InnerText, out oaDate))
                    {
                        value = DateTime.FromOADate(oaDate).ToShortDateString();
                    }
                }
                else
                {
                    value = cell.InnerText;
                }
            }
        }
        catch (Exception ex)
        {

        }
        return value;
    }

    private enum Formats
    {
        General = 0,
        Number = 1,
        Decimal = 2,
        Currency = 164,
        Accounting = 44,
        DateShort = 14,
        DateLong = 165,
        Time = 166,
        Percentage = 10,
        Fraction = 12,
        Scientific = 11,
        Text = 49
    }

    public string RemoveSpecialCharacters(string text)
    {
        return System.Text.RegularExpressions.Regex.Replace(text, @"(\s+|\*|\#|\@|\$)", "");
    }

    private string GetValue_1(SpreadsheetDocument doc, Cell cell)
    {
        string value = cell.CellValue.InnerText;
        if (cell.DataType != null && cell.DataType.Value == CellValues.Date)
        {
            return value;// doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
        }
           else if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
        {
            return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
        }
        return value;
    }


    protected void btn_Back_Click(object sender, EventArgs e)
    {
        input_panel.Visible = true;
        result_panel.Visible = false;
        labupderror.Text = "";
        lab_successmsg.Text = "";
        btn_SendSMS.Visible = true;
        btn_SendSMS.Enabled= true;
    }

    protected void btn_SendSMS_Click(object sender, EventArgs e)
    {
        
        string xlrawdata = hdn_xlrawdata.Value;
        
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dtdata = new DataTable();
       
        string connstr = "";
        try
        {
            connstr = ap.dbConnStr;
            

            ds = cls.set_covid19testresultxlupload(xlrawdata, connstr);
        if (ds.Tables.Count > 0)
        {
            dt = ds.Tables[0];
            dtdata = ds.Tables[1];
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["cnt"].ToString()) > 0)
                {
                    lab_successmsg.Text = "Data saved and SMS has been sent successfully";
                    btn_SendSMS.Enabled = false;                    
                    sendSMS(dtdata);// Sending SMS
                }
                if (Convert.ToInt32(dt.Rows[0]["cnt"].ToString()) == 0)
                {
                    lab_successmsg.Text = "Data already been saved";
                    btn_SendSMS.Visible = false;
                }
            }
        }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        hdn_xlrawdata.Value = "";
    }
    protected void sendSMS(DataTable dt)
    {       
        string templateId = "1407162065828534452";
        string SenderID = "CALLER";
        string key = "772a06a9514af34b644290e029e8404e";
        string tomobno = "";
        string url = "";
        //string msgformat = "{#var#} sample tested for {#var#} {#var#} {#var#} {#var#} {#var#} {#var#}";
        //msgformat = "RT-PCR " + "sample tested for " + "JAGANNATHAN " + "(Id:JAGANNATHAN) " + "SRF ID TGMC-21-79107 " + "on May 12, 2021 at GMCH, " + "TLR is found to be " + "Negative for COVID 19.";
        string tmpmsg = "";
        for (int i=0;i<=dt.Rows.Count-1;i++)
        {
            tomobno = dt.Rows[i]["MobileNo"].ToString();
            //tomobno = "8925467090";
            //tmpmsg = "RT-PCR " + "sample tested for " + dt.Rows[i]["PatientName"].ToString() + "(Id:" + dt.Rows[i]["PatientName"].ToString() + ") " + dt.Rows[i]["SFRID"].ToString() + " " + " on " + dt.Rows[i]["ReceiveDate"].ToString() + " at GMCH, TLR is found to be " + dt.Rows[i]["Result"].ToString() + " for COVID 19.";
            //tmpmsg = "Swab " + "sample tested for " + dt.Rows[i]["PatientName"].ToString() + " SRF:" + dt.Rows[i]["SFRID"].ToString() + " (LAB:" + dt.Rows[i]["LABNO"].ToString() + ") TESTED BY RTPCR ON  " + dt.Rows[i]["ReceiveDate"].ToString() + " at GMCH, TLR is found to be " + dt.Rows[i]["Result"].ToString().ToUpper() + " for COVID 19.";
            tmpmsg = "Swab " + "sample tested for " + dt.Rows[i]["PatientName"].ToString().ToUpper() + " SRF:" + dt.Rows[i]["SFRID"].ToString() + " (" + dt.Rows[i]["LABNO"].ToString() + ") BY RTPCR ON  " + dt.Rows[i]["ReceiveDate"].ToString() + " at GMCH, TLR is found to be " + dt.Rows[i]["Result"].ToString().ToUpper() + " for COVID 19.";
            url = @"http://login.olasms.in/api/smsapi?key=" + key + "& route=1&sender=" + SenderID + "&number=" + tomobno + " &templateid=" + templateId + "&sms=" + tmpmsg;
            WebRequest request = HttpWebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string urlText = reader.ReadToEnd(); // it takes the response from your url. now you can use as your need  
        }
        


        //old string url = @"http://login.olasms.in/api/smsapi?key=3a337ce2adeb5455bfe48e8bb7e577de&route=1&sender=CALLER&number=919444685550&templateid=1407161760188461136&sms=" + MyBox.Text.Trim();
       // string url = @"http://login.olasms.in/api/smsapi?key=" + key + "& route=1&sender=" + SenderID + "&number=" + tomobno + " &templateid=" + templateId + "&sms=" + msgformat;
        //WebRequest request = HttpWebRequest.Create(url);
        //WebResponse response = request.GetResponse();
        //StreamReader reader = new StreamReader(response.GetResponseStream());
        //string urlText = reader.ReadToEnd(); // it takes the response from your url. now you can use as your need  
        //Response.Write(urlText.ToString());


    }

}