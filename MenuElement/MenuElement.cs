using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

public enum Availability { Available, Inactive, Disabled }

namespace MenuElement
{
    public class MenuElement : MenuItem
    {
        private int _level;
        private string _name;
        private Availability _availability;
        private string _handler;
        private List<MenuItem> _elements;

        private Delegates delegates = new Delegates();

        public MenuElement()
        {
            _elements = new List<MenuItem>();
            Click += MenuItemClick;
        }

        public int Level { get => _level; set { if (value >= 0) _level = value; } }
        public string Name
        {
            get => _name;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _name = value;
                    Header = _name;
                }
            }
        }
        public Availability Availability
        {
            get => _availability;
            set
            {
                _availability = value;
                switch (_availability)
                {
                    case Availability.Available:
                        Visibility = System.Windows.Visibility.Visible;
                        break;
                    case Availability.Inactive:
                        Visibility = System.Windows.Visibility.Visible;
                        IsEnabled = false;
                        break;
                    case Availability.Disabled:
                        Visibility = System.Windows.Visibility.Collapsed;
                        IsEnabled = false;
                        break;
                    default:
                        throw new ArgumentException("Invalid availability parameter");
                }

            }
        }
        public string Handler { get => _handler; set => _handler = value; }

        public List<MenuItem> Elements { get => _elements; set => _elements = value; }

        public void MenuItemClick(object sender, RoutedEventArgs e)
        {
            delegates.callDelegate((sender as MenuElement).Handler);
        }
    }
}