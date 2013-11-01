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
using System.Drawing;

public partial class GuessingPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            lblGuesses.Text = Session["Name"] + " Your Guesses so far: ";
        }
       
        if (Session["Status"].Equals("PlayerDone"))
        {
            checkGameDone();
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string result;
        result = ((Game)Session["Game"]).makeGuess((string)Session.SessionID, int.Parse(txtGuess.Text));
        lblGuesses.Text = lblGuesses.Text + txtGuess.Text + ", "; 
        if (result.Equals("Correct"))
        {
            // You are done
            lblPrompt.Text = "You have guessed the secret number";
            btnSubmit.Enabled = false;
            txtGuess.Enabled = false;
            // set player status ???
            Session["Status"] = "PlayerDone";

        }
        else 
        {
            // keep guessing
            lblPrompt.Text = "Try again";
            // Is this all?
            txtGuess.Text = "";
            Response.Redirect("GuessingPage.aspx", true);
        }
        lblResults.Text = "Your guess was " + result + "<br> Your Status is " + (string)Session["Status"];
   }

    private void checkGameDone()
    {
        if (((Game)Session["Game"]).isGameDone())
        {
            // Go to result page
            Response.Redirect("resultsPage.aspx", true);
        }
        else
        {
            // wait for opponent
            Response.Write("Checking the result.");
            Response.AppendHeader("Refresh", "2");
        }

    }
}
