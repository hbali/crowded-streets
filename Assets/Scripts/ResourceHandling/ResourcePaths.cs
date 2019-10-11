using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceHandling
{
    static class ResourcePaths
    {
        public static string ModelPath(string type)
        {
            return "Models/" + type;
        }
    }
}
