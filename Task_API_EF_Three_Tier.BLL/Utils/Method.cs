using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Task_API_EF_Three_Tier.DAL.Entities;

namespace Task_API_EF_Three_Tier.BLL.Utils
{
    internal static class Method
    {
        internal static string EncodePassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        internal static string EncodePassword(this PersonEntity person) {
        
            person.Password = EncodePassword(person.Password);
            return person.Password;
        
        }

        internal static bool VerifyExtension(string fileName)
        {
            string extension = fileName.Substring(fileName.Length - 3);
            bool isAuthorized = false;
            string[] authorizedExtensions = new string[] { "jpg", "png" };

            foreach (var ext in authorizedExtensions)
            {
                if (ext == extension) isAuthorized = true;
            }
            return isAuthorized;
        }
    }
}
