﻿using Flurl.Http;
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
    public class GameServer
    {
        public static string address = "http://mamadgram.tk/guessIt.php";
        public static int numberOfUsers;
        public static int numberOfGames;
        public static int numberOfOnlineGames;
        public static int numberOfWords;

        public static double serverResponseTime;

        public static string time;
        
        public static List<Game> games;
        public static List<Word> words;
        public static List<User> users;

        public static async Task updateAsync()
        {

            SendAllUsersDatabaseResponse sendAllUsersDatabaseResponse = JsonConvert.DeserializeObject<SendAllUsersDatabaseResponse>(
                await GameServer.address.PostJsonAsync(
                new { action = "sendAllUsersDatabase", userID = Me.id }).ReceiveString());

            Console.WriteLine(sendAllUsersDatabaseResponse.ToString());
            if (sendAllUsersDatabaseResponse.dataIsRight == "yes")
            {
                GameServer.numberOfUsers = sendAllUsersDatabaseResponse.users.Count;
                GameServer.users = sendAllUsersDatabaseResponse.users;

            }



            SendAllGamesDatabaseResponse sendAllGamesDatabaseResponse = JsonConvert.DeserializeObject<SendAllGamesDatabaseResponse>(
                await GameServer.address.PostJsonAsync(
                new { action = "sendAllGamesDatabase", userID = Me.id }).ReceiveString());

            Console.WriteLine(sendAllGamesDatabaseResponse.ToString());
            if (sendAllGamesDatabaseResponse.dataIsRight == "yes")
            {
                GameServer.numberOfGames = sendAllGamesDatabaseResponse.games.Count;
                GameServer.games = sendAllGamesDatabaseResponse.games;

            }



            SendAllWordsDatabaseResponse sendAllWordsDatabaseResponse = JsonConvert.DeserializeObject<SendAllWordsDatabaseResponse>(
                await GameServer.address.PostJsonAsync(
                new { action = "sendAllWordsDatabase", userID = Me.id }).ReceiveString());

            Console.WriteLine(sendAllWordsDatabaseResponse.ToString());
            if (sendAllWordsDatabaseResponse.dataIsRight == "yes")
            {
                GameServer.numberOfWords = sendAllWordsDatabaseResponse.words.Count;
                GameServer.words = sendAllWordsDatabaseResponse.words;

            }


            
            UpdateServerDataResponse updateServerDataResponse = JsonConvert.DeserializeObject<UpdateServerDataResponse>(
                await GameServer.address.PostJsonAsync(
                new { action = "updateServerData", userID = Me.id }).ReceiveString());

            Console.WriteLine(updateServerDataResponse.numberOfUsers.ToString());
            if (updateServerDataResponse.dataIsRight == "yes")
            {
                ServerData.numberOfUsers = updateServerDataResponse.numberOfUsers;
                foreach (var v in updateServerDataResponse.numberOfUsers)
                {
                    Console.WriteLine(v.date + "    " + v.number);
                }
                Console.WriteLine("----------------------");
                foreach (var v in updateServerDataResponse.numberOfUsers)
                {
                    Console.WriteLine(v.date + "    " + v.number);
                }


            }




        }

        public static async Task<Boolean> serverResponseTimeUpdate()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            SendTimeResponse sendTimeResponse = JsonConvert.DeserializeObject<SendTimeResponse>(
                await GameServer.address.PostJsonAsync(
                new { action = "sendTime" }).ReceiveString());
            
            stopwatch.Stop();

            Console.WriteLine(sendTimeResponse.ToString());
            if (sendTimeResponse.dataIsRight == "yes")
            {
                serverResponseTime = ((double) stopwatch.ElapsedMilliseconds) / 1000;
                time = sendTimeResponse.responseData;
                Console.Out.WriteLine("Seerver Time : " + sendTimeResponse.responseData);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static async Task<Boolean> addNewWordToDatabase(Word word)
        {
            AddNewWordToDatabaseResponse addNewWordToDatabaseResponse = JsonConvert.DeserializeObject<AddNewWordToDatabaseResponse>(
                await GameServer.address.PostJsonAsync(
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
