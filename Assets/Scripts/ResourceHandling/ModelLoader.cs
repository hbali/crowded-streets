using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ResourceHandling
{
    static class ModelLoader
    {
        public static Transform LoadModel(string type)
        {
            string path = ResourcePaths.ModelPath(type);
            GameObject original = Resources.Load<GameObject>(path);
            Transform tr = GameObject.Instantiate(original).transform;
            return tr;
        }
    }
}
