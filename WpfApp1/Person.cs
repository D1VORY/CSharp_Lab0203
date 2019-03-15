using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Annotations;

namespace WpfApp1
{


    public class Person : INotifyPropertyChanged
    {
        private string _name;
        public string Name {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _secondName;
        public string SecondName {
            get =>_secondName;
            set
            {
                _secondName = value; 
                OnPropertyChanged("SecondName");
            }
        }

        private string _email;
        public string Email {
            get =>_email;
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private DateTime _birthDate;
        public DateTime BirthDate {
            get =>_birthDate;
            set
            {
                _birthDate = value; 
                OnPropertyChanged("BirthDate");
            }
        }

        public readonly bool IsAdult;
        public readonly string SunSign;
        public readonly string ChineseSign;
        public readonly bool IsBirthday;

        public Person(string name, string secondName, string email, DateTime birthDate)
        {
            Name = name;
            SecondName = secondName;
            Email = email;
            BirthDate = birthDate;
            IsAdult = isAdult();
            IsBirthday = IsBirthDay();
            SunSign = WestHoro(birthDate);
            ChineseSign = ChineseZodiak(birthDate);
        }

        public Person(string name, string secondName, string email) : this(name,secondName,email,new DateTime(0,0,0))
        { 
        }

        public Person(string name, string secondName,  DateTime birthDate):this(name,secondName,"Undefined",birthDate)
        {
        }

        private string WestHoro(DateTime bDate)
        {
            switch (bDate.Month)
            {
                case 1:
                    return bDate.Day < 20 ? "Capricon" : "Aquarius";

                case 2:
                    return bDate.Day < 19 ? "Aquarius" : "pisces";

                case 3:
                    return bDate.Day < 21 ? "pisces" : "aries";

                case 4:
                    return bDate.Day < 20 ? "aries" : "taurus";

                case 5:
                    return bDate.Day < 21 ? "taurus" : "gemini";

                case 6:
                    return bDate.Day < 21 ? "gemini" : "cancer";

                case 7:
                    return bDate.Day < 23 ? "cancer" : "leo";

                case 8:
                    return bDate.Day < 23 ? "leo" : "virgo";

                case 9:
                    return bDate.Day < 23 ? "virgo" : "libra";

                case 10:
                    return bDate.Day < 23 ? "libra" : "scorpio";

                case 11:
                    return bDate.Day < 22 ? "scorpio" : "sagittarius";

                case 12:
                    return bDate.Day < 22 ? "sagittarius" : "capricon";
                default:
                    return "";
            }
        }

        private  string ChineseZodiak(DateTime bDate)
        {
            switch (bDate.Year % 12)
            {
                case 0: return "monkey";
                case 1: return "rooster";
                case 2: return "dog";
                case 3: return "pig";
                case 4: return "rat";
                case 5: return "ox";
                case 6: return "tiger";
                case 7: return "rabbit";
                case 8: return "dragon";
                case 9: return "snake";
                case 10: return "horse";
                case 11: return "sheep";
                default: return "";
            }
        }

        private bool isAdult()
        {
            return (((DateTime.Today - BirthDate).Days / 365) >= 18);
        }

        private  bool IsBirthDay()
        {
            return ((BirthDate.Day == DateTime.Today.Day) && (BirthDate.Month == DateTime.Today.Month));
        }

        public static  bool IsValidAge(DateTime BirthDate)
        {
            if (BirthDate >= DateTime.Today)
            {
                throw new BadFutureDateException();
                return false;
            }

            if (DateTime.Today.Year - BirthDate.Year >= 135)
            {
                throw new BadPastDateException();
                return false;
            }
            return true;
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
            {
                throw new BadEmailException();
                return false;
            }

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class BadEmailException : Exception
    { }
    public class BadFutureDateException : Exception
    { }
    public class BadPastDateException : Exception
    { }

}
