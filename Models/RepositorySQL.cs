using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RepositorySQL
    {
        #region Propertys
        private string _connectionString;
        public SqlConnection conn { get; }
        #endregion
        public RepositorySQL()
        {
            _connectionString = Encrypted();
            this.conn = new SqlConnection(_connectionString);
        }
        private string Encrypted()
        {
            TextReader reed = new StreamReader(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Encrypted.txt"));
            return Security.DescEncriptar( reed.ReadToEnd());
        }
    }
    #region Security Encryptation
    public static class Security
    {
        public static string Encriptar(this string encrip)
        {
            string rs = string.Empty;
            byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(encrip);
            rs = Convert.ToBase64String(encrypted);
            return rs;
        }
        public static string DescEncriptar(this string encrip)
        {
            string rs = string.Empty;
            byte[] decryted = Convert.FromBase64String(encrip);
            rs = System.Text.Encoding.Unicode.GetString(decryted);
            return rs;
        }
    }
    #endregion
}
