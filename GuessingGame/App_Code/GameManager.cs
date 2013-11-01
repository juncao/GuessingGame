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
using System.Web.SessionState;
using System.Collections;

/// <summary>
/// Summary description for GameManager
/// </summary>
public class GameManager
{
    private static GameManager self = null;
	private ArrayList waitingList;

	/// <summary>
	/// Manager
	/// Constructor 
	/// </summary>
	public GameManager()
	{
		waitingList = new ArrayList();
	}

    public static GameManager getManager()
    {
        if (self == null)
            self = new GameManager();

        return self;
    }
	/// <summary>
	/// registerPlayer
	/// This method adds a player as a HttpSessionState object
	/// to the waitinglist.
	/// When there are two players 
	/// they are passed to a new Game object
	/// and removed from the list 
	/// </summary>
	public void registerPlayer(HttpSessionState player)
	{
		waitingList.Add(player);
		// if 2 or more waiting, make a game 
		if( waitingList.Count >= 2 )
		{
			//Creates a new game
			//Sends the two session objects in the array
			//to the newly created game

			// Game constructor called passing name and SessionID for each player
			Game newGame = new Game(
                    (string)((HttpSessionState)waitingList[0])["Name"], 
                    (string)((HttpSessionState)waitingList[0]).SessionID, 
                    (string)((HttpSessionState)waitingList[1])["Name"], 
                    (string)((HttpSessionState)waitingList[1]).SessionID );
			
			// Give each player HttpSessionState object a reference to the Game
            // This is one way communication instead of two way
            ((HttpSessionState)waitingList[0])["Game"] = newGame;
            ((HttpSessionState)waitingList[1])["Game"] = newGame;
            ((HttpSessionState)waitingList[0])["Status"] = "In Game";
            ((HttpSessionState)waitingList[1])["Status"] = "In Game";
           
            // remove from waiting list
			waitingList.RemoveAt(0);
			waitingList.RemoveAt(0);  
		}
	}//end of function

}
