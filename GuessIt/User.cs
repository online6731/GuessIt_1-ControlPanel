using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessIt
{
    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string name { get; set; }
        public string games { get; set; }
        public string profilePicture { get; set; }
        public string scores { get; set; }
        public int totalScore { get; set; }
        public int position { get; set; }
        public string role { get; set; }
    }
}
