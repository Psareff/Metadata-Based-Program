using System.Collections.Generic;

namespace Metadata
{
    internal class MenuBarProcessor
    {
        MenuBarParser menuBarParser;
        
        public MenuBarProcessor(MenuBarParser menuBarParser)
        => this.menuBarParser = menuBarParser;

        public List<MenuElement> Process()
        {
            List<MenuElement> elements = menuBarParser.Parse();
            List<MenuElement> ProcessedItems = new List<MenuElement>();
            MenuElement buff;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Level == 0)
                    ProcessedItems.Add(elements[i]);
                else
                {
                    if (elements[i].Level <= elements[i - 1].Level)
                    {
                        buff = elements[i];
                        int j = i;
                        while (!(elements[i].Level - 1 == buff.Level))
                        {
                            buff = elements[j];
                            j--;
                        }
                        buff.Elements.Add(elements[i]);
                        continue;
                    }

                    if (elements[i].Level > elements[i - 1].Level)
                    {
                        elements[i - 1].Elements.Add(elements[i]);
                        elements[i - 1].ItemsSource = elements[i - 1].Elements;
                        continue;
                    }
                }
            }
            return ProcessedItems;

        }



    }
}