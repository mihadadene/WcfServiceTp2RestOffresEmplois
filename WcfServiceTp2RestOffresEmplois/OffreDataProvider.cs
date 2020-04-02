using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServiceTp2RestOffresEmplois
{
    public class OffreDataProvider
    {
        private static List<OffreEmplois> liste = new List<OffreEmplois>();
        //cnx.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=myDB;Integrated Security=True; ";
        public static List<OffreEmplois> GetListOffresEmplois()
        {
            //List<OffreEmplois> liste = new List<OffreEmplois>();

            SqlConnection cnx = ConnectionDb.GetInstance();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            try
            {                                
                cmd.CommandText = "getListeOffresEmplois";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;
               // cnx.Open();

                dr= cmd.ExecuteReader();
                OffreEmplois oe;
                while (dr.Read())
                {
                    oe = new OffreEmplois ()
                    {
                        Num = int.Parse(dr["num"].ToString()),
                        Titre = dr["titre"].ToString(),
                        Description = dr["description"].ToString(),
                        Langages = ParserString(dr["langages"].ToString())
                    };

                    liste.Add(oe);
                }
                cmd.Dispose();
            }
            catch (SqlException e)
            {
                cnx.Close();
                Console.WriteLine(" erreur " + e);
                return null;
            }
            cnx.Close();
            return liste;
        }

        private static List <string> ParserString(string l)
        {
            return l.Split(',').ToList();
        }

        //public static List<OffreEmplois> FindAllOffresEmplois()
        //{

        //    return liste;
        //}

        public static OffreEmplois FindOffreByTitre(string Titre)
        {
            return liste.Find(x => x.Titre == Titre);

            //List<Product>.Enumerator it = liste.GetEnumerator();
            //while (it.MoveNext())
            //{
            //    if (it.Current.IdProd == IdProd)
            //    {
            //        return it.Current;
            //    }
            //}
            //return null;
        }

        public static int GetSize()
        {
            return liste.Count;
        }

        public static void AddOffreEmplois(OffreEmplois offreEmplois)
        {
            //int newIdProd = int.Parse(Guid.NewGuid().ToString());
            //product.IdProd = newIdProd;
            liste.Add(offreEmplois);
        }

    }
}