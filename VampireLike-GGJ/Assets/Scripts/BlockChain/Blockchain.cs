using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockChain
{
    public class Blockchain
    {
        private readonly int _proofOfWorkDifficulty;
        public List<Block> Chain;
        
        public Blockchain(int proofOfWorkDifficulty)
        {
            _proofOfWorkDifficulty = proofOfWorkDifficulty;
            var genesis = CreateGenesisBlock();
            genesis.MineBlock(_proofOfWorkDifficulty);
            Chain = new List<Block> {genesis};
        }
        public void AddNewBlock(string data)
        {
            //int index, long timestamp, string previousHash, string data
            var lastBlock = getLastBlock();
            Block block = new Block(lastBlock.getIndex() + 1, DateTime.Now, lastBlock.getHash(), data);
            block.MineBlock(_proofOfWorkDifficulty);
            Chain.Add(block);
        }
        public bool IsValidChain()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block previousBlock = Chain[i - 1];
                Block currentBlock = Chain[i];
                if (currentBlock.getHash() != currentBlock.CreateHash())
                    return false;
                if (currentBlock.getPreviousHash() != previousBlock.getHash())
                    return false;
            }
            return true;
        }
        
        private Block CreateGenesisBlock()
        {
            return new Block(0, DateTime.Now, null, "Genesis");
        }

        private Block getLastBlock()
        {
            return Chain.Last();
        }
    }
}
