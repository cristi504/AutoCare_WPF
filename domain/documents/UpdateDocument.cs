using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocare_WPF.domain.documents
{
    internal class UpdateDocument
    {
        public UpdateDocument(string documentType,string series,DateTime? issueDate,DateTime? expiryDate,int documentId)
        {
            this.documentType = documentType;
            this.series = series;
            this.issueDate = issueDate;
            this.expiryDate = expiryDate;
            this.documentId = documentId;

        }
        public string documentType { get; internal set; }
        public string series { get; internal set; }
        public DateTime? issueDate { get; internal set; }
        public DateTime? expiryDate { get; internal set; }
        public int documentId { get; internal set; }
           
    }
}
