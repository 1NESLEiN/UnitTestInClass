using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Person
    {
        private string _name;
        private double _age;
        private string _cpr;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();
                _name = value;
            }
        }

        public string CPR
        {
            get { return _cpr; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                _cpr = value;
            }
        }

        public double Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                {
                    throw new AgeException();
                }
                _age = value;
            }

        }

        public Person(string name, double age, string cpr)
        {
            _name = name;
            _age = age;
            _cpr = cpr;
        }

        public bool isAdult()
        {
            return _age >= 18;
        }

        /*public override bool Equals(object obj)
        {
            Person otherPerson = (Person) obj;

            #region FirstTime
            bool result;

            if (this.Name == otherPerson.Name && this.Age == otherPerson.Age && this.CPR == otherPerson.CPR)
            {
                result = true;
            }
            else
            {
                result = false;
            }
             
            #endregion

            return (this.Name == otherPerson.Name) && (this.CPR == otherPerson.CPR) && (this.Age == otherPerson.Age);
        }*/

        protected bool Equals(Person other)
        {
            return string.Equals(_name, other._name) && _age.Equals(other._age) && string.Equals(_cpr, other._cpr);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Person) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _age.GetHashCode();
                hashCode = (hashCode*397) ^ (_cpr != null ? _cpr.GetHashCode() : 0);
                return hashCode;
            }
        }
    } 
}