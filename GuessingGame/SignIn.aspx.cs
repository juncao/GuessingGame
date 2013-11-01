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
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Status"] == null) // first load
        {
            formLoad.Text = "First Load";
            lblPrompt.Text = "Enter your name and a secret number between 1 and 100 for your opponent to guess";
        }
        else if (((string)Session["Status"]).Equals("Registered")) // wait here
        {
            // refresh the data on the form
            Response.AppendHeader("Refresh", "3");
        }
        else if (((string)Session["Status"]).Equals("In Game"))
        {
            startPlay();
        }
        else if (((string)Session["Status"]).Equals("Reset"))
        {
            // Definitely a little something to do here
            lblPrompt.Text = "Enter your a secret number between 1 and 100 for your opponent to guess";
            txtName.Enabled = false;
        }
     }// end of Page_Load
   

    // Player is registering
    // Receives the standard parameters
    protected void btnPlayGame_Click(object sender, EventArgs e)
    {
        // if there is data, process it
        if (txtName.Text != "" && txtSecretNumber.Text != "")
        {
            // is the data good?  Do we care?  How high can it blow up anyway?
            // Set Name so it is available for GameManager
            Session["Name"] = txtName.Text;
            Session["SecretNumberString"] = txtSecretNumber.Text;

            Session["Status"] = "Registered";
            // Use the Application variable to keep only one copy of the GameManager
            // Pass our identity, Game will use SessionID
            GameManager.getManager().registerPlayer(Session);
            setWaitingValues();  // where is this??
            
            // Even while we registered, someone else might have registered too
            // And a Game been started for us  - start playing
            if ((Session["Game"]) != null)
            {
                Response.Redirect("GuessingPage.aspx", true);
            }

            // useful for tracking what is going on
            formLoad.Text = Session["Name"] + " : " + Session.SessionID.ToString();
        }
        else // no data
        {
            formLoad.Text = "You must enter both a name and a number";
        }
    }

    private void setWaitingValues()
    {
        lblPrompt.Text =
            "You are waiting for a suitable opponent <br>You will automatically be sent to a new page when there is another player ";
        btnPlayGame.Enabled = false;
        txtName.Enabled = false;
        txtName.Text = (string)Session["Name"];
        txtSecretNumber.Text = (string)Session["SecretNumberString"];
        txtSecretNumber.Enabled = false;
        // what else do we do while waiting ??  For that matter HOW do we WAIT?
    }

    private void startPlay()
    {
        // potential problem here.  What if they entered a letter?
        // Want to fix it?
        ((Game)Session["Game"]).setSecretNumberForOpponent(
                    Session.SessionID, int.Parse((string)Session["SecretNumberString"]));
        Response.ClearContent();
        Response.Redirect("GuessingPage.aspx", true);
    }
}// end of class
