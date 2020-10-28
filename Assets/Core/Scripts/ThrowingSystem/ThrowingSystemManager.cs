using HGO.ai;
using HGO.core;
using System.Collections.Generic;

public class ThrowingSystemManager
{
    /// <summary>
    /// Il nodo dove deve essere lanciato un'oggetto
    /// </summary>
    public Node selectedNode { private set; get; }
    /// <summary>
    /// Una lista di nemici che ha sentito un rumore
    /// </summary>
    internal List<AI_Controller> enemiesNoised = new List<AI_Controller>();

    public ThrowingSystemManager()
    {

    }
    /// <summary>
    /// Registra il nodo dove deve essere lancia un'oggetto
    /// </summary>
    /// <param name="n"></param>
    public void RegisterNode(ref Node n)
    {
        selectedNode = n;
    }
    public void UnregisterNode()
    {
        selectedNode = null;
    }
 
}
