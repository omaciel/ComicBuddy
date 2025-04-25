// Comic Buddy #
//
// Author: Gnu Kemist
//

using Gtk;
using GtkSharp;
using System;
using System.Drawing;
using System.Collections;
	
namespace ComicBuddy {
	public class ComicBuddy
	{


		private	ComicStrips oComicStrips;
		
		private Window window;
				
		private Table myTable;
		private Gtk.Image myImg;
		private Calendar myCal;
		private Combo myCombo;
		private Button quitButton;
		private Button aboutButton;
	
		private ComicStrip myComic;		

		/* Event for myCombo */
		//void OnEntryActivated (object obj, EventArgs args)
		void OnEntryChanged (object obj, EventArgs args)
     		{
     			string comic = myCombo.Entry.Text.ToString();
     			
          		//myComic = oComicStrips.GetComicStrip(myCombo.Entry.Text);
          		myComic = oComicStrips.GetComicStrip("Garfield");
          		Console.WriteLine(comic);
     		}
     				
		/* Handles click event for the calendar control */
		void HandleDaySelected( object obj, EventArgs args)
		{
			Calendar activatedCalendar = (Calendar) obj;
			Console.WriteLine(activatedCalendar.GetDate().ToString("yy/MM/dd") + " * " +  myCombo.Entry.Text);
		}

		/* Exit application when user clicks on the 'x' button */
		static void delete_event (object obj, DeleteEventArgs args)
		{
			Application.Quit();
		}
		
		/* Exists the application */
		static void exit_event (object obj, EventArgs args)
		{
			Application.Quit();
		}

		/*  */
		static void about_event (object obj, EventArgs args)
		{
			ComicBuddyAbout dialog = new ComicBuddyAbout();
		}

		//public void populateComboBox();
		
		public void Run()
		{
			Application.Init ();

			/* Create a new window */
			window = new Window ("ComicBuddy#");

			/* Instantiates ComicStrips object */
			oComicStrips = new ComicStrips();
			
			/* Set a handler for delete_event that immediately
			 * exits GTK. 						*/
			window.DeleteEvent += new DeleteEventHandler (delete_event);

			/* Sets the border width of the window. */
			window.BorderWidth= 20;

			/* Create a 2x2 myTable */
			myTable = new Table (3, 3, false);

			/* Put the myTable in the main window */
			window.Add(myTable);

			/* Create an image control */
			myImg = new Gtk.Image("./ga040412.gif");
			
			/* Insert an Image control into both
			 * upper quadrants */
			myTable.Attach(myImg, 0, 3, 0, 1);
			 
			myImg.Show();
			
			/* Create a calendar control */
			myCal = new Calendar();
			myCal.DisplayOptions = CalendarDisplayOptions.ShowHeading |
				 CalendarDisplayOptions.ShowDayNames |
				 CalendarDisplayOptions.ShowWeekNumbers;
				 
			myCal.DaySelected += new EventHandler(HandleDaySelected);
			
			/* Insert a calendar control into
			 * lower right quadrant */
			myTable.Attach(myCal, 2, 3, 2, 3);
			
			/* Create a combobox control */
			myCombo = new Combo();
			myCombo.Entry.Editable = false;
			
			/* Populates ComboBox */
			//GLib.List l = new GLib.List (IntPtr.Zero, typeof (string));
          		string[] l = {"Garfield","Calvin and Hobbes"};
          		
		        /* foreach (object myComic in oComicStrips)
          		{
               			l.Append ("String " + (ComicStrip)myComic.Name);
          		} */
          		//l.Append ("Garfield");
          		//l.Append ("Calvin & Hobbes");
          
          		myCombo.PopdownStrings = l;
          		//myCombo.Entry.Changed += new EventHandler (OnEntryChanged);
				myCombo.Entry.Changed += new EventHandler (OnEntryChanged);

			
			myTable.Attach(myCombo, 2, 3, 1, 2);
						 
			/* "Quit" button */
			quitButton = new Button("Quit");
			quitButton.Clicked += new EventHandler (exit_event);
			myTable.Attach(quitButton, 0, 1, 1, 2);
			quitButton.Show();

			/* "About" button */
			aboutButton = new Button("About");
			aboutButton.Clicked += new EventHandler (about_event);
			myTable.Attach(aboutButton, 1, 2, 1, 2);
			aboutButton.Show();
			
			myTable.Show();
			window.ShowAll();

			Application.Run();
		}
		
		public static void Main(string[] args)
		{
 
		  ComicBuddy t = new ComicBuddy();
		  t.Run();

		}
	}
}
