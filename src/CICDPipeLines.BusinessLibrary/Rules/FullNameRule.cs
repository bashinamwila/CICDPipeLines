using Csla.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICDPipeLines.BusinessLibrary.Rules
{
    public class FullNameRule :
        BusinessRule
    {
        public FullNameRule(Csla.Core.IPropertyInfo primaryProperty,
            Csla.Core.IPropertyInfo affectedProperty)
            : base(primaryProperty)
        {
            InputProperties.AddRange(new[] { primaryProperty,affectedProperty });
            AffectedProperties.Add(affectedProperty);
        }
#pragma warning disable CSLA0017
        protected override void Execute(IRuleContext context)
        {
            var target=(Person)context.Target;
            var firstName = target.FirstName;
            var lastName = target.LastName;

            LoadProperty(target, AffectedProperties[1], firstName + " " + lastName);
#pragma warning restore CSLA0017  


        }
    }
}
