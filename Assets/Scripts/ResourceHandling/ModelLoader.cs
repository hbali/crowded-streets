using GameLogic.GroupHandling.Individual;
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
        internal static T LoadModel<T>(string type)
        {
            string path = ResourcePaths.ModelPath(type);
            GameObject original = Resources.Load<GameObject>(path);
            return GameObject.Instantiate(original).GetComponent<T>();
        }
    }
}
