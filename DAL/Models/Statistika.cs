using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Statistika
    {
        public Player player;
        public int goals;
        public int yellowCards;

        public override string ToString()
        {
            return $"{player.Name}";
        }
    }
}
