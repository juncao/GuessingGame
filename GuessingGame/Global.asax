<%@ Application Language="C#" %>

<script runat="server">

   // Not really anything to do here 
   void Application_Start(object sender, EventArgs e) 
    {
       Application["Manager"] = new GameManager();

    }
    
    void Application_End(object sender, EventArgs e) 
    {
       Application["Manager"] = null;
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
       
       // for testing destroy Manager if a Session ends
       Application["Manager"] = null;
    
       //Destroys the Manager but not the Game
       // Don't trust this but don't waste time here either

    }
       
</script>
