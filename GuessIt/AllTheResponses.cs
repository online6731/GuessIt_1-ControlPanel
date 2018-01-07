using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessIt
{
    class AllTheResponses
    {
    }
    class SendAllUsersDatabaseResponse
    {
        public string dataIsRight;
        public string responseData;
        public List<User> users;
    }

    class SendAllGamesDatabaseResponse
    {
        public string dataIsRight;
        public string responseData;
        public List<Game> games;
    }

    class SendAllWordsDatabaseResponse
    {
        public string dataIsRight;
        public string responseData;
        public List<Word> words;
    }

    class SendAllOnlineGamesDatabaseResponse
    {
        public string dataIsRight;
        public string responseData;
        public List<Word> onlineGames;
    }

    class SendTimeResponse
    {
        public string dataIsRight;
        public string responseData;
    }
}
