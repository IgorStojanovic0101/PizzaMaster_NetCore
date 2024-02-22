using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Infrastructure.System
{
    public class FromBodyByDefaultConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            var post = IsHttpPost(action);
            foreach (var parameter in action.Parameters)
            {
                if (parameter.BindingInfo is null)
                    parameter.BindingInfo = new BindingInfo();


                parameter.BindingInfo.BindingSource = BindingSource.Body;

            }
        }
        private bool IsHttpPost(ActionModel action)
        {
            return action.Attributes.Any(attr => attr is HttpPostAttribute);
        }

    }
}
