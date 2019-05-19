using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Interfaces
{
    public interface IModel
    {
        System.Reflection.PropertyInfo[] GetInfoProperties();
    }
}
