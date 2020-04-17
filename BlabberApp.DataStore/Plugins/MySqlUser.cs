using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore.Plugins
{
    public class MySqlUser : IUserPlugin
    {
        MySqlConnection _dcUser;
        public MySqlUser()
        {
            _dcUser = new MySqlConnection("server=142.93.114.73;database=ccaldwell;user=c-caldwell;password=letmein");
            
            _dcUser.Open();
        
        }
        public void Create(IEntity obj)
        {
            User user = (User)obj;
            DateTime now = DateTime.Now;
            string sql = "INSERT INTO users (sys_id, email, dttm_registration, dttm_last_login) VALUES ('"
                    + user.Id + "', '"
                    + user.Email + "', '"
                    + now.ToString("yyyy-MM-dd HH:mm:ss")
                    + "', '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            MySqlCommand cmd = new MySqlCommand(sql, _dcUser);
            cmd.ExecuteNonQuery();
        }

        public IEnumerable ReadAll()
        {
            string sql = "SELECT * FROM users";
            MySqlDataAdapter daUser = new MySqlDataAdapter(sql, _dcUser); // To avoid SQL injection.
            MySqlCommandBuilder cbUser = new MySqlCommandBuilder(daUser);
            DataSet dsUsers = new DataSet();

            daUser.Fill(dsUsers, "users");

            ArrayList users = new ArrayList();

            foreach (DataRow row in dsUsers.Tables[0].Rows)
            {
                users.Add(DataRow2User(row));
            }

            return users;
        }

        public IEntity ReadById(Guid Id)
        {
            string sql = "SELECT * FROM users WHERE users.sys_id = '" + Id.ToString() + "'";
            MySqlDataAdapter daUser = new MySqlDataAdapter(sql, _dcUser); // To avoid SQL injection.
            MySqlCommandBuilder cbUser = new MySqlCommandBuilder(daUser);
            DataSet dsUser = new DataSet();

            daUser.Fill(dsUser, "users");
            if(dsUser.Tables[0].Rows.Count > 0){
                DataRow row = dsUser.Tables[0].Rows[0];
                return DataRow2User(row);
            }else{
                return null;
            }
        }
        public IEntity ReadByUserEmail(string Id)
        {
            string sql = "SELECT * FROM users WHERE users.email = '" + Id.ToString() + "'";
            MySqlDataAdapter daUser = new MySqlDataAdapter(sql, _dcUser); // To avoid SQL injection.
            MySqlCommandBuilder cbUser = new MySqlCommandBuilder(daUser);
            DataSet dsUser = new DataSet();

            daUser.Fill(dsUser, "users");
            if(dsUser.Tables[0].Rows.Count > 0){
                DataRow row = dsUser.Tables[0].Rows[0];
                
                return DataRow2User(row);
            }else{
                return null;
            }
        }

        public void Update(IEntity obj)
        {
            User user = (User)obj;
            this.Delete(user);
            this.Create(user);
        }

        public void Delete(IEntity obj)
        {
            User user = (User)obj;
            string sql = "DELETE FROM ccaldwell.users WHERE users.sys_id='"+user.Id+"'";
            MySqlCommand cmd = new MySqlCommand(sql, _dcUser);
            cmd.ExecuteNonQuery();
        }

         public void DeleteAll(string email)
        {
            string sql = "DELETE FROM ccaldwell.users WHERE users.email='"+email+"'";
            MySqlCommand cmd = new MySqlCommand(sql, _dcUser);
            cmd.ExecuteNonQuery();
        }

        private User DataRow2User(DataRow row)
        {
            User user = new User();

            user.Id = new Guid(row["sys_id"].ToString());
            user.ChangeEmail(row["email"].ToString());
            user.RegisterDTTM = (DateTime)row["dttm_registration"];
            user.LastLoginDTTM = (DateTime)row["dttm_last_login"];

            return user;
        }
    }
}