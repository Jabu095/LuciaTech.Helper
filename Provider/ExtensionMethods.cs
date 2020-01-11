using LuciaTech.Helper.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuciaTech.Helper.Provider
{
    public static class ExtensionMethods
    {
        public static string Encrypt(this string value)
        {
            return new Encryption().Encypt(value);
        }

        public static string EncryptId(this int Id)
        {
            return new Encryption().Encypt(Id.ToString());
        }

        public static string DeCrypt(this string value)
        {
            return new Encryption().Decrypt(value);
        }

        public static int DeCryptId(this string value)
        {
            return int.Parse(new Encryption().Decrypt(value));
        }

        public static string GetUserId(this string token)
        {
            return token.Split('#')[0].DeCrypt();
        }
    }
}
