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
                await ServerInformation.address.PostJsonAsync(
                new { action = "sendAllUsersDatabase", userID = Me.id }).ReceiveString());

            Console.WriteLine(sendAllUsersDatabaseResponse.ToString());
            if (sendAllUsersDatabaseResponse.dataIsRight == "yes")
            {
                GameInformation.numberOfUsers = sendAllUsersDatabaseResponse.users.Count;
                GameInformation.users = sendAllUsersDatabaseResponse.users;

            }



            SendAllGamesDatabaseResponse sendAllGamesDatabaseResponse = JsonConvert.DeserializeObject<SendAllGamesDatabaseResponse>(
                await ServerInformation.address.PostJsonAsync(
                new { action = "sendAllGamesDatabase", userID = Me.id }).ReceiveString());

            Console.WriteLine(sendAllGamesDatabaseResponse.ToString());
            if (sendAllGamesDatabaseResponse.dataIsRight == "yes")
            {
                GameInformation.numberOfGames = sendAllGamesDatabaseResponse.games.Count;
                GameInformation.games = sendAllGamesDatabaseResponse.games;

            }



            SendAllWordsDatabaseResponse sendAllWordsDatabaseResponse = JsonConvert.DeserializeObject<SendAllWordsDatabaseResponse>(
                await ServerInformation.address.PostJsonAsync(
                new { action = "sendAllWordsDatabase", userID = Me.id }).ReceiveString());

            Console.WriteLine(sendAllWordsDatabaseResponse.ToString());
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
                await ServerInformation.address.PostJsonAsync(
                new { action = "sendTime" }).ReceiveString());
            
            stopwatch.Stop();

            Console.WriteLine(sendTimeResponse.ToString());
            if (sendTimeResponse.dataIsRight == "yes")
            {
                serverResponseTime = ((double) stopwatch.ElapsedMilliseconds) / 1000;
                Console.Out.WriteLine("Seerver Time : " + sendTimeResponse.responseData);
            }
            
        }

        public static async Task<Boolean> addNewWordToDatabase(Word word)
        {
            AddNewWordToDatabaseResponse addNewWordToDatabaseResponse = JsonConvert.DeserializeObject<AddNewWordToDatabaseResponse>(
                await ServerInformation.address.PostJsonAsync(
                new { action = "addWord", userID = Me.id, word = JsonConvert.SerializeObject(word) }).ReceiveString());

            Console.WriteLine(addNewWordToDatabaseResponse.ToString());
            if (addNewWordToDatabaseResponse.dataIsRight == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
