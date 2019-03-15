using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Annotations;

namespace WpfApp1
{
    class MyViewModel : INotifyPropertyChanged
    {
        public Person p { get; set; }
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

        private DateTime _birthDate = DateTime.Today;
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public ICommand viewCommand { get; set; }


        public MyViewModel()
        {
            viewCommand = new RelayCommand(showPerson,CanExecuteCommand);
            
        }

        void showPerson(object obj)
        {
            
            CreatePerson();
        }

        private async void CreatePerson()
        {
            try
            {
                Person.IsValidAge(BirthDate);
            }
            catch 
            {
                MessageBox.Show("You have entered invalid Date!");
                return;
            }


            try
            {
                Person.IsValidEmail(Email);
            }
            catch (BadEmailException e)
            {
                MessageBox.Show("You have entered invalid Email!");
                return;
            }
            await Task.Run(() =>
                {
                    p = new Person(Name, SecondName, Email, BirthDate);
                  
                }
            );

            PersonInfoView piv = new PersonInfoView(p);
            piv.Show();
            if (p.IsBirthday)
            {
                MessageBox.Show("Happy birthDay!");
            }

        }


        public bool CanExecuteCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(SecondName) && !string.IsNullOrWhiteSpace(Email) ;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
