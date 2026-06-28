using Microsoft.Xrm.Sdk;
using System;

namespace plugins
{
    public class WinValidationPlugin : PluginBase
    {
        public WinValidationPlugin(string unsecureConfiguration, string secureConfiguration)
            : base(typeof(WinValidationPlugin))
        {
        }

        // Entry point for custom business logic execution
        protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            var context = localPluginContext.PluginExecutionContext;

            //Only act when there's a target entity to check
            if(context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity win)
            {
                //Read the Outcome field from teh incoming record
                string outcome = win.GetAttributeValue<string>("hf_outcome");

                //Integrity rule: a win must have an outcome
                if (string.IsNullOrWhiteSpace(outcome))
                {
                    throw new InvalidPluginExecutionException(
                        "Add an outcome before saving - a win isn't a win " + "until you've captured the result it produced");
                }
                
            }
        }
    }
}
