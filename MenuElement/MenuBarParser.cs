using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MenuElement
{
    public class MenuBarParser
    {
        private StreamReader streamReader;
        public MenuBarParser(string filename)
        {
            streamReader = new StreamReader(filename);

        }
        public List<MenuElement> Parse()
        {
            List<MenuElement> elements = new List<MenuElement>();
            string row;
            while ((row = streamReader.ReadLine()) != null)
            {
                string[] buff = row.Split(' ');
                for (int i = 0; i < buff.Length; i++)
                    Trace.WriteLine("Element: " + buff[i] + " Counter: " + i);
                MenuElement temp = new MenuElement();
                temp.Level = Convert.ToInt32(buff[0]);

                StringBuilder sb = new StringBuilder();
                int counter = 0;
                int c = 0;
                for (int i = 1; !int.TryParse(buff[i], out c); i++)
                {
                    sb.Append(buff[i]);
                    counter = i;
                }
                temp.Name = sb.ToString();
                temp.Availability = (Availability)(Convert.ToInt32(buff[counter + 1]));
                temp.Handler = buff[counter + 2] != null ? buff[counter + 2] : null;

                elements.Add(temp);
            }
            return elements;
        }
    }
}