using System;
using System.Collections.Generic;
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
using System.Collections;
using DevExpress.Xpf.Grid;

namespace DXGrid_CustomGrouping {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            this.DataContext = new MyViewModel();
     
        }

        private void grid_CustomColumnGroup(object sender,
                                            CustomColumnSortEventArgs e) {
            if (e.Column.FieldName == "UnitPrice") {
                double x = Math.Floor(Convert.ToDouble(e.Value1) / 10);
                double y = Math.Floor(Convert.ToDouble(e.Value2) / 10);
                int res = Comparer.Default.Compare(x, y);
                if (x > 9 && y > 9) res = 0;
                e.Result = res;
                e.Handled = true;
            }
        }
        private void grid_CustomGroupDisplayText(object sender,
                                                 CustomGroupDisplayTextEventArgs e) {
            if (e.Column.FieldName != "UnitPrice") return;
            int groupLevel = grid.GetRowLevelByRowHandle(e.RowHandle);
            if (groupLevel != e.Column.GroupIndex) return;
            string interval = IntervalByValue(e.Value);
            e.DisplayText = interval;
        }
        // Gets the text that represents the interval which contains the specified value.
        private string IntervalByValue(object val) {
            double d = Math.Floor(Convert.ToDouble(val) / 10);
            string ret = string.Format("{0:c} - {1:c} ", d * 10, (d + 1) * 10);
            if (d > 9) ret = string.Format(">= {0:c} ", 100);
            return ret;
        }

    }
}
