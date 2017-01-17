using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag10.Opdracht.Test
{
    public class BinairytreeTestHelper
    {
        public static BinairyTree<string> CreateTreeWithNames()
        {
            BinairyTree<string> target = new Empty<string>();
            var tree = target.Add("Yael");
            tree.AddRange
            (
                new List<string>()
                {
                    "Rouke", "Wesley", "Simon", "Martin", "Jelle",
                    "Martijn", "Robert-Jan", "Rob", "Pim", "Vincent", "Wouter",
                    "Misha", "Steven", "Jeroen", "Max", "Menno", "Rory",
                    "Jan", "Jan-Paul", "Michiel", "Gert", "Lars", "Joery",
                }
            );
            return tree;
        }
    }
}
