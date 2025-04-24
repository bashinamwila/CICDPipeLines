using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDPipeLines.BusinessLibrary
{
    [Serializable]
    public class Person :BusinessBase<Person>
    {
        public static readonly PropertyInfo<string> EmployeeIdProperty =
            RegisterProperty<string>(nameof(EmployeeId));
        public string EmployeeId
        {
            get => GetProperty(EmployeeIdProperty);
            set=>SetProperty(EmployeeIdProperty, value);
        }

        public static readonly PropertyInfo<string> FirstNameProperty =
            RegisterProperty<string>(nameof(FirstName));
        public string FirstName
        {
            get => GetProperty(FirstNameProperty);
            set => SetProperty(FirstNameProperty, value);
        }

        public static readonly PropertyInfo<string> LastNameProperty =
           RegisterProperty<string>(nameof(LastName));
        public string LastName
        {
            get => GetProperty(LastNameProperty);
            set => SetProperty(LastNameProperty, value);
        }

        public static readonly PropertyInfo<string> FullNameProperty =
           RegisterProperty<string>(nameof(FullName));
        public string FullName
        {
            get => GetProperty(FullNameProperty);
            private set => LoadProperty(FullNameProperty, value);
        }

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
            BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(FirstNameProperty));
            BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(LastNameProperty));
            BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(EmployeeIdProperty));
            BusinessRules.AddRule(new CICDPipeLines.BusinessLibrary.Rules.FullNameRule(FirstNameProperty,FullNameProperty));
            BusinessRules.AddRule(new CICDPipeLines.BusinessLibrary.Rules.FullNameRule(LastNameProperty, FullNameProperty));
        }

        [Create]
        private void Create()
        {
            BusinessRules.CheckRules();
        }
    }

    
}
