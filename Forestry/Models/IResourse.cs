using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Forestry.Requestors;
using Newtonsoft.Json;

namespace Forestry.Models
{
    //https://stackoverflow.com/questions/1344694/implement-an-interface-with-generic-methods
    public interface IResourse<T> where T : class
    {
        T Get(Uri uri);
        HttpResponseMessage Post(Uri uri, object obj);
        HttpResponseMessage Put(Uri uri, object obj);
    }
}
