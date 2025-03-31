using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocare_WPF.domain.documents
{
    internal class StoreDocument
    {

        public StoreDocument(int userId, string documentType, string series, DateTime issueDate, DateTime expiryDate)
        {
            this.userId = userId;
            this.documentType = documentType;
            this.series = series;
            this.issueDate = issueDate;
            this.expiryDate = expiryDate;
        }

        public int userId { get; set; }
        public string documentType { get; set; }

        public string series { get; set; }

        public DateTime issueDate { get; set; }

        public DateTime expiryDate { get; set; }

       

    }
}
