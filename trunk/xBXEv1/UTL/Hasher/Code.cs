﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTL.Hasher
{
    /// <summary>
    /// Base 64 encoding and decoding
    /// </summary>
    public static class Code
    {
        /// <summary>
        /// Encoding
        /// </summary>
        /// <param name="data">String need to encode</param>
        /// <returns>String needed to encode</returns>
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
                throw new Exception("Error in base64Encode" + e.Message);
            }
        }

        /// <summary>
        /// Decoding
        /// </summary>
        /// <param name="data">String need to decode</param>
        /// <returns>String needed to decode</returns>
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
                throw new Exception("Error in base64Decode" + e.Message);
            }
        }
    }
}