using HGO.ai;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HGO
{
    namespace core
    {
        public class LevelManager : MonoBehaviour
        {
            internal List<Node> levelNodes = new List<Node>();
            internal List<AI_Controller> levelEnemies = new List<AI_Controller>();
            internal ThrowingSystemManager ThrowingSystemManager = new ThrowingSystemManager();

            struct  characterData
            {
                public PlayerController controller;
                public Node currentNode;
                public Vector3 position;
                public Vector3 scale;
                public Quaternion rotation;
            }
            characterData playerData = new characterData();
            struct AI_DATA
            {
                public AI_Controller controller;
                public Node currentNode;
                public Node forwardNode;
                public Vector3 position;
                public Vector3 scale;
                public Quaternion rotation;
                
            }
            List<AI_DATA> enemiesData = new List<AI_DATA>();

            #region UnityCallback
            private void Awake()
            {
                levelNodes = FindObjectsOfType<Node>().ToList();
                levelEnemies = FindObjectsOfType<AI_Controller>().ToList();
                #region breakpoint

                if (levelNodes.Count < 1)
                {
                    Debug.LogError("Attention! LevelManager.Awake(): can't initialize node list");
                }


                #endregion

                /* STORAGE LEVEL DATA */
                foreach(AI_Controller ai in levelEnemies)
                {
                    SaveData(ai);
                }

                SaveData(FindObjectOfType<PlayerController>());

            }
            #endregion

            void SaveData(AI_Controller ai)
            {
                var data = new AI_DATA();

                data.controller = ai;
                data.currentNode = data.controller.eyes.currentNode;
                data.forwardNode = data.controller.eyes.forwardNode;
                data.position = data.controller.gameObject.transform.position;
                data.rotation = data.controller.gameObject.transform.rotation;
                data.scale = data.controller.gameObject.transform.localScale;

                enemiesData.Add(data);
            }
            void SaveData(PlayerController pc)
            {
                var data = new characterData();
                data.controller = pc;
                data.currentNode = pc.currentNode;
                data.position = pc.gameObject.transform.position;
                data.rotation = pc.gameObject.transform.rotation;
                data.scale = pc.gameObject.transform.localScale;

                playerData = data;
            }


            /// <summary>
            /// Ripristina i parametri di livello ai valori iniziali
            /// </summary>
            public void ResetLevel()
            {
                for(int i = 0; i < enemiesData.Count; i++)
                {
                    levelEnemies[i].gameObject.transform.position =             enemiesData[i].position;
                    levelEnemies[i].gameObject.transform.rotation =             enemiesData[i].rotation;
                    levelEnemies[i].gameObject.transform.localScale =           enemiesData[i].scale;
                    levelEnemies[i].eyes.currentNode =                          enemiesData[i].currentNode;
                    levelEnemies[i].eyes.forwardNode =                          enemiesData[i].forwardNode;

                    levelEnemies[i].AI_CHANGE_STATE(AI_STATE.SLEEP);
                }

                var pc = FindObjectOfType<PlayerController>();
                pc.gameObject.transform.position =                              playerData.position;
                pc.gameObject.transform.rotation =                              playerData.rotation;
                pc.gameObject.transform.localScale =                            playerData.scale;
                pc.movementComponent.currentNode =                              playerData.currentNode;
                pc.currentNode =                                                playerData.currentNode;

                var itemsNodes = FindObjectsOfType<ItemNode>();
                foreach(ItemNode im in itemsNodes)
                {
                    im.Enable();
                }

                ThrowingSystemManager.enemiesNoised.Clear();
                ThrowingSystemManager.UnregisterNode();
            }

        }
    }
}
