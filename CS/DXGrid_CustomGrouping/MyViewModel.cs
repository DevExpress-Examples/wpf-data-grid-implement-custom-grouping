using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DXGrid_CustomGrouping {
    public class MyViewModel  {
        public MyViewModel() {
            CreateList();
        }


        public ObservableCollection<Person> ListPerson { get; set; }
     
        void CreateList() {
            ListPerson = new ObservableCollection<Person>();
            for (int i = 0; i < 100; i++) {
                Person p = new Person(i);
                ListPerson.Add(p);
            }
        }
    }

    public class Person  {
        public Person() {

        }
        public Person(int i) {
            FirstName = "FirstName" + i;
            LastName = "LastName" + i;
          UnitPrice = i ;
        
        }

        string _firstName;

        public string FirstName {
            get { return _firstName; }
            set {
                _firstName = value;
             
            }
        }
        public string LastName { get; set; }
        int _age;

        public int UnitPrice {
            get { return _age; }
            set { _age = value; }
        }
     


    }
}
