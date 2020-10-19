using HGO.core.data;
using UnityEngine;

namespace HGO
{
    namespace core
    {
        public class ThrowingItem : core.Item
        {
            public readonly string prefab;
            public readonly string data;

            public ThrowingItem()
            {
                prefab = "Prefabs/Items/Default_ThrowingItem";
                data = "DATA/ThrowingSystem/ThrowData";
            }
        }
    }
}