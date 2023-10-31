using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            genesis.MineBlockAsync(_proofOfWorkDifficulty);
            Chain = new List<Block> {genesis};
        }

        public async Task AddNewBlockAsync(string data)
        {
            var lastBlock = getLastBlock();
            Block block = new Block(lastBlock.getIndex() + 1, DateTime.Now, lastBlock.getHash(), data);
            await block.MineBlockAsync(_proofOfWorkDifficulty);
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
