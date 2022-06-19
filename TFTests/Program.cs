using Camille.RiotGames;
using Camille.Enums;
using Camille.RiotGames.TftMatchV1;

Console.WriteLine("Testing TFT API");
Console.Write("Enter development API key: ");
var line = Console.ReadLine();
if (line is string ApiKey)
{
    var client = RiotGamesApi.NewInstance(ApiKey);
    var sumonner = client.TftSummonerV1().GetBySummonerName(PlatformRoute.EUW1, "the poro man");
    Console.WriteLine(sumonner.Name + "'s PUUID: " + sumonner.Puuid);

    Console.WriteLine("Attempting to access last game");
    string matchId = client.TftMatchV1().GetMatchIdsByPUUID(RegionalRoute.EUROPE, sumonner.Puuid, 1)[0];
    Match? match = await client.TftMatchV1().GetMatchAsync(RegionalRoute.EUROPE, matchId);

    foreach (Participant participant in match.Info.Participants) Console.WriteLine(client.TftSummonerV1().GetByPUUID(PlatformRoute.EUW1, participant.Puuid).Name);
}