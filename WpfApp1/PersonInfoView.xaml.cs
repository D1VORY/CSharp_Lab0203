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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для PersonInfoView.xaml
    /// </summary>
    public partial class PersonInfoView : Window
    {
        public PersonInfoView()
        {
            InitializeComponent();
        }

        public PersonInfoView(Person p): this()
        {
            DataContext = new PersonInfoViewModel(p);
        }
    }
}
