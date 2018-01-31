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
    class CommonResponse
    {
        public string dataIsRight { get; set; }
        public string responseData { get; set; }
    }

    class SendAllUsersDatabaseResponse
    {
        public string dataIsRight { get; set; }
        public string responseData { get; set; }
        public List<User> users { get; set; }
    }

    class SendAllGamesDatabaseResponse
    {
        public string dataIsRight { get; set; }
        public string responseData { get; set; }
        public List<Game> games { get; set; }
    }

    class SendAllWordsDatabaseResponse
    {
        public string dataIsRight { get; set; }
        public string responseData { get; set; }
        public List<Word> words { get; set; }
    }

    class SendAllOnlineGamesDatabaseResponse
    {
        public string dataIsRight { get; set; }
        public string responseData { get; set; }
        public List<Word> onlineGames { get; set; }
    }

    class SendTimeResponse
    {
        public string dataIsRight { get; set; }
        public string responseData { get; set; }
    }

    class AddNewWordToDatabaseResponse
    {
        public string dataIsRight { get; set; }
        public string responseData { get; set; }
    }

    class SendUserInformationResponse
    {
        public string dataIsRight { get; set; }
        public string responseData { get; set; }
        public User user { get; set; }
    }

    class LoginResponse
    {
        public string dataIsRight { get; set; }
        public string responseData { get; set; }
        public User user { get; set; }
    }

    class UpdateServerDataResponse
    {
        public string dataIsRight { get; set; }
        public string responseData { get; set; }
        public List<DateNumberObject> numberOfUsers { get; set; }
    }

    class DateNumberObject
    {
        public string date { get; set; }
        public int number { get; set; }
    }
}
