using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessIt
{
    public class Game
    {
        public int id { get; set; }
        public string mode { get; set; }
        public string type { get; set; }
        public string playerOneID { get; set; }
        public string playerTwoID { get; set; }
        public string turn { get; set; }
        public string status { get; set; }
        public string scores { get; set; }
        public string category { get; set; }
        public string numberOfWords { get; set; }
        public int playerOneTotalScore { get; set; }
        public int playerTwoTotalScore { get; set; }
        //public List<string> playerOneCategories { get; set; } // bug : could not cast 0 to list
        //public List<string> playerTwoCategories { get; set; } // bug : could not cast 0 to list
        //public List<int> playerOneTimes { get; set; }
        //public List<int> playerTwoTimes { get; set; }
        //public List<Word> playerOneWords { get; set; }
        //public List<Word> playerTwoWords { get; set; }
        public int playerOneRounds { get; set; }
        public int playerTwoRounds { get; set; }
        public int playerOneTotalTime { get; set; }
        public int playerTwoTotalTime { get; set; }
        public int playerOneLevel { get; set; }
        public int playerTwoLevel { get; set; }
        public string playerOneUsername { get; set; }
        public string playerTwoUsername { get; set; }
        public string playerOneStatus { get; set; }
        public string playerTwoStatus { get; set; }
        public string playerOneStatusTime { get; set; }
        public string playerTwoStatusTime { get; set; }
        

    }
}
