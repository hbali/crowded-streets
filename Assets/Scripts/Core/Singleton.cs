using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    class Singleton<T>
    {
        private static T instance;
        
        public static T Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = Activator.CreateInstance<T>();
                }
                return instance;
            }
        }
    }
}
