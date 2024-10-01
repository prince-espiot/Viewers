using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_Viewer.Models
{
    public class YouTubeViewer
    {
        
        public Guid Id { get; }
        public string? Username { get; }

        public bool IsSubcribed { get; }

        public bool IsMember { get; }

        public YouTubeViewer(Guid id,string? username, bool isSubcribed, bool isMember)
        {
            Id = id;
            Username = username;
            IsSubcribed = isSubcribed;
            IsMember = isMember;
        }
    }
}
