using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BlockChain
{
    public class Block: MonoBehaviour
    {
        private int _index;
        // Date and time that the block has been created
        private DateTime _timestamp;
        // Information that the block has
        private string _data;
        // Difficulty value to mine
        private int _nonce;
        // block hash
        private string _hash;
        // previous block hash
        public string _previousHash;
        
        public Block(int index, DateTime timestamp, string previousHash, string data) {
            this._index = index;
            this._timestamp = timestamp;
            this._previousHash = previousHash;
            this._data = data;
            _nonce = 0;
            _hash = CreateHash();
        }

        public int getIndex() {
            return _index;
        }

        public DateTime getTimestamp() {
            return _timestamp;
        }

        public string getHash() {
            return _hash;
        }

        public string getPreviousHash() {
            return _previousHash;
        }

        public string getData() {
            return _data;
        }

        private string str() {
            return _index + _timestamp.ToString() + _previousHash + _data + _nonce;
        }

        public async Task MineBlockAsync(int proofOfWorkDifficulty)
        {
            string hashValidationTemplate = new String('0', proofOfWorkDifficulty);

            while (_hash.Substring(0, proofOfWorkDifficulty) != hashValidationTemplate)
            {
                _nonce++;
                _hash = CreateHash();
                Debug.Log(_hash + " Nonce -> " + _nonce);
                await Task.Yield(); // Aguarda uma pausa no processamento assíncrono
            }

            // Debug.Log(_hash + " " + _nonce);
            FindObjectOfType<ChainManager>().DisablePickaxe();
            Debug.Log("Bloco com HASH minerado com sucesso! -> " +  _hash + " / Proof -> " + proofOfWorkDifficulty);
        }


        public string CreateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string rawData = str();
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return Encoding.Default.GetString(bytes);
            } 
        }
        
    }
}
