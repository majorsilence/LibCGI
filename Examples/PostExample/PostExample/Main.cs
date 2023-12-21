using System;

namespace PostExample
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Write (Majorsilence.LibCGI.Cgi.Header);

			try {
				var cgi = new Majorsilence.LibCGI.Cgi ();
				Console.WriteLine ("AuthType: " + cgi.AuthType + "<br>");
				Console.WriteLine ("ContentLength: " + cgi.ContentLength + "<br>");
				Console.WriteLine ("ContentType: " + cgi.ContentType + "<br>");
				Console.WriteLine ("DocumentRoot: " + cgi.DocumentRoot + "<br>");
				Console.WriteLine ("GatewayInterface: " + cgi.GatewayInterface + "<br>");
				Console.WriteLine ("HttpAccept: " + cgi.HttpAccept + "<br>");
				Console.WriteLine ("HttpReferer: " + cgi.HttpReferer + "<br>");
				Console.WriteLine ("HttpUserAgent: " + cgi.HttpUserAgent + "<br>");
				Console.WriteLine ("PathInfo: " + cgi.PathInfo + "<br>");
				Console.WriteLine ("PathTranslated: " + cgi.PathTranslated + "<br>");
				Console.WriteLine ("QueryString: " + cgi.QueryString + "<br>");
				Console.WriteLine ("RemoteAddress: " + cgi.RemoteAddress + "<br>");
				Console.WriteLine ("RemoteHost: " + cgi.RemoteHost + "<br>");
				Console.WriteLine ("RemoteIdent: " + cgi.RemoteIdent + "<br>");
				Console.WriteLine ("RemoteUser: " + cgi.RemoteUser + "<br>");
				Console.WriteLine ("RequestMethod: " + cgi.RequestMethod + "<br>");
				Console.WriteLine ("ScriptName: " + cgi.ScriptName + "<br>");
				Console.WriteLine ("ServerName: " + cgi.ServerName + "<br>");
				Console.WriteLine ("ServerPort: " + cgi.ServerPort + "<br>");
				Console.WriteLine ("ServerProtocol: " + cgi.ServerProtocol + "<br>");
				Console.WriteLine ("ServerSoftware: " + cgi.ServerSoftware + "<br>");

				Console.WriteLine ("PostData: " + cgi.PostData + "<br>");
				Console.WriteLine ("<br>");
				Console.WriteLine ("play: " + cgi.Query["play"] + "<br>");
				Console.WriteLine ("other: " + cgi.Query["other"] + "<br>");
			}
			catch (Exception ex) {
				Console.WriteLine ("Error In CGI<br>");
				Console.WriteLine ("Message: " + ex.Message + "<br>");
				Console.WriteLine ("StackTrace: " + ex.StackTrace + "<br>");
			}
		}
	}
}
