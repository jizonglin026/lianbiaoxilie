using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

public class SecurityUtil
{
    // MD5加密
    public static string UserMd5(string str)
    {
        string cl = str;
        string md5Str = "";
        MD5 md5Obj = MD5.Create();
        byte[] s = md5Obj.ComputeHash(Encoding.UTF8.GetBytes(cl));
        for (int i = 0; i < s.Length; i++)
        {
            md5Str = md5Str + s[i].ToString("X");
        }
        return md5Str;
    }

    public static string GetStrMd5(string ConvertString)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(ConvertString)));
        //UTF8Encoding.Default.GetBytes(ConvertString)));
        t2 = t2.Replace("-", "");
        return t2.ToLower();
    }
}
