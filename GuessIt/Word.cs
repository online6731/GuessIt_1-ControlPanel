using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessIt
{
    public class Word
    {
        public int id { get; set; }
        public string word { get; set; }
        public string incompleteWord { get; set; }
        public string category { get; set; }
        public int score { get; set; }
        public int time { get; set; }
        public int level { get; set; }
        public string editorsUsername { get; set; }
        public string date { get; set; }
    }
}
