using GameLogic.GroupHandling.Individual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Extensions
{
    static class TransformExtensions
    {
        public static Actor Actor(this Transform cld) => cld.GetComponent<Actor>();
    }
}
