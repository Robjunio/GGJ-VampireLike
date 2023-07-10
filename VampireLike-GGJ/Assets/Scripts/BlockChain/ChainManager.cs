using System;
using System.Threading.Tasks;
using UnityEngine;

namespace BlockChain
{
    public class ChainManager : MonoBehaviour
    {
        public static ChainManager Instance;
        private Blockchain _bloodChain;

        private async void Awake()
        {
            if (FindObjectsOfType<ChainManager>().Length > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
                
                _bloodChain = new Blockchain(1);
                Instance = this;
            }

            await InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await Task.Delay(1000);

            // TODO
        }

        public async void AddNewRecord(string data)
        {
            if (_bloodChain.IsValidChain())
            {
                await AddNewBlockAsync(data);
            }

            await DebugAsync();
        }

        private async Task AddNewBlockAsync(string data)
        {
            await Task.Delay(1000);

            _bloodChain.AddNewBlock(data);
        }

        public Blockchain GetChain()
        {
            return _bloodChain;
        }

        private async Task DebugAsync()
        {
            await Task.Delay(1000);

            var count = _bloodChain.Chain.Count;
            // Debug.Log(count);
            
            for (int i = 0; i < count; i++)
            {
                Debug.Log(_bloodChain.Chain[i].getData());
            }
            
        }
    }
}
