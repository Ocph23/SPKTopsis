using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using TopsisLIB.Helpers;

namespace TopsisLIB.Models 
{ 
     [TableName("producent")] 
     public class producent : BaseNotifyProperty
    {
          [PrimaryKey("IdProducent")] 
          [DbColumn("IdProducent")] 
          public int Id 
          { 
               get{return _id;} 
               set{ 
                      _id=value; 
                     OnPropertyChange("IdProducent");
                     }
          } 

          [DbColumn("Name")] 
          public string Name 
          { 
               get{return _name;} 
               set{ 
                      _name=value; 
                     OnPropertyChange("Name");
                     }
          } 

          [DbColumn("Description")] 
          public string Description 
          { 
               get{return _description;} 
               set{ 
                      _description=value; 
                     OnPropertyChange("Description");
                     }
          } 

          private int  _id;
           private string  _name;
           private string  _description;
      }
}


