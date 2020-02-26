using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetRetard.DAL
{
    public static class BilletDAL
    {
        public static void insertBilletRetard(string motifParam, string justificatifParam, DateTime dateHeureParam, int scoreParam, int utilisateur_IDParam)
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ProjetRetardBDD"].ConnectionString))
            {
                String query = "INSERT INTO BilletRetard (Motif,Justificatif,dateHeure,Score,Utilisateur_ID) VALUES (@Motif,@Justificatif,@dateHeure,@Score,@Utilisateur_ID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Motif", motifParam);
                    command.Parameters.AddWithValue("@Justificatif", justificatifParam);
                    command.Parameters.AddWithValue("@dateHeure", dateHeureParam);
                    command.Parameters.AddWithValue("@Score", scoreParam);
                    command.Parameters.AddWithValue("@Utilisateur_ID", utilisateur_IDParam);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}