C# cgi library.  Just for fun.

See Examples folder to see how to use this library.


### PostExample.exe
```c#
Console.Write (LibCGI.Cgi.Header);

var cgi = new LibCGI.Cgi ();
Console.WriteLine ("RequestMethod: " + cgi.RequestMethod + "<br>");
Console.WriteLine ("QueryString: " + cgi.QueryString + "<br>");
Console.WriteLine ("PostData: " + cgi.PostData + "<br>");

// Access specific querystring/post key values.
// This example has an html form with a "play" and "other" field.
Console.WriteLine ("play: " + cgi.Query["play"] + "<br>");
Console.WriteLine ("other: " + cgi.Query["other"] + "<br>");
```

On linux systems .net (mono) applications need a shell script to execute them. The
following page script executes the mono program and passes in all arguments.

Both the bash file and .net (mono) executable need to be in the cgi-bin folder.

### postexample
```bash
#!/bin/bash

/usr/bin/mono PostExample.exe $@
```

Form that calls the cgi file.
```html
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<meta content="text/html; charset=ISO-8859-1" http-equiv="content-type">
<title>CGI Post Example</title>
</head>
 
<body>
<h2>Form for Testing CGI POST</h2>
 
<form action="/cgi-bin/postexample" method="POST">
Enter your own input here: <INPUT TYPE="text" NAME="play" SIZE="30" /><br />
Enter your other input here: <INPUT TYPE="text" NAME="other" SIZE="30" /><br />
<input type="submit" value="Submit Report with POST" />
</form>
 
</body>
</html>
```
