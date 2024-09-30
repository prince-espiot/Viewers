using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_Viewer.Models
{
    public class YouTubeViewer
    {
        

        public string? Username { get; }

        public bool IsSubcribed { get; }

        public bool IsMember { get; }

        public YouTubeViewer(string? username, bool isSubcribed, bool isMember)
        {
            Username = username;
            IsSubcribed = isSubcribed;
            IsMember = isMember;
        }
    }
}
