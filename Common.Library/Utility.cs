using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Library
{
    public static class Utility
    {
        /// <summary>
        /// Sha1 Encription
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string toEncrypt(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return "";
            }
            byte[] bytes = Encoding.UTF8.GetBytes(s);

            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return HexStringFromBytes(hashBytes);
        }
        private static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
        /// <summary>
        /// Valid email check
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <returns></returns>
        public static bool IsValidMail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Bangladesh mobile number validation
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool IsValidMobile(string mobile)
        {
            try
            {
                if (mobile.Length == 11)
                {
                    string[] mobilecode = { "013", "014", "015", "016", "017", "018", "019" };
                    if (mobilecode.Contains(mobile.Substring(0, 3)))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// String to int
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>

        public static int toInt(this string s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        /// <summary>
        /// String to long
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long toLong(this string s)
        {
            try
            {
                return Convert.ToInt64(s);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// Guid Id validation check
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsGuid(this string value)
        {
            try
            {
                try
                {
                    if (value == null)
                    {
                        return false;
                    }
                    else if (value == Guid.Empty.ToString())
                    {
                        return false;
                    }
                    Guid x;
                    return Guid.TryParse(value.ToString(), out x);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// String to guid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid StringToGuid(this string value)
        {
            try
            {
                Guid x;
                Guid.TryParse(value, out x);
                return x;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
        /// <summary>
        /// string to decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal toString_Decimal(this string value)
        {
            decimal number;
            NumberStyles style;
            CultureInfo provider;

            style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            provider = new CultureInfo("fr-FR");
            try
            {
                number = Decimal.Parse(value, style, CultureInfo.InvariantCulture);
                return number;
            }
            catch (FormatException)
            {
                return 0;
            }
        }

        public static string getFormateString(int length, string val)
        {
            int l = length - val.Length;
            if (l <= 0)
                l = 0;
            string nS = "";
            while (l > 0)
            {
                nS += "0";
                l--;
            }
            return nS + "" + val;
        }
        /// <summary>
        /// String value convert uper case
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToUperString(this string val)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                return "";
            }
            else
            {
                return val.ToUpper();
            }
        }
        /// <summary>
        /// Random string return
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// In word funtion from string number
        /// </summary>
        /// <param name="numb"></param>
        /// <returns></returns>
        public static string ConvertToWords(this string numb)
        {
            string val, wholeNo = numb;
            string andStr = "", pointStr = "";
            string endStr = "Only";
            try
            {
                int decimalPlace = numb.IndexOf(".", StringComparison.Ordinal);
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    var points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "and"; // just to separate whole numbers from points/cents  
                        endStr = "Paisa " + endStr; //Cents  
                        pointStr = ConvertDecimals(points);
                    }
                }
                val = string.Format("{0} {1}{2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch
            {
                return "Invalid number......";
            }
            return val;
        }
        private static string ConvertWholeNumber(string number)
        {
            string word = "";
            try
            {
                bool isDone = false; //test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {
                    //test for zero or digit zero in a nuemric

                    int numDigits = number.Length;
                    int pos = 0; //store digit grouping
                    string place = ""; //digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1: //ones' range

                            word = Ones(number);
                            isDone = true;
                            break;
                        case 2: //tens' range
                            word = Tens(number);
                            isDone = true;
                            break;
                        case 3: //hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4: //thousands' range
                        case 5:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 6: //Lakh' range
                        case 7:
                            pos = (numDigits % 6) + 1;
                            place = " Lakh ";
                            break;
                        case 8: //Lakh's range
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                            pos = (numDigits % 8) + 1;
                            place = " Crore ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        //if transalation is not done, continue...(Recursion comes in now!!)
                        if (number.Substring(0, pos) != "0" && number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(number.Substring(0, pos)) + place +
                                       ConvertWholeNumber(number.Substring(pos));
                            }
                            catch
                            {
                                //ignore
                            }
                        }
                        else
                        {
                            word = ConvertWholeNumber(number.Substring(0, pos)) +
                                   ConvertWholeNumber(number.Substring(pos));
                        }

                        //check for trailing zeros
                        //if (beginsZero) word = " and " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch
            {
                return "Invalid number.....";
            }
            return word.Trim();
        }

        private static String Tens(String number)
        {
            int numberiInt32 = Convert.ToInt32(number);
            string name = null;
            switch (numberiInt32)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (numberiInt32 > 0)
                    {
                        name = Tens(number.Substring(0, 1) + "0") + " " + Ones(number.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private static String Ones(String number)
        {
            int numberiInt32 = Convert.ToInt32(number);
            string name = "";
            switch (numberiInt32)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static String ConvertDecimals(String number)
        {
            String cd = "";
            foreach (char t in number)
            {
                var digit = t.ToString();
                string engOne;
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = Ones(digit);
                }
                cd += " " + engOne;
            }
            return cd;
        }
        /// <summary>
        /// Add Comma in decimal number
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static String AddCommas(this decimal amount)
        {
            string result;
            string amt;

            amt = amount.ToString(CultureInfo.InvariantCulture);
            int aaa = amount.ToString(CultureInfo.InvariantCulture).IndexOf(".", 0, StringComparison.Ordinal);
            var amtPaisa = amount.ToString(CultureInfo.InvariantCulture).Substring(aaa + 1);

            if (amt == amtPaisa)
            {
                amtPaisa = "";
            }
            else
            {
                amt = amount.ToString(CultureInfo.InvariantCulture).Substring(0, amount.ToString(CultureInfo.InvariantCulture).IndexOf(".", 0, StringComparison.Ordinal));
                amt = (amt.Replace(",", ""));
            }
            switch (amt.Length)
            {
                case 9:
                    if (amtPaisa == "")
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                 amt.Substring(4, 2) + "," + amt.Substring(6, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                 amt.Substring(4, 2) + "," + amt.Substring(6, 3) + "." +
                                 amtPaisa;
                    }
                    break;
                case 8:
                    if (amtPaisa == "")
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                 amt.Substring(3, 2) + "," + amt.Substring(5, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                 amt.Substring(3, 2) + "," + amt.Substring(5, 3) + "." +
                                 amtPaisa;
                    }
                    break;
                case 7:
                    if (amtPaisa == "")
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                 amt.Substring(4, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                 amt.Substring(4, 3) + "." + amtPaisa;
                    }
                    break;
                case 6:
                    if (amtPaisa == "")
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                 amt.Substring(3, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                 amt.Substring(3, 3) + "." + amtPaisa;
                    }
                    break;
                case 5:
                    if (amtPaisa == "")
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 3) + "." +
                                 amtPaisa;
                    }
                    break;
                case 4:
                    if (amtPaisa == "")
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 3) + "." +
                                 amtPaisa;
                    }
                    break;
                default:
                    if (amtPaisa == "")
                    {
                        result = amt;
                    }
                    else
                    {
                        result = amt + "." + amtPaisa;
                    }
                    break;
            }
            return result;
        }
        public static string AddOrdinal(this int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }

        }
        /// <summary>
        /// Return SelectList from enum 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SelectList EnumToList<T>(int id = 0) where T : Enum
        {
            var ss = new SelectList(from T s in Enum.GetValues(typeof(T))
                                    select new
                                    {
                                        Id = Convert.ToInt32(s),
                                        Name = s.ToDescription()
                                    }, "Id", "Name", id);
            return ss;
        }
        /// <summary>
        /// Return List from enum 
        /// Nullable Parameter filtered by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchid"></param>
        /// <returns></returns>
        public static dynamic EnumToDynamicList<T>(List<int> searchid = null) where T : Enum
        {
            var ss = (from T s in Enum.GetValues(typeof(T))
                      where (searchid == null || searchid.Contains(Convert.ToInt32(s)))
                      select new
                      {
                          Id = Convert.ToInt32(s),
                          Name = s.ToDescription()
                      }).ToList();
            return ss;
        }
        /// <summary>
        /// Return string description from enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            object[] attribs = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attribs.Length > 0)
            {
                return ((DescriptionAttribute)attribs[0]).Description.ToString();
            }
            return value.ToString();
        }
        /// <summary>
        /// Return int value from enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this Enum value)
        {
            int something = value.ToInt();
            return something;
        }
        /// <summary>
        /// Default return format "dd/MM/yyyy"
        /// Pass parameter for specific format
        /// </summary>
        /// <param name="date"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime StringToDate(this string date, string format = "dd/MM/yyyy")
        {
            if (String.IsNullOrWhiteSpace(date))
            {
                date = DateTime.Now.ToString("dd/MM/yyyy");
            }
            DateTime dt = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
            return dt;
        }
        /// <summary>
        /// Return string from date. Format: "dd/MM/yyyy"
        /// if date null then return current date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static String DateToString(this DateTime date)
        {
            if (date == null)
            {
                date = DateTime.Now;
            }
            String dt = date.ToString("dd/MM/yyyy");
            return dt;
        }
        /// <summary>
        /// Return string from date. Format: "dd/MM/yyyy"
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static String ToStringDate(this DateTime date)
        {
            if (date == null)
            {
                return "";
            }
            String dt = date.ToString("dd/MM/yyyy");
            return dt;
        }
        /// <summary>
        /// Return object class from json string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T StringToJson<T>(this string json)
        {
            if (String.IsNullOrWhiteSpace(json))
            {
                return default(T);
            }
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
        public static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats  officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        public static decimal DiscountPercentCalculation(decimal UnitPrice, decimal DiscountAmount)
        {
            try
            {
                var price = UnitPrice - DiscountAmount;
                var s = price / UnitPrice;
                var t = 100 - (s * 100);
                var result = Convert.ToDecimal(Math.Round(t, 2));
                if (result > 0)
                {
                    return result;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static string GenerateOptNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max).ToString();
        }
        public static string GenerateOptNo(int _min, int _max)
        {
            Random _rdm = new Random();
            return _rdm.Next(_min, _max).ToString();
        }

     
        public static string GenerateRandomImage()
        {
            Random _random = new Random();
            var num = _random.Next(1, 4);
            return "/Upload/no_img_" + num + ".png";
        }
        public static string GenerateUrlString(this string str)
        {
            str = Regex.Replace(str, "[^a-zA-Z0-9_]+", "-", RegexOptions.Compiled);
            if (str.Substring(str.Length - 1) == "-")
            {
                str = str.Remove(str.Length - 1, 1) + "";
            }
            return str.ToLower();
        }
        public static string ToSubstring(this string val, int s_len, int e_len)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                return "";
            }
            else
            {
                if (val == "")
                {
                    return val;
                }
                else
                {
                    try
                    {
                        var s = val.Substring(s_len, e_len);
                        return s;
                    }
                    catch (Exception)
                    {
                        return val;
                    }
                }
            }
        }
        public static string ToSubstringReadMore(this string val, int s_len, int e_len)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                return "";
            }
            else
            {
                if (val == "")
                {
                    return val;
                }
                else
                {
                    try
                    {
                        var s = val.Substring(s_len, e_len);
                        return s + "...";
                    }
                    catch (Exception)
                    {
                        return val;
                    }
                }
            }
        }

    }
}
