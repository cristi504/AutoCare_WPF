using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocare_WPF.domain.documents
{
    internal class RetrievedDocument
    {
            public RetrievedDocument()
            {

            }
            public RetrievedDocument(int documentID, string Type, string Series, DateTime IssueDate, DateTime ExpiryDate)
            {
                this.documentID = documentID;
                this.Type = Type;
                this.Series = Series;
                this.IssueDate = IssueDate;
                this.ExpiryDate = ExpiryDate;

            }
            public int documentID { get; set; }
            public string Type { get; set; }
            public string Series { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ExpiryDate { get; set; }
            public byte[] Photo { get; set; }
    }
    
}
