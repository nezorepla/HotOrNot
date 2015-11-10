using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class hon : System.Web.UI.Page
{



    /*
     
       CREATE TABLE [dbo].[qm_hon](
	[intcode] [int] IDENTITY(1,1) NOT NULL,
	[challenge_id] [int] NULL,
	[isim] [varchar](50) NOT NULL,
	[sicil] [varchar](6) NOT NULL,
	[valid] [int] NOT NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[qm_hon] ADD  CONSTRAINT [DF_qm_hon_valid]  DEFAULT ((1)) FOR [valid]
 


     * 
     * 
CREATE TABLE [dbo].[qm_hon_v](
	[intcode] [int] IDENTITY(1,1) NOT NULL,
	[challenge_id] [int] NULL,
	[usr] [varchar](20) NULL,
	[uid] [varchar](20) NULL,
	[vote] [int] NULL,
	[sezon] [int] NULL,
	[date] [datetime] NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[qm_hon_v] ADD  CONSTRAINT [DF_qm_hon_v_date]  DEFAULT (getdate()) FOR [date] 

     * 
     * 
      
   insert into  dbo.qm_hon (challenge_id,isim, sicil)
 SELECT TOP 1000 
    0,  [AD_SOYAD],a.[SICIL]
  FROM [NEW_INTRANET].[dbo].[INTRA_Fact_AGENT_LIST] a left join INTRA_TBL_AGENTSTATUS b on a.SICIL=b.SICIL
  where b.GND_CODE='K'
  
     
     * 
     * 

create proc INTRA_SP_HON as

SELECT   a.intcode,a.sicil,a.isim,count(b.vote) as oyadet,sum(b.vote) as oytoplam ,MAX(b.intcode) mx
        FROM  dbo.qm_hon a
        Left outer join  dbo.qm_hon_v b
        on a.sicil=b.uid and a.challenge_id=b.challenge_id 
       group by a.intcode,a.sicil,a.isim  
         order by   count(b.vote) asc ,MAX(b.intcode) asc
 
     * 
     * 
ALTER proc [dbo].[INTRA_SP_CHL] as 
 
//weighted rating (WR) = (v ÷ (v+m)) × R + (m ÷ (v+m)) × C 
//R = average for the movie (mean) = (Rating)
//v = number of votes for the movie = (votes)
//m = minimum votes required to be listed in the Top 250 (currently 25,000)
//C = the mean vote across the whole report

 

select top 5 *,(oyadet /(oyadet+4)) * rating + (4 /(oyadet+4)) * 0.15  raiting
from (
SELECT    a.intcode,a.sicil,a.isim ,convert(float,count(b.vote)) as oyadet,convert(float,sum(b.vote)) as oytoplam , convert(float,sum(b.vote))/convert(float,count(b.vote)) rating
 FROM dbo.qm_hon a
       inner   join dbo.qm_hon_v b
       on  a.sicil=b.uid and a.challenge_id=b.challenge_id 
       group by a.intcode,a.sicil,a.isim  
       )x 
   order by  (oyadet /(oyadet+4)) * rating + (4 /(oyadet+4)) * 0.15  desc ,NEWID()     
     
     */

    public string cEDWUserId;
    public string cEDWPassword;
    public string USER;

 
  

    protected void Page_Load(object sender, EventArgs e)
    {
        USER = HttpContext.Current.User.Identity.Name.ToUpper().Replace("İ", "I").Substring(7, 6).ToString();


        if (Page.IsPostBack)
        {



            if (Request["__EVENTTARGET"] == "budur")
            {
                //do something
                IslemYap(Request["__EVENTARGUMENT"].ToString());
            }
        }
        else
        {
            if (kontrol())
            {
                main();
            }
            else
            {

            }

            Random rnd = new Random();
            TextBox1.Text = rnd.Next(1000000000, 2147483647).ToString();
        }

    }


    public void IslemYap(string Id)
    {
        string TKN = TextBox1.Text.ToString();


        string query = "insert into dbo.qm_hon_v(challenge_id,usr,uid,vote,sezon) values (0,'" + USER + "','" + Id.Trim().Replace("-", "',1," + TKN + "); insert into dbo.qm_hon_v(challenge_id,usr,uid,vote,sezon) values (0,'" + USER + "','") + "',0," + TKN + ")";
    

        PCL.MsSQL_DBOperations.ExecuteScalarSQLStr(query,"NEWINTRA");
 
  

        main();
        //Page.ClientScript.RegisterStartupScript(typeof(Page), "msgseysi", "alert('" + Id + "')", true);




    }

    public bool kontrol() { 
       //InitEDWUser();
       //DataTable dt2 = PCL.Oracle_DBOperations.GetData(sql2, "EDWConn", cEDWUserId, cEDWPassword);


        if (USER ==  USER  
            )
        {
            return true;
        }
        else { return false; }

    }

    public void main()
    {
        //     

        string cmd2 = "EXEC INTRA_SP_HON";






        DataTable dt = PCL.MsSQL_DBOperations.GetData(cmd2, "NEWINTRA");





        string ana = "<div class=\"ana\"><table style=\"width:500px;\"><tr>";


        if (dt.Rows.Count > 0)
        {
            ana += "<td  style=\"width:250px;\"><A  href=\"javascript:__doPostBack('budur','" + dt.Rows[0]["sicil"] + "-" + dt.Rows[1]["sicil"] + "');\" class=\"bu_1\"   id=\"" + dt.Rows[0]["intcode"] + "\"> <img class=\"chl_img\" title=\"" + dt.Rows[0]["sicil"] + "\" src=\"http://profil.bizcemumkun/User%20Photos/Profil%20Resimleri/000" + dt.Rows[0]["sicil"].ToString().Substring(1, 5) + "_LThumb.jpg\"> </A></td>";
            ana += "<td  style=\"width:250px;\"><A  href=\"javascript:__doPostBack('budur','" + dt.Rows[1]["sicil"] + "-" + dt.Rows[0]["sicil"] + "');\" class=\"bu_2\"   id=\"" + dt.Rows[0]["intcode"] + "\"> <img class=\"chl_img\" title=\"" + dt.Rows[1]["sicil"] + "\" src=\"http://profil.bizcemumkun/User%20Photos/Profil%20Resimleri/000" + dt.Rows[1]["sicil"].ToString().Substring(1, 5) + "_LThumb.jpg\"> </A></td>";


        }

        ana += "</tr><tr><td colspan=\"2\" style=\"  text-align: center;\">" + toplar() + "</td></tr></table></div>";


        Label1.Text = ana;
   
    }

    public string toplar()
    {

        //  '###################################
        string cmd3 = "exec INTRA_SP_CHL";




        DataTable dt = PCL.MsSQL_DBOperations.GetData(cmd3, "NEWINTRA");


        string ana = " <img style=\"padding-top:50 px;\" src=\"https://badgeos.org/wp-content/uploads/edd/2013/11/leaderboard-300x300.png\" height=\"150\" width=\"150\" alt=\"Leader Board\">  <table>";

        int x = 1;

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                ana += "<tr><td>" + x.ToString() + "</td><td><span class=\"top_" + x + "\"   id=\"" + dr["intcode"] + "\"> <img title=\"" + dr["sicil"] + "\" height=\"50%\" width=\"50%\" src=\"Resimleri/000" + dr["sicil"].ToString().Substring(1, 5) + "_LThumb.jpg\"> </span></td><td>" + dr["isim"] + " </td><td>" + PCL.Utility.DBtoMT.ToDouble(dr["raiting"])  + " </td></tr>";

                x++;
            }
        }

        ana += "</table> ";

 return ana;

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
   
        Page.ClientScript.RegisterStartupScript(typeof(Page), "msgseysi", "alert('DAHA DEGIL!')", true);
 
    }
}
