using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_MVVM.Models;


//ShellViewModel is Interface and This Acts Like The Backend Code where we write The Logic.
// I am doing this while watching the Tutorials of Iamtimcory on WPF tutorials.

// In fact, All the three Folders Represent The user Interface. {Models Views and ViewModels}

namespace Wpf_MVVM.ViewModels
{
    public class ShellViewModel :Conductor<object>
    {


        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "James" , LastName = "Bond"});
            People.Add(new PersonModel { FirstName = "Eddie", LastName = "Heisenberg" });
            People.Add(new PersonModel { FirstName = "Lionel", LastName = "Messi" });
            People.Add(new PersonModel { FirstName = "Cristiano", LastName = "Ronaldo" });
        }
        private string _firstName = "";

        public string FirstName
        {
            get
            {
            return _firstName;
            }
    set { _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        private string _lastName;

        public  string LastName
        {
            get { return _lastName; }
            set { _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get { return $"{FirstName}  {LastName}"; }
        }

        private BindableCollection<PersonModel> _people= new BindableCollection<PersonModel>();

        public BindableCollection<PersonModel> People 
        {
            get { return _people; }
            set { _people = value; }
        }

        private String _selectedPerson;

        public String SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);   }
        }

        public bool CanClearText() => !string.IsNullOrWhiteSpace(FirstName) || !string.IsNullOrWhiteSpace(LastName); 
        //{
        //    throw new NotImplementedException();
        //}

        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
           
           ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }

    }
}
