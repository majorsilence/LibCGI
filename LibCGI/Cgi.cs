using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCGI
{
    public class Cgi
    {
        public Cgi()
        {
            // server specific variables
            _gatewayInterface = System.Environment.GetEnvironmentVariable("GATEWAY_INTERFACE");
            _serverSoftware = System.Environment.GetEnvironmentVariable("SERVER_SOFTWARE");
            _serverName = System.Environment.GetEnvironmentVariable("SERVER_NAME");
            _serverProtocol = System.Environment.GetEnvironmentVariable("SERVER_PROTOCOL");
			int.TryParse(System.Environment.GetEnvironmentVariable("SERVER_PORT"), out _serverPort);

            _requestMethod = System.Environment.GetEnvironmentVariable("REQUEST_METHOD");
            _pathInfo = System.Environment.GetEnvironmentVariable("PATH_INFO");
            _pathTranslated = System.Environment.GetEnvironmentVariable("PATH_TRANSLATED");
            _scriptName = System.Environment.GetEnvironmentVariable("SCRIPT_NAME");
            _queryString = System.Environment.GetEnvironmentVariable("QUERY_STRING");
            _remoteHost = System.Environment.GetEnvironmentVariable("REMOTE_HOST");
            _remoteAddress = System.Net.IPAddress.Parse(System.Environment.GetEnvironmentVariable("REMOTE_ADDR"));
            _authType = System.Environment.GetEnvironmentVariable("AUTH_TYPE");
            _remoteUser = System.Environment.GetEnvironmentVariable("REMOTE_USER");
            _remoteIdent = System.Environment.GetEnvironmentVariable("REMOTE_IDENT");
			int.TryParse(System.Environment.GetEnvironmentVariable("CONTENT_LENGTH"), out _contentLength);
            _documentRoot = System.Environment.GetEnvironmentVariable("DOCUMENT_ROOT");
            _httpReferer = System.Environment.GetEnvironmentVariable("HTTP_REFERER");
            _httpUserAgent = System.Environment.GetEnvironmentVariable("HTTP_USER_AGENT");
            _httpAccept = System.Environment.GetEnvironmentVariable("HTTP_ACCEPT");
            RetrivePostData(_contentLength);
			SetQuery(_requestMethod);
        }

		private void SetQuery (string requestMethod)
		{
			string data;
			if (requestMethod == "POST") {
				data = PostData;
			} else {
				data = QueryString;
			}
			_query = new Dictionary<string, string>();

			string [] values = data.Split ('&');
			foreach (string val in values) {
				string [] split = val.Split('=');
				_query.Add(split[0], split[1]);
			}

		}

		private Dictionary<string, string> _query;
		public Dictionary<string, string> Query {
			get 
			{
				return _query;
			}
		}

        private string _postData = "";
        private void RetrivePostData(int contentLength)
        {
			byte[] data = null;
			using (var s = Console.OpenStandardInput())
			{
				using (var br = new System.IO.BinaryReader(s))
				{
					data = new byte[contentLength];
					br.Read(data, 0, contentLength);

					_postData = System.Text.Encoding.Default.GetString(data, 0, contentLength);
				}
	
			}
        }
        public string PostData
        {
            get
            {
                return _postData;
            }
        }

        private string _httpAccept="";
        /// <summary>
        /// A list of the MIME types that the client can accept.
        /// </summary>
        public string HttpAccept
        {
            get
            {
                return _httpAccept;
            }
        }

        private string _httpUserAgent = "";
        /// <summary>
        /// The name/version of the client issuing the request to the script.
        /// </summary>
        public string HttpUserAgent
        {
            get
            {
                return _httpUserAgent;
            }
        }

        private string _httpReferer = "";
        /// <summary>
        /// The URL that the referred (via a link or redirection) the web client to the script. 
        /// Typed URLs and bookmarks usually result in this variable being left blank.
        /// </summary>
        public string HttpReferer
        {
            get
            {
                return _httpReferer;
            }
        }

        private string _documentRoot = "";
        /// <summary>
        /// The directory over which all www document paths are resolved by the server.
        /// </summary>
        public string DocumentRoot
        {
            get
            {
                return _documentRoot;
            }
        }


        public static string Header
        {
            get
            {
                return "Content-Type: text/html\n\n";
            }
        }

        private int _contentLength;
        /// <summary>
        /// Similarly, size of input data (decimal, in octets) if provided via HTTP header.
        /// </summary>
        public int ContentLength
        {
            get
            {
                return _contentLength;
            }
        }

        private string _contentType = "";
        /// <summary>
        /// Internet media type of input data if PUT or POST method are used, as provided via HTTP header.
        /// </summary>
        public string ContentType
        {
            get
            {
                return _contentType;
            }
        }

        private string _remoteIdent = "";
        /// <summary>
        /// See ident, only if server performed such lookup.
        /// </summary>
        public string RemoteIdent
        {
            get
            {
                return _remoteIdent;
            }
        }

        private string _remoteUser = "";
        /// <summary>
        /// Used for certain AUTH_TYPEs.
        /// </summary>
        /// <remarks>Use with basic auth.</remarks>
        public string RemoteUser
        {
            get
            {
                return _remoteUser;
            }
        }

        private string _authType = "";
        /// <summary>
        /// Identification type, if applicable.
        /// </summary>
        public string AuthType
        {
            get
            {
                return _authType;
            }
        }

        private System.Net.IPAddress _remoteAddress;
        /// <summary>
        /// IP address of the client.
        /// </summary>
        public System.Net.IPAddress RemoteAddress
        {
            get
            {
                return _remoteAddress;
            }
        }

        private string _remoteHost = "";
        /// <summary>
        /// Host name of the client, unset if server did not perform such lookup.
        /// </summary>
        public string RemoteHost
        {
            get
            {
                return _remoteHost;
            }
        }

        private string _queryString = "";
        /// <summary>
        /// the part of URL after ? character. The query string may be composed of *name=value pairs separated with ampersands 
        /// (such as var1=val1&var2=val2...) when used to submit form data transferred via GET method as defined by HTML 
        /// application/x-www-form-urlencoded.
        /// </summary>
        public string QueryString
        {
            get
            {
                return _queryString;
            }
        }

        private string _scriptName = "";
        /// <summary>
        /// Relative path to the program, like /cgi-bin/script.cgi.
        /// </summary>
        public string ScriptName
        {
            get
            {
                return _scriptName;
            }
        }

        private string _pathTranslated = "";
        /// <summary>
        /// Corresponding full path as supposed by server, if PATH_INFO is present.
        /// </summary>
        public string PathTranslated
        {
            get
            {
                return _pathTranslated;
            }
        }

        private string _pathInfo = "";
        /// <summary>
        /// Path suffix, if appended to URL after program name and a slash.
        /// </summary>
        public string PathInfo
        {
            get
            {
                return _pathInfo;
            }
        }

        private string _requestMethod = "";
        /// <summary>
        /// Name of HTTP method.
        /// </summary>
        public string RequestMethod
        {
            get
            {
                return _requestMethod;
            }
        }

        private int _serverPort;
        /// <summary>
        /// TCP port
        /// </summary>
        public int ServerPort
        {
            get
            {
                return _serverPort;
            }
        }

        private string _serverProtocol = "";
        /// <summary>
        /// HTTP/version.
        /// </summary>
        public string ServerProtocol
        {
            get
            {
                return _serverProtocol;
            }
        }

        private string _serverName = "";
        /// <summary>
        /// Host name of the server, may be dot-decimal IP address.
        /// </summary>
        /// <remarks>Server specific variable.</remarks>
        public string ServerName
        {
            get
            {
                return _serverName;
            }
        }

        private string _serverSoftware = "";
        /// <summary>
        /// Name/version of HTTP server.
        /// </summary>
        /// <remarks>Server specific variable.</remarks>
        public string ServerSoftware
        {
            get
            {
                return _serverSoftware;
            }
        }

        private string _gatewayInterface = "";
        /// <summary>
        /// CGI/version.
        /// </summary>
        /// <remarks>Server specific variable.</remarks>
        public string GatewayInterface
        {
            get
            {
                return _gatewayInterface;
            }
        }


    }
}
