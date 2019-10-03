using System;
using EmbedPowerBI;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TokenEmbedPowerBI obj = new TokenEmbedPowerBI
            {
                GroupId = "38404938-a610-4add-834b-cb8230b73f6e",
                ReportId = "2b3c66bc-3081-458d-b35d-d1f41278d5f2",
                DatasetId = "9a304ede-f256-42b8-adf8-df469a7ca57f",
                AccessLevel = "View"
            };

            Token Token = obj.GetTokenAccess();

            Console.WriteLine(Token.EmbedUrl + " \n");
            Console.WriteLine("Expira en {0} minutos \n", Token.MinutesToExpiration);
            Console.WriteLine(Token.EmbedToken.Token);

            Console.ReadLine();
        }
    }
}