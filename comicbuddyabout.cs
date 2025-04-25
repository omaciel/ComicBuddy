using System;
using Gtk;

class ComicBuddyAbout
{
	// Members
	private Dialog dialog;
	
	public ComicBuddyAbout()
	{
	    
	    dialog = new Dialog();
	    dialog.Title = "About ComicBuddy#";
		//dialog = new Dialog ("About ComicBuddy#", win, DialogFlags.DestroyWithParent);
            dialog.Modal = true;
            dialog.AddButton ("Close", 5);
            dialog.Response += new ResponseHandler (on_dialog_response);
            dialog.Run ();
            dialog.Destroy ();
        }
          
        void on_dialog_response (object obj, ResponseArgs args)
        {
            Console.WriteLine (args.ResponseId);
        }


}
