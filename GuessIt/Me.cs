using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessIt
{
    public class Me
    {
        public static string id;
        public static string firstName;
        public static string lastName;
        public static int totalScore;
        public static int position;
        public static string games;
        public static string role;
        public static string scores;


        public static async Task updateAsync()
        {
            SendUserInformationResponse sendUserInformationResponse = JsonConvert.DeserializeObject<SendUserInformationResponse>(
                await GameServer.address.PostJsonAsync(
                new { action = "sendUserInformation", userID = Me.id }).ReceiveString());

            Console.WriteLine(sendUserInformationResponse);
            if (sendUserInformationResponse.dataIsRight == "yes")
            {
                Me.firstName = sendUserInformationResponse.user.firstName;
                Me.lastName = sendUserInformationResponse.user.lastName;
                Me.position = sendUserInformationResponse.user.position;
                Me.role = sendUserInformationResponse.user.role;
                Me.totalScore = sendUserInformationResponse.user.totalScore;
                Me.scores = sendUserInformationResponse.user.scores;
                Me.games = sendUserInformationResponse.user.games;
            }

        }

    }
}
