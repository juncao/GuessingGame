/*******************************************************************/
/**                                                               **/
/**                                                               **/
/**    Student Name                :  Jun Cao                     **/
/**    EMail Address               :  cao00051@algonquinlive.com  **/
/**    Student Number              :  040710235                   **/
/**    Course Number               :  CST8256                     **/
/**    Lab Section Number          :  442                         **/
/**    Professor Name              :  John Tappin                 **/
/**    Assignment Name/Number/Date :  MidTerm Test                **/
/**    Optional Comments           :                              **/
/**                                                               **/
/**                                                               **/
/*******************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class resultsPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblResults.Text = ((Game)Session["Game"]).getWinnerName() + " is the winner";
        // And We are ?????
    }
    
    protected void btnPlayAgain_Click(object sender, EventArgs e)
    {
        //reset the game  - How
        Response.Clear();
        Session["Status"] = "Reset";
        ((Game)Session["Game"]).resetGame();
        Response.Redirect("SignIn.aspx", true);
    }
}
