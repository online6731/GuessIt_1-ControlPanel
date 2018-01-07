using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessIt
{
    public class GameInformation
    {
        public static int numberOfUsers;
        public static int numberOfGames;
        public static int numberOfOnlineGames;
        public static int numberOfWords;

        public static double serverResponseTime;

        public static List<Game> games;
        public static List<Word> words;
        public static List<User> users;


        public static async Task updateAsync()
        {
            
            SendAllUsersDatabaseResponse sendAllUsersDatabaseResponse = JsonConvert.DeserializeObject<SendAllUsersDatabaseResponse>(
                await "http://mamadgram.tk/guessIt.php".PostJsonAsync(
                new { action = "sendAllUsersDatabase", userID = Me.id }).ReceiveString());

            if (sendAllUsersDatabaseResponse.dataIsRight == "yes")
            {
                GameInformation.numberOfUsers = sendAllUsersDatabaseResponse.users.Count;
                GameInformation.users = sendAllUsersDatabaseResponse.users;

            }



            SendAllGamesDatabaseResponse sendAllGamesDatabaseResponse = JsonConvert.DeserializeObject<SendAllGamesDatabaseResponse>(
                            await "http://mamadgram.tk/guessIt.php".PostJsonAsync(
                            new { action = "sendAllGamesDatabase", userID = Me.id }).ReceiveString());

            if (sendAllGamesDatabaseResponse.dataIsRight == "yes")
            {
                GameInformation.numberOfGames = sendAllGamesDatabaseResponse.games.Count;
                GameInformation.games = sendAllGamesDatabaseResponse.games;

            }



            SendAllWordsDatabaseResponse sendAllWordsDatabaseResponse = JsonConvert.DeserializeObject<SendAllWordsDatabaseResponse>(
                            await "http://mamadgram.tk/guessIt.php".PostJsonAsync(
                            new { action = "sendAllWordsDatabase", userID = Me.id }).ReceiveString());

            if (sendAllWordsDatabaseResponse.dataIsRight == "yes")
            {
                GameInformation.numberOfWords = sendAllWordsDatabaseResponse.words.Count;
                GameInformation.words = sendAllWordsDatabaseResponse.words;

            }



        }

        public static async Task serverResponseTimeUpdate()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            SendTimeResponse sendTimeResponse = JsonConvert.DeserializeObject<SendTimeResponse>(
                await "http://mamadgram.tk/guessIt.php".PostJsonAsync(
                new { action = "sendTime" }).ReceiveString());
            
            stopwatch.Stop();

            if (sendTimeResponse.dataIsRight == "yes")
            {
                serverResponseTime = ((double) stopwatch.ElapsedMilliseconds) / 1000;
                Console.Out.WriteLine("Seerver Time : " + sendTimeResponse.responseData);
            }
            
        }


    }

    

}
