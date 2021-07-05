using DevExpress.Xpf.Grid;
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

namespace CustomGrouping_CodeBehind {
    public class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UnitPrice { get; set; }

        public Person() { }
        public Person(int i) {
            FirstName = "FirstName" + i;
            LastName = "LastName" + i;
            UnitPrice = i;
        }
    }
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            grid.ItemsSource = GetPersonList().ToList();
        }
        static IEnumerable<Person> GetPersonList() {
            return Enumerable.Range(0, 100).Select(i => new Person(i));
        }

        void OnCustomColumnGroup(object sender, CustomColumnSortEventArgs e) {
            if(e.Column.FieldName != "UnitPrice")
                return;
            double x = Math.Floor(Convert.ToDouble(e.Value1) / 10);
            double y = Math.Floor(Convert.ToDouble(e.Value2) / 10);
            e.Result = x > 9 && y > 9 ? 0 : x.CompareTo(y);
            e.Handled = true;
        }
        
        void OnCustomGroupDisplayText(object sender, CustomGroupDisplayTextEventArgs e) {
            if(e.Column.FieldName != "UnitPrice")
                return;
            string interval = IntervalByValue(e.Value);
            e.DisplayText = interval;
        }
        
        // Gets the interval which contains the specified value.
        private string IntervalByValue(object val) {
            double d = Math.Floor(Convert.ToDouble(val) / 10);
            string ret = string.Format("{0:c} - {1:c} ", d * 10, (d + 1) * 10);
            if(d > 9)
                ret = string.Format(">= {0:c} ", 100);
            return ret;
        }
    }
}
