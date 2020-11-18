using br.com.teczilla.datasus.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.teczilla.datasus.view.controls
{
    public class FileFilterParameters
    {

        private br.com.teczilla.datasus.services.RepositoryFilter _filter;

        public FileFilterParameters() {
            _filter = new RepositoryFilter();
        }

        public FileFilterParameters(RepositoryFilter filter)
        {
            _filter = filter;
        }

        public string[] Term
        {
            get => _filter.Prefixes;
            set => _filter.Prefixes = value;
        }

        public string[] UFs
        {
            get => _filter.UFs;
            set => _filter.UFs = value;
        }

        public int? MinYear
        {
            get => _filter.MinYear;
            set => _filter.MinYear = value;
        }

        public int? MaxYear
        {
            get => _filter.MaxYear;
            set => _filter.MaxYear = value;
        }

        public int[] Months
        {
            get => _filter.Months;
            set => _filter.Months = value;
        }

        public br.com.teczilla.datasus.services.RepositoryFilter ToRepositoryFilter()
        {
            return _filter;
        }
    }
}
