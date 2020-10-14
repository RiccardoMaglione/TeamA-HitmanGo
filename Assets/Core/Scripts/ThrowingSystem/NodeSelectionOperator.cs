using HGO.core.data;
using UnityEngine;

namespace HGO
{
    namespace core
    {
        public static class NodeSelectionOperator
        {

            public enum nodeTypeOperation { ALL, ITEM, WALKABLE}
            public static NodeSelectionOperation CreateNodeSelectionOperator(nodeTypeOperation type, ThrowingData data, Vector3 origin, Node start_node)
            {
                return new NodeSelectionOperation(data, origin, type, start_node);
            }


        }
    }
}