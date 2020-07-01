using System;
using $ext_CommonProj$;

namespace $safeprojectname$
{
    internal class $ext_Wizard_CallbackImplClass$ : $ext_Wizard_CallbackContract$
    {
        public void Reply(string msgFromService)
        {
            Console.WriteLine($"\tOperation '{nameof(Reply)}' was called with message '{msgFromService}'.");
        }
    }
}
