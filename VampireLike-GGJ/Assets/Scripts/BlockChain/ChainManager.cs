using System;
using System.Threading.Tasks;
using UnityEngine;

namespace BlockChain
{
    public class ChainManager : MonoBehaviour
    {
        public static ChainManager Instance;
        private Blockchain _bloodChain;

        [SerializeField] private GameObject pickaxe;

        private async void Awake()
        {
            if (FindObjectsOfType<ChainManager>().Length > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
                
                Instance = this;
            }

            await InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await Task.Delay(1000);

            _bloodChain = new Blockchain(1);
        }

        public async void AddNewRecord(string data)
        {
            if (_bloodChain.IsValidChain())
            {
                Debug.Log("Adicionando um novo Bloco na cadeia!");
                EnablePickaxe();
                GameObject.FindObjectOfType<SceneManager>().LoadScene("Menu");
                await AddNewBlockAsync(data);
            }

            await DebugAsync();
        }

        private async Task AddNewBlockAsync(string data)
        {
            await Task.Delay(1000);

            await _bloodChain.AddNewBlockAsync(data);
        }

        public Blockchain GetChain()
        {
            return _bloodChain;
        }

        private async Task DebugAsync()
        {
            await Task.Delay(1000);

            var count = _bloodChain.Chain.Count;
            Debug.Log(count); // Number of blocks in the chain
            
            for (int i = 0; i < count; i++)
            {
                Debug.Log(_bloodChain.Chain[i].getData()); // Print all blocks data
            }
        }
        
        public void EnablePickaxe()
        {
            pickaxe.SetActive(true);
        }

        public void DisablePickaxe()
        {
            pickaxe.SetActive(false);
        }

    }
}
