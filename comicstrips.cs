// Comic Buddy #
//
// Author: Gnu Kemist
//

using System;
using System.Xml;
using System.IO;

/// <summary>
/// Summary description for ComicStrip.
/// </summary>

public class ComicStrips
{
	private System.Collections.Hashtable strips;

	public ComicStrips()
	{
		// Initialization of hashtable
		strips = new System.Collections.Hashtable();

		//Fetch Data from XML file
		System.Xml.XmlDocument xmlFile = new XmlDocument(); 
		xmlFile.Load("./comics.xml");
		
		//
		// TODO: Error handling; file path validation
		//
		//Load the the document with the last book node.
		//XmlTextReader reader = new XmlTextReader("./comics.xml");
		//reader.WhitespaceHandling = WhitespaceHandling.None;
		//reader.MoveToContent();
		//reader.Read();

		//xmlFile.Load(reader);
		
		// Walk down xml tree and populate comics hash
		System.Xml.XmlNodeList xmlComics=
			xmlFile.SelectNodes("/Comics/Comic");

		foreach(System.Xml.XmlNode xmlComic in xmlComics )
		{
			string name =
				xmlComic.SelectSingleNode("Name").InnerText ;
			string prefix =
				xmlComic.SelectSingleNode("Prefix").InnerText;
			string url =
				xmlComic.SelectSingleNode("URL").InnerText;
			DateTime startDate =
				Convert.ToDateTime(xmlComic.SelectSingleNode("StartDate").InnerText) ;
			DateTime endDate =
				Convert.ToDateTime(xmlComic.SelectSingleNode("EndDate").InnerText) ;
            
			// Creates new ComicStrip object
			ComicStrip newComic = new
				ComicStrip(name,prefix,url,startDate,endDate ); 
						// and add it to hash
			strips.Add(newComic.Name, newComic); 
			
		}
	}
	
		// Method
	public ComicStrip GetComicStrip(string Name)
	{
		//Return comic strip object from hashtable
		return (ComicStrip)this.strips[Name];
		
	}
		
}
  
public class ComicStrip
{
	private string _name = null;
	private string _url = null;
	private DateTime _startDate;
	private DateTime _endDate;
	private string _prefix = null;

	// Constructor
	public ComicStrip(ComicStrip o)
	{
		_name = o._name;
		_url = o._url;
		_startDate = o._startDate;
		_endDate = o._endDate;
		_prefix = o._prefix;
	}

	// Constructor
	public ComicStrip(string name,string prefix, 
		string url, DateTime startDate,
		DateTime endDate)
	{
		_name = name;
		_url = url;
		_startDate = startDate;
		_endDate = endDate;
		_prefix = prefix;
	}

	// Property ReadOnly
	public string Name
	{
		get {return _name;}
	}
	
	// Property ReadOnly
	public string Url
	{
		get {return _url;}
	}
	
	// Property ReadOnly
	public DateTime StartDate
	{
		get {return _startDate;}
	}
	
	// Property ReadOnly
	public DateTime EndDate
	{
		get {return _endDate;}
	}
	
		// Method
	public System.IO.Stream GetPictureStream(DateTime date)
	{
		// Below is an example of what the final URL should be:
		// string URL="http://images.ucomics.com/comics/ch/1993/ch930406.gif";
		// The member variable _url should be:
		// _url = "http://images.ucomics.com/comics/ch/
		
		// Build URL string
		string url = _url + date.Year.ToString() + "/" + _prefix + date.ToString("yy/MM/dd") + ".gif";
			
		System.IO.Stream comicPicture = StreamFromURL(url);
			
		//return proper stream here
		return comicPicture;
			
	}

	// Method
	private System.IO.Stream StreamFromURL(string URL) 
	{
		System.Net.WebClient WC = new System.Net.WebClient();
		return WC.OpenRead(URL);
	}

}
