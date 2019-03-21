using BilgeAdam.Core.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.Core.Core.Entity
{
    public class CoreEntity:IEntity<Guid>
    {
        public Guid ID { get; set; }
        public Status Status { get; set; }

        
        
        //  Ekleme anı logları
        public string CreatedComputerName { get; set; }
        public string CreatedIp { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedADUserName { get; set; }


        //Güncelleme anı logları
        public string ModifiedComputerName { get; set; }
        public string ModifiedIp { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedADUserName { get; set; }
    }
}
