using System;
using UnityEngine;

namespace BlockChain
{
    public class ChainManager : MonoBehaviour
    {
        public static ChainManager Instance;
        private Blockchain BloodChain;
        private void Awake()
        {
            if (FindObjectsOfType<ChainManager>().Length > 1)
            {
                // This avoid the creation of multiple instances of this same game object.
                Destroy(gameObject);
            }
            else
            {
                // Make this object persist between scenes.
                DontDestroyOnLoad(gameObject);
                
                // Creation of the chain.
                BloodChain = new Blockchain(1);
                Instance = this;
            }
        }

        public void AddNewRecord(string Data)
        {
            if (BloodChain.IsValidChain())
            {
                BloodChain.AddNewBlock(Data);
            }
            debug();
        }

        public Blockchain getChain()
        {
            return BloodChain;
        }

        private void debug()
        {
            var count = BloodChain.Chain.Count;
            print(count);
            for (int i = 0; i < count; i++)
            {
                print(BloodChain.Chain[i].getData());
            }
        }
    }
}
