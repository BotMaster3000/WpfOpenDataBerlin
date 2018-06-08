using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOpenDataBerlin.Models
{
    public class BanishedBooksModel
    {
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string FirstEditionPublicationPlace { get; set; }
        public string FirstEditionPublicationYear { get; set; }
        public string FirstEditionPublisher { get; set; }
        public string Title { get; set; }
        public string AdditionalInfos { get; set; }
        public string SecondEditionPublisher { get; set; }
        public string SecondEditionPublicationPlace { get; set; }
        public string SecondEditionPublicationYear { get; set; }

        // DIE UNTEREN WERDEN NICHT ANGEZEIGT
        public string ID { get; set; }
        public string SsFlag { get; set; }
        public string Ocrresult { get; set; }
        public string PageNumberInocrDocument { get; set; }
    }
}
