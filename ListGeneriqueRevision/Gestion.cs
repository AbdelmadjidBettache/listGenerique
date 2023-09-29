using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListGeneriqueRevision
{
    internal class Gestion
    {
        ObservableCollection<Article> articles;

        internal ObservableCollection<Article> Articles { get => articles;}

        public Gestion()
        {
            this.articles = new ObservableCollection<Article>();
        }

        public void AjouterArticle(string designation,double prix,double quantite,double taux)
        {
            Article article = new Article(designation,prix,quantite,taux);
            articles.Add(article);
        }

        public double GetHT()
        {
            double totalHt = 0.0;
            foreach (Article article in articles)
            {
                totalHt += article.MontantHT;
            }
            return totalHt;
        }
        public double GetTva()
        {
            double totalTva = 0.0;
            foreach (Article article in articles)
            {
                totalTva += article.MontantHT;
            }
            return totalTva;
        }
        public double GetTtc()
        {
            double totalTtc = 0.0;
            foreach (Article article in articles)
            {
                totalTtc += article.MontantHT;
            }
            return totalTtc;
        }

    }
}
