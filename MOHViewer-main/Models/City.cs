using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace MOHViewer.Models
{
    internal class City : BindableBase
    {

        [JsonProperty("שם_ישוב")]
        //public string name { get; set; }
        private string _name;

        public string name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }


    }
}
