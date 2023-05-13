using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;


namespace Metadata
{
    internal class Delegates
    {
        public void Others()
            => System.Windows.MessageBox.Show("File clicked");
        public void Staff()
            => System.Windows.MessageBox.Show("Staff clicked");
        public void Orders()
            => System.Windows.MessageBox.Show("Ordersclicked");
        public void Docs()
            => System.Windows.MessageBox.Show("Docs clicked");
        public void Departs()
            => System.Windows.MessageBox.Show("Departs clicked");
        public void Towns()
            => System.Windows.MessageBox.Show("Towns clicked");
        public void Posts()
            => System.Windows.MessageBox.Show("Posts clicked");
        public void Window()
            => System.Windows.MessageBox.Show("Window clicked");
        public void Help()
            => System.Windows.MessageBox.Show("Help clicked");
        public void Content()
            => System.Windows.MessageBox.Show("Content clicked");
        public void About()
            => System.Windows.MessageBox.Show("About clicked");

        public Delegates()
        {
            calls.Add("Others", Others);
            calls.Add("Staff", Staff);
            calls.Add("Orders", Orders);
            calls.Add("Docs", Docs);
            calls.Add("Departs", Departs);
            calls.Add("Towns", Towns);
            calls.Add("Posts", Posts);
            calls.Add("Window", Window);
            calls.Add("Help", Help);
            calls.Add("Content", Content);
            calls.Add("About", About);
        }
        Dictionary<string, Delegate> calls = new Dictionary<string, Delegate>();

        public void callDelegate(string name)
        {
            if (name != "")
                calls[name].DynamicInvoke();
            return;
        }
    }
}