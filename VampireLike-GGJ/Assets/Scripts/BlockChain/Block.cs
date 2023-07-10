using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace BlockChain
{
    public class Block: MonoBehaviour
    {
        // Block position in Blockchain
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

        public void MineBlock(int proofOfWorkDifficulty)
        {
            string hashValidationTemplate = new String('0', proofOfWorkDifficulty);
            
            while (_hash.Substring(0, proofOfWorkDifficulty) != hashValidationTemplate)
            {
                _nonce++;
                _hash = CreateHash();
                // print(_hash);
            }
            Console.WriteLine("Blocked with HASH={0} successfully mined!", _hash);
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
