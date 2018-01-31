using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GuessIt
{
    public class GameServer
    {
        public const string address = "http://mamadgram.tk/guessIt.php";
        public int numberOfUsers { get; set; }
        public int numberOfGames { get; set; }
        public int numberOfOnlineGames { get; set; }
        public int numberOfWords { get; set; }

        public double serverResponseTime { get; set; }

        public string time { get; set; }

        public List<Game> games { get; set; }
        public List<Word> words { get; set; }
        public List<User> users { get; set; }


        public TextBlock statusBarTextBlock { get; set; }

        public async Task<bool> updateUserDatabase()
        {
            statusBarTextBlock.Text = "... در حال دریافت دیتابیس کاربران";
            SendAllUsersDatabaseResponse sendAllUsersDatabaseResponse = JsonConvert.DeserializeObject<SendAllUsersDatabaseResponse>(
                await GameServer.address.PostJsonAsync(
                new { action = "sendAllUsersDatabase", userID = Me.id }).ReceiveString());

            Console.WriteLine(sendAllUsersDatabaseResponse.ToString());
            if (sendAllUsersDatabaseResponse.dataIsRight == "yes")
            {
                numberOfUsers = sendAllUsersDatabaseResponse.users.Count;
                users = sendAllUsersDatabaseResponse.users;

                statusBarTextBlock.Text = "دیتابیس کاربران با موفقیت دریافت شد";
                return true;
            }
            else
            {
                statusBarTextBlock.Text = "دربافت دیتابیس کاربران با مشکل مواجه شد";
                return false;
            }
        }

        public async Task<bool> updateGameDatabase()
        {
            statusBarTextBlock.Text = "... در حال دریافت دیتابیس بازی ها";
            SendAllGamesDatabaseResponse sendAllGamesDatabaseResponse = JsonConvert.DeserializeObject<SendAllGamesDatabaseResponse>(
                await GameServer.address.PostJsonAsync(
                new { action = "sendAllGamesDatabase", userID = Me.id }).ReceiveString());

            Console.WriteLine(sendAllGamesDatabaseResponse.ToString());
            if (sendAllGamesDatabaseResponse.dataIsRight == "yes")
            {
                numberOfGames = sendAllGamesDatabaseResponse.games.Count;
                games = sendAllGamesDatabaseResponse.games;
                statusBarTextBlock.Text = "دیتابیس بازی ها با موفقیت دریافت شد";
                return true;
            }
            else
            {
                statusBarTextBlock.Text = "دربافت دیتابیس بازی ها با مشکل مواجه شد";
                return false;
            }
        }

        public async Task<bool> updateWordDatabase()
        {
            statusBarTextBlock.Text = "... در حال دریافت دیتابیس کلمات";
            SendAllWordsDatabaseResponse sendAllWordsDatabaseResponse = JsonConvert.DeserializeObject<SendAllWordsDatabaseResponse>(
                await GameServer.address.PostJsonAsync(
                new { action = "sendAllWordsDatabase", userID = Me.id }).ReceiveString());

            Console.WriteLine(sendAllWordsDatabaseResponse.ToString());
            if (sendAllWordsDatabaseResponse.dataIsRight == "yes")
            {
                numberOfWords = sendAllWordsDatabaseResponse.words.Count;
                words = sendAllWordsDatabaseResponse.words;
                statusBarTextBlock.Text = "دیتابیس کلمات با موفقیت دریافت شد";
                return true;
            }
            else
            {
                statusBarTextBlock.Text = "دربافت دیتابیس کلمات با مشکل مواجه شد";
                return false;
            }
        }

        public async Task<bool> updateServerDataDatabase()
        {
            statusBarTextBlock.Text = "... در حال دریافت دیتابیس اطلاعات سرور";
            UpdateServerDataResponse updateServerDataResponse = JsonConvert.DeserializeObject<UpdateServerDataResponse>(
                await GameServer.address.PostJsonAsync(
                new { action = "updateServerData", userID = Me.id }).ReceiveString());

            Console.WriteLine(updateServerDataResponse.numberOfUsers.ToString());
            if (updateServerDataResponse.dataIsRight == "yes")
            {
                ServerData.numberOfUsers = updateServerDataResponse.numberOfUsers;

                statusBarTextBlock.Text = "دیتابیس اطلاعات سرور با موفقیت دریافت شد";
                return true;
            }
            else
            {
                statusBarTextBlock.Text = "دربافت دیتابیس اطلاعات سروز با مشکل مواجه شد";
                return false;
            }
        }

        public async Task updateAsync()
        {
            await updateUserDatabase();
            await updateWordDatabase();
            await updateGameDatabase();
            await updateServerDataDatabase();

        }

        public async Task<Boolean> serverResponseTimeUpdate()
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                SendTimeResponse sendTimeResponse = JsonConvert.DeserializeObject<SendTimeResponse>(
                    await GameServer.address.PostJsonAsync(
                    new { action = "sendTime" }).ReceiveString());

                stopwatch.Stop();

                Console.WriteLine(sendTimeResponse.ToString());
                if (sendTimeResponse.dataIsRight == "yes")
                {
                    serverResponseTime = ((double)stopwatch.ElapsedMilliseconds) / 1000;
                    time = sendTimeResponse.responseData;
                    Console.Out.WriteLine("Seerver Time : " + sendTimeResponse.responseData);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public async Task<Boolean> addNewWordToDatabase(Word word)
        {
            try
            {
                statusBarTextBlock.Text = "... درحال افزودن کلمه جدید";
                AddNewWordToDatabaseResponse addNewWordToDatabaseResponse = JsonConvert.DeserializeObject<AddNewWordToDatabaseResponse>(
                    await GameServer.address.PostJsonAsync(
                    new { action = "addWord", userID = Me.id, word = JsonConvert.SerializeObject(word) }).ReceiveString());

                Console.WriteLine(addNewWordToDatabaseResponse.ToString());
                if (addNewWordToDatabaseResponse.dataIsRight == "yes")
                {
                    statusBarTextBlock.Text = "کلمه جدید با موفقیت اضافه شد";
                    return true;
                }
                else
                {
                    statusBarTextBlock.Text = "افزودن کلمه با مشکل مواجه شد";
                    return false;
                }

            } catch (Exception e)
            {
                return false;
            }
            
        }

        public async Task<Boolean> checkInternetConnection()
        {
            if (!await serverResponseTimeUpdate())
            {
                // we cant connect to server, probably there is a problem with your internet connection
                //await Task.Delay(1000);
                //checkInternetConnection();
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
