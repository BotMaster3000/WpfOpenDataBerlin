using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WpfOpenDataBerlin.Models;

namespace WpfOpenDataBerlin.ViewModels
{
    public class BanishedBooksViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<BanishedBooksModel> BookCollection = new ObservableCollection<BanishedBooksModel>();

        public BanishedBooksViewModel(string search)
        {
            InitializeBookArray(search);
        }

        private void InitializeBookArray(string search)
        {
            // REFERENZ-LINK daten.berlin.de:
            // https://daten.berlin.de/datensaetze/liste-der-verbannten-b%C3%BCcher-0
            // bzw. LINK zur Ressource
            // http://www.berlin.de/berlin-im-ueberblick/geschichte/berlin-im-nationalsozialismus/verbannte-buecher/suche/index.php/index/all.json?q=

            const string BURNED_BOOKS_RESOURCE_LINK = "http://www.berlin.de/berlin-im-ueberblick/geschichte/berlin-im-nationalsozialismus/verbannte-buecher/suche/index.php/index/all.json?q=";

            string jsonString = "";

            using (WebClient client = new WebClient())
            {
                jsonString = client.DownloadString(BURNED_BOOKS_RESOURCE_LINK);
            }

            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonString);
                if (jsonObject.index?.Count > 0)
                {
                    ObservableCollection<BanishedBooksModel> books = new ObservableCollection<BanishedBooksModel>();

                    dynamic bookArray = jsonObject.index;
                    foreach (dynamic book in bookArray)
                    {
                        
                        BanishedBooksModel currentBookToAdd = new BanishedBooksModel()
                        {
                            ID = book["id"],
                            AuthorFirstName = book["authorfirstname"],
                            AuthorLastName = book["authorlastname"],
                            FirstEditionPublicationPlace = book["firsteditionpublicationplace"],
                            FirstEditionPublicationYear = book["firsteditionpublicationyear"],
                            FirstEditionPublisher = book["firsteditionpublisher"],
                            Ocrresult = book["ocrresult"],
                            Title = book["title"],
                            SsFlag = book["ssflag"],
                            AdditionalInfos = book["additionalinfos"],

                            PageNumberInocrDocument = book["pagenumberinocrdocument"],
                            SecondEditionPublisher = book["secondeditionpublisher"],
                            SecondEditionPublicationPlace = book["secondeditionpublicationplace"],
                            SecondEditionPublicationYear = book["secondeditionpublicationyear"],
                        };

                        if (currentBookToAdd.AdditionalInfos != null && currentBookToAdd.AdditionalInfos != "")
                        {
                            

                                string x = currentBookToAdd.AdditionalInfos;
                            
                        }
                        if (search != "")
                        {
                            if (currentBookToAdd.Ocrresult.IndexOf(search) == -1)
                            {
                                continue;
                            }
                            else
                            {
                                books.Add(currentBookToAdd);
                            }
                        }
                        else
                        {
                            books.Add(currentBookToAdd);
                        }
                    }

                    BookCollection = books;
                }
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
