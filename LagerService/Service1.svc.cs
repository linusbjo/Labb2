﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LagerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Vara> GetListVara()
        {
            // Creates a list of table "Vara" and returns it
            List<Vara> VaraList = new List<Vara>();
            LagerServiceDatabaseEntityDataModel db = new LagerServiceDatabaseEntityDataModel();

            VaraList = db.Vara.ToList();
            return VaraList;
        }
    }
}
