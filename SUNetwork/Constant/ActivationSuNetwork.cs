using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUNetwork.Constant
{

    public class ActivationSuNetwork : Attribute
    {
        public ActivationSuNetwork()
        {
            bool isValid = false;

            isValid = Constants.Constants.USER_INFOS.USERS.STATUS_CODE == "W";
            if (isValid)
            {
               
            }
        }
    }
}