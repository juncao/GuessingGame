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
using System.Web.SessionState;  // for HttpSessionState
//using System.Data;
//using System.Configuration;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Game
/// </summary>
public class Game
{
    // more than two states to game, so use an enum 
    // possible values are:
    //      Started = game started but no play yet
    //      Playing = play still going on for one or both players - may not actually need this
    //      GameOver = play all done - both players have correct results
    // enum defines values
    private enum Status {Started, Playing, GameOver};

    #region object member variables list is here - click on plus at left
    // Each Game object gets its own set
    /// players are stored as "SessionID" strings with names numbers and guesses
    /// Do we really need all of these?
    private string player1ID;
    private string player2ID;
    private string player1Name;
    private string player2Name;
    private int secretNumber1;
    private int secretNumber2;
    private int Guesses1;
    private int Guesses2;
    // status variables
    private Status gameStatus;
    private Status player1Status;
    private Status player2Status;
    #endregion
  
    /// <summary>
    /// Game constructor
    /// requires two players
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    public Game(string name1, string ID1, string name2, string ID2)
    {
        player1ID = ID1;
        player2ID = ID2;
        player1Name = name1;
        player2Name = name2;
        Guesses1 = 0;
        Guesses2 = 0;
        gameStatus = Status.Started;
        player1Status = Status.Started;
        player2Status = Status.Started;
        secretNumber1 = 0;
        secretNumber2 = 0;
    }
    
    /// <summary>
    /// MakeGuess Returns one of the following string values describing the guess
    /// "Correct"
    /// "Low"
    /// "High"
    /// "Too Early"
    /// Or throws an Argument Exception if the ID is unrecognized
    /// </summary>
    /// <param name="playerID"></param>
    /// <param name="guess"></param>
    /// <returns></returns>
    public string makeGuess(string playerID, int guess)
    {
        string result = null;

        // gameStatus 
        if (gameStatus != Status.GameOver
            && gameStatus != Status.Started)
        {
            if (player1ID == playerID)
            {
                if (player1Status == Status.Playing)
                {
                    #region Player1 - click on plus at left to expand code
                    Guesses1++;
                    if (guess == secretNumber1)
                    {
                        player1Status = Status.GameOver;
                        result = "Correct";
                    }
                    else if (guess > secretNumber1)
                    {
                        player1Status = Status.Playing;
                        result = "High";
                    }
                    else
                    {
                        player1Status = Status.Playing;
                        result = "Low";
                    }
                    #endregion
                }
                else
                {
                    throw new InvalidOperationException("player is done or has no secret to guess yet");
                }
           }
            else if (player2ID == playerID)
            {
                if (player2Status == Status.Playing)
                {
                    #region Player2 - click on plus at left to expand code
                    Guesses2++;
                    if (guess == secretNumber2)
                    {
                        player2Status = Status.GameOver;
                        result = "Correct";
                    }
                    else if (guess > secretNumber2)
                    {
                        player2Status = Status.Playing;
                        result = "High";
                    }
                    else
                    {
                        player2Status = Status.Playing;
                        result = "Low";
                    }
                    #endregion
                }
                else
                {
                    throw new InvalidOperationException("player is done or has no secret to guess yet");
                }
            }
            else  // no match for playerID
                throw new ArgumentException("Invalid Player ID");
        }
        else  // Game is over - no play possible
            throw new InvalidOperationException("Game NOT in play");

        // Now check if game is over
        if (player1Status == Status.GameOver && player2Status == Status.GameOver)
        {
            gameStatus = Status.GameOver;
        }

        return result;
    }

    public int getGuessesForPlayer(string playerID)
    {
        int guessCount = 0;
        if (playerID == player1ID)
        {
            guessCount = Guesses1;
        }
        else if (playerID == player2ID)
        {
            guessCount = Guesses2;
        }
        else // Who is calling us?
            throw new ArgumentException("Invalid Player ID");

        return guessCount;
    }

    public void setSecretNumberForOpponent(string playerID, int secret)
    {
        if (secret >= 1 || secret >= 100)
        {
            if (player1ID == playerID)
            {
                secretNumber2 = secret;
                player2Status = Status.Playing;
            }
            else if (player2ID == playerID)
            {
                secretNumber1 = secret;
                player1Status = Status.Playing;
            }
            else  // no match for playerID
                throw new ArgumentException("Invalid Player ID");
        }
        else
            throw new ArgumentOutOfRangeException("Secret number must be in range of 1 to 100 inclusive");

        // Check if both set and then allow play
        if (secretNumber1 != 0 && secretNumber2 != 0)
        {
            gameStatus = Status.Playing;
        }
    }

    public bool isGameDone()
    {
        Boolean gameDone = false;
        if (gameStatus != Status.GameOver)
        {
            if
              (player1Status == Status.GameOver && player2Status == Status.GameOver)
            { gameStatus = Status.GameOver;
              gameDone = true;  
            }
        }
        return gameDone;
    }

    public string getWinnerName()
    {
        string result = "Not done";
            if (Guesses1 == Guesses2) // tie
            {
                result = "Tie";
            }
            else if (Guesses1 > Guesses2) // player1 loses
            {
                result = player2Name;

            }
            else
            {
                result = player1Name;
            }
        return result;
    }
    public void resetGame()
    {
        gameStatus = Status.Started;
        player1Status = Status.Started;
        player2Status = Status.Started;
        Guesses1 = 0;
        Guesses2 = 0;
        secretNumber2 = 0;
        secretNumber1 = 0;
    }


}
