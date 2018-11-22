using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace homework9
{
    public class Program
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        public Program()
        {
            urls = new Hashtable();
            count = 0;
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了....");
            Parallel.For(0, 10, i =>
            {
                string current = null;

                lock (this)
                {
                    foreach (string url in urls.Keys)
                    {
                        if ((bool)urls[url])
                        {
                            continue;
                        }
                        current = url;
                    }
                    Console.WriteLine("爬行" + current + "页面！");
                    string html = DownLoad(current);
                    urls[current] = true;
                    count = i;
                    Parse(html);
                }
            });
            Console.WriteLine("爬行结束\n");
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            Parallel.For(0, matches.Count, i =>
            {
                strRef = matches[i].Value.Substring(matches[i].Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');
                if (strRef.Length == 0)return;
                if (urls[strRef] == null)urls[strRef] = false;
            });
        }

        static void Main(string[] args)
        {
            Program myCrawler = new Program();
            string starturl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) starturl = args[0];
            myCrawler.urls.Add(starturl, false);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            myCrawler.Crawl();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

    }
}
