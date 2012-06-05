﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.UTL.Hasher
{
    /// <summary>
    /// Mã hoá và giải mã chuỗi
    /// </summary>
    public static class Code
    {
        /// <summary>
        /// Mã hoá chuỗi
        /// </summary>
        /// <param name="data">Chuỗi cần mã</param>
        /// <returns>Chuỗi đã được mã</returns>
        public static string Encode(string data)
        {
            try
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception e)
            {
                throw new Exception("Lỗi mã hoá: " + e.Message);
            }
        }

        /// <summary>
        /// Giải mã chuỗi
        /// </summary>
        /// <param name="data">Chuỗi cần giải mã</param>
        /// <returns>Chuỗi đã được giải mã</returns>
        public static string Decode(string data)
        {
            try
            {
                UTF8Encoding encoder = new UTF8Encoding();
                Decoder utf8Decode = encoder.GetDecoder();

                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);

                string result = new String(decoded_char);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Lỗi giải mã: " + e.Message);
            }
        }
    }
}