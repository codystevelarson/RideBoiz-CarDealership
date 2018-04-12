using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Data;
using System.Data.SqlClient;

namespace GuildCars.Data.ADO
{
    public class ContactRepositoryADO : IContactRepository
    {
        public Contact Add(Contact contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("AddContact", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

            
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@VIN", contact.VIN);
                cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contact.FirstName);
                if(!string.IsNullOrEmpty(contact.Email))
                {
                    cmd.Parameters.AddWithValue("@Email", contact.Email);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", null);
                }
                if (!string.IsNullOrEmpty(contact.Phone))
                {
                    cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", null);
                }

                cmd.Parameters.AddWithValue("@Message", contact.Message);


                cn.Open();
                cmd.ExecuteNonQuery();

                contact.ContactId = (int)param.Value;

            }
            return contact;
        }
    }
}
