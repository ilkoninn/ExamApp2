using App2.Business.ViewModels.CommonVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Business.ViewModels.ServiceVMs
{
    public class UpdateServiceVM : BaseEntityVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
