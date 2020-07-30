using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDataGrid
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Model> mlist;
        public MainWindow()
        {
            InitializeComponent();

            mlist = new List<Model>();
            
            for(int i=0;i<100*100;i++)
            {
                var m = new Model();
                m.index = i;
                m.Name = "testdata"+i;
                m.PhoneNum = i+"testdata";
                mlist.Add(m);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var tag = btn.Tag as string;
            switch (tag)
            {
                case "init":
                    dg.ItemsSource = mlist;
                    break;
                case "hide":
                    for (int i = 3; i < mlist.Count; i++)
                    {
                        mlist[i].isVisible = Visibility.Collapsed;
                    }
                    break;
                case "show":
                    for (int i = 3; i < mlist.Count; i++)
                    {
                        mlist[i].isVisible = Visibility.Visible;
                    }
                    break;
            }
            
        }
    }

    public class Model:INotifyPropertyChanged
    {
        public int index { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }

        Visibility _isVisible;
        public Visibility isVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged("isVisible");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
