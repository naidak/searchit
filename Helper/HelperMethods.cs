using Azure.Core;
using JobSearchingWebApp.Endpoints.CV.Update;
using JobSearchingWebApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JobSearchingWebApp.Helper
{
    public static class HelperMethods
    { 

        public static IEnumerable<T> SortByProperty<T>(IEnumerable<T> lista, string propertyNaziv, bool ascending)
        {
            var props = propertyNaziv.Split('.');
            var propertyInfo = typeof(T).GetProperty(props[0], BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property '{propertyNaziv}' does not exist on type '{typeof(T)}'");
            }

            return ascending
                ? lista.OrderBy(x => GetNestedPropertyValue(x, props))
                : lista.OrderByDescending(x => GetNestedPropertyValue(x, props));
        }

        public static object GetNestedPropertyValue(object obj, string[] props)
        {
            foreach (var prop in props)
            {
                if (obj == null) return null;

                var propInfo = obj.GetType().GetProperty(prop, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

                if (propInfo == null) return null;

                obj = propInfo.GetValue(obj, null);
            }

            return obj;
        }

        public static string GenerateSalt()
        {
            byte[] byteArray = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(byteArray);
            }
            return Convert.ToBase64String(byteArray);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
