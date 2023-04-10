using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Gacha_Simulate
{
    internal class Gacha
    {
        private dynamic item = new List<dynamic>();
        private Dictionary<string,double> name_rarity = new Dictionary<string, double>();
        private Dictionary<double,List<string>> rarityMap = new Dictionary<double, List<string>>();
        public Gacha()
        {         
        }
        public void takedata(dynamic dataop)
        {
            item = dataop;
        }
        public  void SetRarity()
        {
            //Generic Simulation just to test the waters
            //For Information: No Pity and Acces to all operators that can be headhunted
            //Currently using Console, will convert it to be used in WPF      
            foreach (var characterlist1 in item)
            {
                if (characterlist1.Value.itemObtainApproach == "Recruitment & Headhunting" && characterlist1.Value.rarity >= 2)
                {
                    string name = characterlist1.Value.phases[0].characterPrefabKey;
                    double rarity = 0;
                    if (characterlist1.Value.rarity == 5)
                    {
                        rarity = 0.02;
                    }
                    else if (characterlist1.Value.rarity == 4)
                    {
                        rarity = 0.08;
                    }
                    else if (characterlist1.Value.rarity == 3)
                    {
                        rarity = 0.50;
                    }
                    if (characterlist1.Value.rarity == 2)
                    {
                        rarity = 0.40;
                    }
                    name_rarity.Add(name, rarity);
                }
            }
            // Create a dictionary to store the rarity and probability for each character
            //var characters = new Dictionary<string, double>()
            //{
            //    { "Skadi", 0.02 },
            //    { "Surtr", 0.02 },
            //    { "Specter", 0.08 },
            //    { "Texas", 0.08 },
            //    { "CliffHeart", 0.08 },
            //    { "Elysium", 0.08 },
            //    { "Lappland", 0.08 },
            //    { "Franka", 0.08 },
            //    { "Jaye", 0.50 },
            //    { "Ambriel", 0.50 },
            //    { "Melantha", 0.40 },
            //    { "Orchid", 0.40 }
            //};
            foreach (var character in name_rarity)
            {
                if (!rarityMap.ContainsKey(character.Value))
                {
                    rarityMap[character.Value] = new List<string>();
                }

                rarityMap[character.Value].Add(character.Key);
            }                        
        }
        public List<string> Generic_Simulate()
        {
            List<string> TenPull = new List<string>();
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var randomNumber = random.NextDouble();
                var cumulativeProbability = 0.0;
                foreach (var rarity in rarityMap.Keys)
                {
                    cumulativeProbability += rarity;
                    if (randomNumber < cumulativeProbability)
                    {
                        List<string> characterList = rarityMap[rarity];

                        var index = random.Next(characterList.Count);
                        TenPull.Add(characterList[index]);
                        break;
                    }
                }
            }
            return TenPull;
        }

    }
}
