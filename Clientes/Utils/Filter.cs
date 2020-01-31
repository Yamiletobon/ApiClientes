using Clientes.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Clientes.Utils
{
	public class Filter : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			//var algo = context.ActionDescriptor["ActionName"];

			if (!context.ModelState.IsValid)
			{
				var errors = "Modelo Invalido: ";
				foreach (var state in context.ModelState)
				{
					foreach (var error in state.Value.Errors)
					{
						errors += error.ErrorMessage + "" + ", ";
					}
				}


				var Result = new BadRequestObjectResult(new Error()
				{
					codigoError = "2101",
					descripcionError = errors,
				});
				context.Result = Result;

			}

		}
	}
}
