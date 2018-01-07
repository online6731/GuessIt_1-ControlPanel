using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessIt
{
    public class Game
    {
        public int id;
        public string mode;
        public string type;
        public string playerOneID;
        public string playerTwoID;
        public string turn;
        public string status;
        public string scores;
        public string category;
        public string numberOfWords;
        public int playerOneTotalScore;
        public int playerTwoTotalScore;
        //public List<string> playerOneCategories; // bug : could not cast 0 to list
        //public List<string> playerTwoCategories; // bug : could not cast 0 to list
        //public List<int> playerOneTimes;
        //public List<int> playerTwoTimes;
        //public List<Word> playerOneWords;
        //public List<Word> playerTwoWords;
        public int playerOneRounds;
        public int playerTwoRounds;
        public int playerOneTotalTime;
        public int playerTwoTotalTime;
        public int playerOneLevel;
        public int playerTwoLevel;
        public string playerOneUsername;
        public string playerTwoUsername;
        public string playerOneStatus;
        public string playerTwoStatus;
        public string playerOneStatusTime;
        public string playerTwoStatusTime;
        

    }
}
