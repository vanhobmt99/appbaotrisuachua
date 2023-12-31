#region Imports

using System;
using System.Text;
using System.Xml;

#endregion

namespace CMMSBT.Util
{
    /// <summary>
    /// Page Action Enum
    /// </summary>
    public enum PageAction
    {
        None = 0,
        Insert = 1,
        Update = 2,
        Delete = 3,
        Active = 4,
        InActive = 5,
        ApproveThietKe = 6,
        RejectThietKe = 7,
        ApproveChietTinh = 8,
        RejectChietTinh = 9,
        ApproveThiCong = 10,
        RejectThiCong = 11
    }

    /// <summary>
    /// Summary description for CommonUtil.
    /// </summary>
    public class CommonUtil
    {
        /// <summary>
        /// Format file name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string FormatFileName(string name)
        {
            var dateTime = DateTime.Now.ToString("yyyyMMddhhmmss");
            var strRes = name.Replace(" ", "_");
            return dateTime + "_" + strRes;
        }

        /// <summary>
        /// GenerateRandomString
        /// </summary>
        /// <param name="intLenghtOfString"></param>
        /// <returns></returns>
        public static string GenerateRandomString(int intLenghtOfString)
        {

            var randomString = new StringBuilder();
            var randomNumber = new Random();

            for (var i = 0; i <= intLenghtOfString; ++i)
            {
                var appendedChar = Convert.ToChar(Convert.ToInt32(26 * randomNumber.NextDouble()) + 65);
                randomString.Append(appendedChar);
            }

            return randomString.ToString();
        }

        /// <summary>
        /// Generate random code
        /// </summary>
        /// <param name="intLenghtOfString"></param>
        /// <returns>
        /// String of numbers
        /// </returns>
        public static string GenerateRandomCode(int intLenghtOfString)
        {
            var codeStr = string.Empty;
            var random = new Random();

            try
            {
                for (int i = 0; i < intLenghtOfString; i++)
                {
                    codeStr = String.Concat(codeStr, random.Next(10).ToString());
                }
            }
            catch (Exception)
            {
            }

            return codeStr;
        }

        /// <summary>
        /// Read from application configure file
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public static string ReadApplicationConfig(string tagName, string folderPath)
        {
            var xmlDoc = new XmlDocument();

            xmlDoc.Load(folderPath);
            var nodeText = xmlDoc.SelectSingleNode(tagName)!.InnerText;

            return nodeText.ToLower();
        }

        /// <summary>
        /// Show confirm message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string ShowConfirm(string message)
        {
            return "return confirm('" + message + "');";
        }
        /// <summary>
        /// Đọc số tiền thành chữ
        /// </summary>
        /// <param name="number">Số tiền</param>
        /// <returns></returns>
        public static string DocSoTien(decimal number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = " ";
            bool booAm = false;
            decimal decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDecimal(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                            str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "mốt " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;
            str = str + "đồng chẵn";
            if (str.Substring(0, 1) == " ")
                str = str.Substring(1, str.Length-1);
            var stt = str.IndexOf("  ");
            while (stt > 0)
            {              
                str = str.Remove(stt, 1);
                stt = str.IndexOf("  ");
            };            

            char[] c = str.ToCharArray();
            int k;
            for (k = 0; k < str.Length; k++)
            {
                if (k == 0) c[k] = c[k].ToString().ToUpper()[0];
                else c[k] = c[k].ToString().ToLower()[0];
            }

            return new string(c);
        }
   
    }
}
