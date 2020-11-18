using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace br.com.teczilla.datasus.services
{
    public class RepositoryFilter
    {
        public string[] Prefixes { get; set; }

        public string[] UFs { get; set; }

        public int[] Months { get; set; }

        public int[] GetYears()
        {
            if (MinYear == null || MaxYear == null)
                return null;
            List<int> years = new List<int>();
            for (int i = MinYear.Value; i <= MaxYear.Value; i++)
                years.Add(i);
            return years.ToArray();
        }

        public int? MinYear { get; set; }

        public int? MaxYear { get; set; }

        public string[] Unmatched { get; set; }

        public FilteredItem[] FilteredItems { get; set; }
       
    }

    public class FilteredItem
    {
        public string Name { get; set; }

        public Match Match { get; set; }

        public FilteredItem(string name, Match match)
        {
            Name = name;
            Match = match;
        }
    }
}
