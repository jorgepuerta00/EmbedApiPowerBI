using System;
using EmbedPowerBI;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ClsEmbedPowerBI obj = null;
            obj = new ClsEmbedPowerBI(groupId: "ca7a0b50-9880-4748-b73e-347417a98117", reportId: "c6bf94f3-db14-4b56-8914-5a6ce0bcf201", datasetId: "27655a4a-fcfe-4edc-91ab-005656a6747f", accessLevel: "View");
            Console.WriteLine(obj.GetTokenAccess());
            /*obj = new ClsEmbedPowerBI(groupId: "47ae6da6-4c1a-4742-998e-bd05a6b385dd", reportId: "57c5b6b4-6bdb-4c0e-ac8b-ad23f887d9ce", datasetId: "17d9a289-a2a5-41bd-b64b-50dbf95272e8", accessLevel: "View");
            Console.WriteLine(obj.GetTokenAccess());
            obj = new ClsEmbedPowerBI(groupId: "47ae6da6-4c1a-4742-998e-bd05a6b385dd", reportId: "55abf618-e179-42fb-b2f5-ba76a0b400bb", datasetId: "6f56bb0e-f4a4-4068-8ac1-32a387ac9056", accessLevel: "View");
            Console.WriteLine(obj.GetTokenAccess());
            obj = new ClsEmbedPowerBI(groupId: "47ae6da6-4c1a-4742-998e-bd05a6b385dd", reportId: "84cbb013-08bd-4ae9-971e-fff20803a95d", datasetId: "6c02ff03-f6c0-44e4-bde0-c5da08da8d37", accessLevel: "View");
            Console.WriteLine(obj.GetTokenAccess());*/
            Console.ReadLine();
        }
    }
}