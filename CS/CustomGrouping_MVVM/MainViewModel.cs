using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CustomGrouping_MVVM {
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

    public class MainViewModel : ViewModelBase {
        public ObservableCollection<Person> ListPerson { get; }
        
        public MainViewModel() {
            ListPerson = new ObservableCollection<Person>(GetPersonList());
        }
        static IEnumerable<Person> GetPersonList() {
            return Enumerable.Range(0, 100).Select(i => new Person(i));
        }

        [Command]
        public void CustomColumnGroup(RowSortArgs args) {
            if(args.FieldName != "UnitPrice")
                return;
            double x = Math.Floor(Convert.ToDouble(args.FirstValue) / 10);
            double y = Math.Floor(Convert.ToDouble(args.SecondValue) / 10);
            args.Result = x > 9 && y > 9 ? 0 : x.CompareTo(y);
        }

        [Command]
        public void CustomGroupDisplayText(GroupDisplayTextArgs args) {
            if(args.FieldName != "UnitPrice")
                return;
            string interval = IntervalByValue(args.Value);
            args.DisplayText = interval;
        }
        // Gets the text that represents the interval which contains the specified value.
        private string IntervalByValue(object val) {
            double d = Math.Floor(Convert.ToDouble(val) / 10);
            string ret = string.Format("{0:c} - {1:c} ", d * 10, (d + 1) * 10);
            if(d > 9)
                ret = string.Format(">= {0:c} ", 100);
            return ret;
        }
    }
}
