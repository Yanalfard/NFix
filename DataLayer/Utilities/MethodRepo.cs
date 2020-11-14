using DataLayer.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DataLayer.Utilities
{
    public static class MethodRepo
    {
        private static Random _rng = new Random();
        private static readonly string ConnectionString = Config.ConnectionString;

        private static SqlConnection _connection;
        private static SqlCommand _command;

        public static DateTime C24To12(string t24)
        {
            if (t24 == "0001-01-01")
            {
                return new DateTime(1900, 1, 1, 12, 1, 1);
            }
            else
            {
                string[] datetime = t24.Split(' ');
                string time = datetime[1];
                string[] timeLaps = time.Split(':');
                int hour = Convert.ToInt32(timeLaps[0]);
                int min = Convert.ToInt32(timeLaps[1]);
                int sec = Convert.ToInt32(timeLaps[2]);
                if (hour > 12)
                {
                    hour -= 12;
                    return DateTime.Parse(datetime[0] + " " + hour + ":" + min + ":" + sec + " PM");
                }
                if (hour == 12 && (min > 0 || sec > 0))
                    return DateTime.Parse(datetime[0] + " " + hour + ":" + min + ":" + sec + " PM");
                if (datetime[2] == "PM")
                    return DateTime.Parse(t24);
                if (hour == 0 && min == 0 && sec == 0)
                    return DateTime.Parse(t24.Split('.')[0] + " AM");
                return DateTime.Parse(datetime[0] + " " + datetime[1] + " AM");
            }
        }

        public static bool CheckRechapcha(FormCollection form)
        {
            string urlToPost = "https://www.google.com/recaptcha/api/siteverify";
            //< !--Site-- >
            //string secretKey = "6LepA-IZAAAAAH31nwaZGoIFt_mEOsLDBPlsg17J"; // change this
            //< !--localhost-- >
            string secretKey = "6LfOVNwZAAAAAPj0ia7sDuqvApueRKSHU6y7gxsp"; // change this //
            string gRecaptchaResponse = form["g-recaptcha-response"];

            var postData = "secret=" + secretKey + "&response=" + gRecaptchaResponse;

            // send post data
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToPost);
            request.Method = "POST";
            request.ContentLength = postData.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(postData);
            }

            // receive the response now
            string result = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }

            // validate the response from Google reCaptcha
            var captChaesponse = JsonConvert.DeserializeObject<reCaptchaResponse>(result);
            return captChaesponse.Success;
            //!!!
            //return true;
        }

        public static string C12To24(DateTime t12)
        {
            string[] datetime = t12.ToString().Split(' ');
            string[] cdate = datetime[0].Split('/');
            string date = cdate[2] + '-' + cdate[0] + '-' + cdate[1];
            string[] time = datetime[1].Split(':');
            int hour = Convert.ToInt32(time[0]);
            int min = Convert.ToInt32(time[1]);
            int sec = Convert.ToInt32(time[2]);
            if (datetime[2] == "PM")
                hour += 12;
            if (hour == 24)
                hour = 0;
            return date + " " + hour + ":" + min + ":" + sec;
        }

        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static bool ExistInDb(string tableName, string columnName, string columnValue)
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
            _command = new SqlCommand($"SELECT id FROM {tableName} WHERE {columnName} = '{columnValue}'", _connection);
            SqlDataReader reader = _command.ExecuteReader();
            bool result = reader.Read();
            reader.Close();
            _connection.Close();
            return result;
        }

        /// <summary>
        /// Converts a Tbl type To Dto type
        /// </summary>
        /// <typeparam name="T">Tbl</typeparam>
        /// <typeparam name="TY">Dto</typeparam>
        /// <param name="tableList">Tbl var</param>
        /// <returns>A list of Dto</returns>
        public static List<TY> ConvertToDto<T, TY>(List<T> tableList)
        {
            List<TY> res = new List<TY>();
            foreach (T i in tableList)
                res.Add((TY)Activator.CreateInstance(typeof(TY), i));

            return res;
        }

        public static bool CheckIdentification(string nationalCode)
        {
            try
            {
                var allDigitEqual = new[]
                {
                    "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999"
                };
                if (allDigitEqual.Contains(nationalCode))
                    return false;
                var chArray = nationalCode.ToCharArray();
                var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
                var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
                var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
                var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
                var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
                var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
                var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
                var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
                var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
                var a = Convert.ToInt32(chArray[9].ToString());
                var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
                var c = b % 11;
                return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
            }
            catch
            {
                return false;
            }
        }
    }
}