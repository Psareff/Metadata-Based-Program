using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;


namespace Metadata
{
    internal class Delegates
    {
        public void fileHandler()
            => Trace.WriteLine("File clicked");

        public void saveHandler()
            => Trace.WriteLine("Save clicked");

        public void closeHandler()
            => Trace.WriteLine("Close clicked");

        public void closeAndSaveHandler()
            => Trace.WriteLine("Close and save clicked");

        public void editHandler()
            => Trace.WriteLine("Edit clicked");

        public void undoHandler()
            => Trace.WriteLine("Undo clicked");

        public void redoHandler()
            => Trace.WriteLine("Redo clicked");

        public void replaceHandler()
            => Trace.WriteLine("Replace clicked");

        public Delegates()
        {
            calls.Add("fileHandler", fileHandler);
            calls.Add("saveHandler", saveHandler);
            calls.Add("closeHandler", closeHandler);
            calls.Add("closeAndSaveHandler", closeAndSaveHandler);
            calls.Add("editHandler", editHandler);
            calls.Add("undoHandler", undoHandler);
            calls.Add("redoHandler", redoHandler);
            calls.Add("replaceHandler", replaceHandler);
        }
        Dictionary<string, Delegate> calls = new Dictionary<string, Delegate>();

        public void callDelegate(string name)
        {
            if (name != "-")
                calls[name].DynamicInvoke();
            return;
        }
    }
}