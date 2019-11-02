using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace AnsonGlue.Tool
{
    public class CIniFile
    {
        /// <summary>
        ///     写入INI文件
        /// </summary>
        /// <param name="section">节点名称[如[TypeName]]</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        /// <summary>
        ///     读取INI文件
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="def">值</param>
        /// <param name="retval">stringbulider对象</param>
        /// <param name="size">字节大小</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval,
            int size, string filePath);



        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern uint GetPrivateProfileStringA(string section, string key,
            string def, byte[] retVal, int size, string filePath);

        /// <summary>
        ///     写入
        /// </summary>
        /// <param name="strSection">节点名称</param>
        /// <param name="strKey">键</param>
        /// <param name="strValue">值</param>
        /// <param name="strPath">文件路径</param>
        public void WriteContentValueToIni(string strSection, string strKey, string strValue, string strPath)
        {
            WritePrivateProfileString(strSection, strKey, strValue, strPath);
        }

        /// <summary>
        ///     读取INI文件中的内容方法
        /// </summary>
        /// <param name="strSection">节点名称</param>
        /// <param name="strKey">键</param>
        /// <param name="strPath">文件路径</param>
        /// <returns>值</returns>
        public string ReadContentValueFromIni(string strSection, string strKey, string strPath)
        {
            var temp = new StringBuilder(1024);
            GetPrivateProfileString(strSection, strKey, "", temp, 1024, strPath);
            return temp.ToString();
        }

        /// <summary>
        /// 读取ini中键值的集合
        /// </summary>
        /// <param name="strSection">段名</param>
        /// <param name="strPath">文件名</param>
        /// <returns></returns>
        public List<string> ReadKeys(string strSection, string strPath)
        {
            List<string> result = new List<string>();
            Byte[] buf = new Byte[65536];
            GetPrivateProfileStringA(strSection, null, null, buf, buf.Length, strPath);
            uint len = GetPrivateProfileStringA(strSection, null, null, buf, buf.Length, strPath);
            int j = 0;
            for (int i = 0; i < len; i++) //遍历字节数组
            {
                if (buf[i] == 0)  //字符串结束位
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j)); //截取字符串
                    j = i + 1;//记录上一次字符串结束位的索引
                }
            }

            return result;
        }

        /// <summary>
        /// 读取ini中的段名的集合
        /// </summary>
        /// <param name="strPath">文件名</param>
        /// <returns></returns>
        public List<string> ReadSections( string strPath)
        {
            List<string> result = new List<string>();
            byte[] buf = new byte[65536];
            GetPrivateProfileStringA(null, null, null, buf, buf.Length, strPath);
            uint len = GetPrivateProfileStringA(null, null, null, buf, buf.Length, strPath);
            int j = 0;
            for (int i = 0; i < len; i++)//遍历字节数组
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            return result;
        }

        private List<string> ByteConvertToString(byte[] buf)
        {
            List<string> result = new List<string>();
            int j = 0;
            for (int i = 0; i < buf.Length; i++)//遍历字节数组
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));//截取字符串
                    j = i + 1;//记录上一次字符串结束位的索引
                }

            return result;
        }

        /// <summary>
        ///     向txt文件写值
        /// </summary>
        /// <param name="strPath">txt文件路劲</param>
        /// <param name="strInfo">添加信息</param>
        /// <param name="bAddTime">是否加时间</param>
        public void WriteStrToTxt(string strPath, string strInfo, bool bAddTime = true)
        {
            var fs = new FileStream(strPath, FileMode.Append, FileAccess.Write);
            if (bAddTime) strInfo = strInfo + "   " + DateTime.Now.ToLocalTime().ToString(CultureInfo.CurrentCulture);
            strInfo = strInfo + "\r\n";

            //获得字节数组
            var data = Encoding.Default.GetBytes(strInfo);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
    }
}