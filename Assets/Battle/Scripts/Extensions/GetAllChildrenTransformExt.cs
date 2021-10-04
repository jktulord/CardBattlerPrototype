using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class GetAllChildrenTransformExt
    {
        public static List<Transform> GetAllChildren(this Transform transform)
        {
            List<Transform> children = new List<Transform>();

            for (int i = 0; i < transform.childCount; i++)
            {
                children.Add(transform.GetChild(i));
            }

            return children;
        }
    }
}
