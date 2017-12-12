using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTTPServer
{
    public enum RequestMethod
    {
        GET,
        POST,
        HEAD
    }

    public enum HTTPVersion
    {
        HTTP10,
        HTTP11,
        HTTP09
    }

    class Request
    {
        string[] requestLines;
        RequestMethod method;
        public string relativeURI;
        Dictionary<string, string> headerLines;

        public Dictionary<string, string> HeaderLines
        {
            get { return headerLines; }
        }

        HTTPVersion httpVersion;
        string requestString;
        string[] contentLines;

        public Request(string requestString)
        {
            this.requestString = requestString;
        }
        /// <summary>
        /// Parses the request string and loads the request line, header lines and content, returns false if there is a parsing error
        /// </summary>
        /// <returns>True if parsing succeeds, false otherwise.</returns>
        public bool ParseRequest()
        {


            string[] RequestLines_Separator = new string[] { "\r\n" };
            this.requestLines = requestString.Split(RequestLines_Separator, StringSplitOptions.None);

            if (requestLines.Count() >= 3)
            {
                if (ParseRequestLine() == true && ValidateBlankLine() == true && LoadHeaderLines() == true)
                {
                    return true;
                }
                else
                    return false;

            }


            throw new NotImplementedException();

            //TODO: parse the receivedRequest using the \r\n delimeter   

            // check that there is atleast 3 lines: Request line, Host Header, Blank line (usually 4 lines with the last empty line for empty content)

            // Parse Request line

            // Validate blank line exists

            // Load header lines into HeaderLines dictionary
        }

        private bool ParseRequestLine()
        {
            string requestLine = requestLines[0];
            string[] requestLineSeparator = new string[] { " " };
            string[] Parts = requestLine.Split(requestLineSeparator, StringSplitOptions.None);
            this.method = RequestMethod.GET;
            if (Parts[0].Equals(this.method))
            {
                return true;

                relativeURI = Parts[1];

                if (ValidateIsURI(Parts[1]) == true)
                {
                    return true;

                    if (Parts[2] == "HTTP/1.0")
                    {
                        httpVersion = HTTPVersion.HTTP10;
                        return true;
                    }

                    else if (Parts[2] == "HTTP/1.1")
                    {
                        httpVersion = HTTPVersion.HTTP11;
                        return true;
                    }

                    else if ((Parts[2] == "HTTP/0.9"))
                    {
                        httpVersion = HTTPVersion.HTTP09;
                        return true;
                    }
                }

                else
                {
                    return false;
                }


            }

            else
            {
                return false;
            }


            throw new NotImplementedException();
        }

        private bool ValidateIsURI(string uri)
        {
            return Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute);
        }

        private bool LoadHeaderLines()
        {
            for (int i = 1; i <= 3; i++)
            {
                if (requestLines[i].Contains("HOST") || requestLines[i].Contains("Host"))
                {
                    string[] HostLineSeparator = new string[] { ":" };
                    string[] Host_contents = requestLines[i].Split(HostLineSeparator, StringSplitOptions.None);
                    relativeURI = Host_contents[1];
                    HeaderLines.Add(Host_contents[0], relativeURI);
                }
            }

            throw new NotImplementedException();
        }

        private bool ValidateBlankLine()
        {

            string[] BlankLineSeparator = new string[] { "\r\n" };
            string[] Request_lines = requestString.Split(BlankLineSeparator, StringSplitOptions.None);
            for (int i = 0; i <= Request_lines.Count(); i++)
            {
                if (Request_lines[i] == "")
                {
                    return true;
                }

            }
            throw new NotImplementedException();
        }

    }
}
