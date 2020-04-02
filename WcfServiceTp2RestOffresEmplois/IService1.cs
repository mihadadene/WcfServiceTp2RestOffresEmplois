using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceTp2RestOffresEmplois
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                    UriTemplate = "/offres/{Titre}",
                    //BodyStyle = WebMessageBodyStyle.Wrapped,
                    RequestFormat = WebMessageFormat.Json,
                    //ResponseFormat = WebMessageFormat.Xml
                    ResponseFormat = WebMessageFormat.Json)]
        OffreEmplois GetOffreEmplois(string Titre);

        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    //BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "/offres")]
        List<OffreEmplois> GetAllOffresEmplois();

        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    //BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "/offres/count")]
        int Count();
        // TODO: ajoutez vos opérations de service ici
        [OperationContract]
        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    // BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "/offres")]
        void AddOffreEmplois(OffreEmplois offreEmplois);

    }
}