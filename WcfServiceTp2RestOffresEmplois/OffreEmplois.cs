using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServiceTp2RestOffresEmplois
{
    [DataContract]
    public class OffreEmplois
    {
        [DataMember]
        public int Num { get; set; }
        [DataMember]
        public string Titre { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public List<string> Langages { get; set; }
  
        public bool addLangage(string langage)
        {
            if (Langages.Contains(langage.ToUpper())) 
            {
                return false;
            }
            Langages.Add(langage.ToUpper());

            return true;
        }

        public OffreEmplois()
        {

        }
        //public OffreEmplois(int Num, string Titre, string Description, string Language)
        //{
        //    this.Num = Num;
        //    this.Titre = Titre;
        //    this.Description = Description;
        //    //this.Langages = Langages;
        //}
    }
}