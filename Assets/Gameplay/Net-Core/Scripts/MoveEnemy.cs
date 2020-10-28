using HGO.ai;
using HGO.core;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class MoveEnemy : StateMachineBehaviour
{
    LevelManager level;
    List<AI_Controller> movingEnemies = new List<AI_Controller>();

    /// <summary>
    /// Struttura che definisce la procedura di movimento per i personaggi
    /// </summary>
    struct MovementProcedure
    {
        internal List<AI_Controller> characters;
        internal Node goalNode;

        public MovementProcedure(AI_Controller character, Node goalNode)
        {
            characters = new List<AI_Controller>();
            characters.Add(character);
            this.goalNode = goalNode;
        }
    }
    List<MovementProcedure> movementProcedures = new List<MovementProcedure>();

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Controlla tutte i personaggi che si devono muovere
        // Verifica i personaggi che si devono muovere su di una stessa cella
        // Verifica le direzioni da cui vengono questi personaggi
        // Se: 2 personaggi da direzioni opposte
        // Se: 3+ personaggi 

        movingEnemies.Clear();
        movementProcedures.Clear();

        if (!level) level = FindObjectOfType<LevelManager>();

        /*Registra i nemici che si devono muovere*/
        foreach(AI_Controller ai in level.levelEnemies)
        {
            if (ai.waitedRound == 1)
            {
                movingEnemies.Add(ai);
                //ai.AI_MOVE();
                //ai.waitedRound = 0;
            }
            else if(ai.behaviour == AI_STATE.PATROL && ai.waitedRound == 0)
            {
                ai.waitedRound += 1;
            }
        }

        if (movingEnemies.Count > 0)
        {
       
            for(int i = 0; i<movingEnemies.Count; i++)
           {
                if (i == 0)
                {
                    movementProcedures.Add(new MovementProcedure(movingEnemies[i], movingEnemies[i].eyes.forwardNode));
                }
                else
                {
                    /* Crea un numero di procedure in base a quanti sono i personaggi che si devono muovere su caselle diverse*/
                    foreach (MovementProcedure mp in movementProcedures)
                    {
                        if (movingEnemies[i].eyes.forwardNode == mp.goalNode)
                        {
                            mp.characters.Add(movingEnemies[i]);
                        }
                        else
                        {
                            movementProcedures.Add(new MovementProcedure(movingEnemies[i], movingEnemies[i].eyes.forwardNode));
                        }
                    }
                }
           }

            foreach (MovementProcedure mp in movementProcedures)
            {
                if (mp.characters.Count <= 1)
                {
                    mp.characters[mp.characters.Count - 1].AI_MOVE();
                }
                else
                {
                    if(mp.characters.Count == 2)
                    {
                        for(int i = 0; i<mp.characters.Count; i++)
                        {
                            mp.characters[i].gameObject.transform.DOMove(mp.goalNode.gameObject.transform.position + (mp.characters[i].gameObject.transform.position - mp.goalNode.gameObject.transform.position).normalized * 1f, 0.25f);
                            mp.characters[i].currentNode = mp.goalNode;
                            mp.characters[i].AI_CHANGE_STATE(AI_STATE.SLEEP);
                        }
                    }
                    else
                    {
                        /* !!! DA COMPLETARE !!! */
                        // se gia ci sono dei nemici sulle celle li sposta nella migliore posizione possibile liberando lo spazio per i nuovi arrivati
                        if(mp.goalNode.nodeData.overlappedEnemies.Count > 0)
                        {
                            int totalEnemies = mp.characters.Count + mp.goalNode.nodeData.overlappedEnemies.Count;
                            float degs = 360f / totalEnemies;

                            Vector3 axis = Vector3.up;
                            List<Vector3> positions = new List<Vector3>();

                            for(int i = 1; i <= totalEnemies; i++)
                            {
                                positions.Add(new Vector3(axis.x * Mathf.Cos(degs * i) - Mathf.Sin(degs * i) * axis.z, axis.y, axis.x * Mathf.Sin(degs * i) + axis.z * Mathf.Cos(degs * i)));
                                //Debug.DrawLine(positions[i], positions[i] + Vector3.up * 5f, Color.red, 3600f);
                            }
                        }
                        else
                        {
                            Debug.Log("movimento di gruppo");

                            int totalEnemies = mp.characters.Count;
                            float degs = 360f / totalEnemies;

                            List<Vector3> positions = new List<Vector3>();

                            Debug.Log($"gradi: {degs}");

                            // Calcola nuove posizioni
                            for (int i = 1; i <= totalEnemies; i++)
                            {
                                var direction = Quaternion.AngleAxis(degs * i, Vector3.up) * (mp.goalNode.gameObject.transform.position + Vector3.forward);
                                positions.Add(mp.goalNode.gameObject.transform.position + direction);
                                //Debug.Log($"direzione: {direction}, positions: {positions[i - 1]}");
                                //Debug.DrawLine(positions[i - 1], positions[i - 1] + Vector3.up * 2f, Color.red, 3600f);
                            }

                            /* Trova nodo piu vicino e muovi il personaggio */
                            for(int i = 0; i < mp.characters.Count; i++)
                            {
                                int index = -1;
                                float lenght = -500;
                                for(int j = 0; j < positions.Count; j++)
                                {
                                    if (j == 0)
                                    {
                                        index = j;
                                        lenght = (positions[j] - mp.characters[i].gameObject.transform.position).magnitude;
                                    }
                                    else
                                    {
                                        if((positions[j] - mp.characters[i].gameObject.transform.position).magnitude < lenght)
                                        {
                                            index = j;
                                            lenght = (positions[j] - mp.characters[i].gameObject.transform.position).magnitude;
                                        }
                                    }

                                    mp.characters[i].gameObject.transform.DOMove(positions[index], 0.25f);
                                    mp.characters[i].eyes.currentNode = mp.goalNode;
                                    //mp.characters[i].eyes.RegisterForwardNode();
                                    mp.characters[i].AI_CHANGE_STATE(AI_STATE.SLEEP);
                                }
                            }
                            
                        }
                        
                    }
                }
            }
           
        }


        animator.SetTrigger("Register Forward Node");
        return;
    }



}