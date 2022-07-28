using Infrastructure.Abstract;
using Infrastructure.Repository;
using ModelsAndUtility.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Factory
{
    public class ContentManagerFactory
    {
        public IContent GetObjInstance(int CSID)
        {
            IContent obj = null;

            if (CSID == 0)
            {
                obj = new AddContent();
            }
            else if (CSID > 0)
            {
                obj = new ModifyContent();
            }

            return obj;
        }
    }
}
