using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Annotations;

namespace WpfApp1
{
    class PersonInfoViewModel:INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _secondName;
        public string SecondName
        {
            get => _secondName;
            set
            {
                _secondName = value;
                OnPropertyChanged("SecondName");
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _birthDate;
        public string BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        private string _westSign;
        public string WestSign
        {
            get => _westSign;
            set
            {
                _westSign = value;
                OnPropertyChanged("WestSign");
            }
        }

        private string _asianSign;
        public string AsianSign
        {
            get => _asianSign;
            set
            {
                _asianSign = value;
                OnPropertyChanged("AsianSign");
            }
        }

        private string _isAdult;
        public string IsAdult
        {
            get => _isAdult;
            set
            {
                _isAdult = value;
                OnPropertyChanged("IsAdult");
            }
        }

        private string _isBirthDay;
        public string IsBirthday
        {
            get => _isBirthDay;
            set
            {
                _isBirthDay = value;
                OnPropertyChanged("IsBirthday");
            }
        }

        public PersonInfoViewModel(Person p)
        {
            Name = p.Name;
            SecondName = p.SecondName;
            Email = p.Email;
            BirthDate = p.BirthDate.ToShortDateString();
            WestSign = p.SunSign;
            AsianSign = p.ChineseSign;
            IsAdult = p.IsAdult.ToString();
            IsBirthday = p.IsBirthday.ToString();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
