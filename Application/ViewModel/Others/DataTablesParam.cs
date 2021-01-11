using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ViewModel.Others
{
    public class DataTablesParam
    {
        public bool bEscapeRegex { get; set; }
        public List<bool> bEscapeRegexColumns { get; set; }
        public List<bool> bSearchable { get; set; }
        public List<bool> bSortable { get; set; }

        public int iColumns { get; set; }
        public int iDisplayLength { get; set; }
        public int iDisplayStart { get; set; }
        public List<int> iSortCol { get; set; }
        public int iSortingCols { get; set; }

        public List<string> sColumnNames { get; set; }
        public int sEcho { get; set; }
        public string sSearch { get; set; }
        public List<string> sSearchValues { get; set; }
        public List<string> sSortDir { get; set; }

        public string VM { get; set; }
        public bool IsReload { get; set; }

        public DataTablesParam()
        {
            bEscapeRegexColumns = new List<bool>();
            bSearchable = new List<bool>();
            sColumnNames = new List<string>();
            bSortable = new List<bool>();
            iSortCol = new List<int>();
            sSearchValues = new List<string>();
            sSortDir = new List<string>();
        }

        public DataTablesParam(int iColumns)
        {
            this.iColumns = iColumns;
            sColumnNames = new List<string>(iColumns);
            bSortable = new List<bool>(iColumns);
            bSearchable = new List<bool>(iColumns);
            sSearchValues = new List<string>(iColumns);
            iSortCol = new List<int>(iColumns);
            sSortDir = new List<string>(iColumns);
            bEscapeRegexColumns = new List<bool>(iColumns);
        }
    }
}
