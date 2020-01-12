using System;
using System.Security.Cryptography;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Runblade.Experiencer.CSharpBlockchain
{
    public class Transaction
    {
        public string From      { get;  }
        public string To        { get;  }
        public double Amount    { get;  }    
        //Constructor
        public Transaction(string from, string to, double amount)
        {
            From    = from;
            To      = to;
            Amount  = amount;
        }
    }
   
    public class Block
    {
        private readonly DateTime _timeStamp;    
        private long _nonce;    
        public string PreviousHash              { get; set;         }
        public List<Transaction> Transactions   { get; set;         }
        public string Hash                      { get; private set; }
    
        //Genesis Block shouldn't be this easy to create?!
        public Block(DateTime timeStamp, List<Transaction> transactions, string previousHash = "")
        {
            _timeStamp = timeStamp;
            _nonce = 0;        
            Transactions = transactions;
            PreviousHash = previousHash;
            Hash = CreateHash();
        }
        
        public void MineBlock(int proofOfWorkDifficulty)
        {
            string hashValidationTemplate = new String('0', proofOfWorkDifficulty);
            int hashCount = 0;
            while (Hash.Substring(0, proofOfWorkDifficulty) != hashValidationTemplate)
            {
                _nonce++;
                Hash = CreateHash();
                Console.Write("\rAttempt {0} at {1} ({2})", String.Format("{0:n0}", hashCount), DateTime.Now, Hash);
                hashCount++;
            }        
            Console.WriteLine("\nBlock with HASH {0} successfully mined!", Hash);
        }    
        
        public string CreateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string rawData = PreviousHash + _timeStamp + Transactions + _nonce;            
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return BitConverter.ToString(bytes).Replace("-","");
            } 
        }
    }

    public class BlockChain
    {
        private readonly int _proofOfWorkDifficulty;
        private readonly double _miningReward;    
        private List<Transaction> _pendingTransactions;    
        public List<Block> Chain { get; set; }    
        
        public BlockChain(int proofOfWorkDifficulty, double miningReward)
        {
            _proofOfWorkDifficulty = proofOfWorkDifficulty;
            _miningReward = miningReward;
            _pendingTransactions = new List<Transaction>();
            Chain = new List<Block> {CreateGenesisBlock()};
        }    
        
        public void CreateTransaction(Transaction transaction)
        {
            _pendingTransactions.Add(transaction);
        }    
        
        public void MineBlock(string minerAddress) //This should be named differently (similar function name above)
        {
            Transaction minerRewardTransaction = new Transaction(null, minerAddress, _miningReward);
            _pendingTransactions.Add(minerRewardTransaction);        
            Block block = new Block(DateTime.Now, _pendingTransactions);
            block.MineBlock(_proofOfWorkDifficulty);        
            block.PreviousHash = Chain.Last().Hash;
            Chain.Add(block);        
            _pendingTransactions = new List<Transaction>();
        }    
        
        public bool IsValidChain()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block previousBlock = Chain[i - 1];
                Block currentBlock = Chain[i];            
                if (currentBlock.Hash != currentBlock.CreateHash())
                    return false;            
                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }       
            return true;
        }    

        public double GetBalance(string address)
        {
            double balance = 0;        
            foreach (Block block in Chain)
            {
                foreach (Transaction transaction in block.Transactions)
                {
                    if (transaction.From == address)
                    {
                        balance -= transaction.Amount;
                    }                
                    if (transaction.To == address)
                    {
                        balance += transaction.Amount;
                    }
                }
            }        
            return balance;
        }    
        
        //Not sure if Genesis Block creation should be this easy!
        private Block CreateGenesisBlock()
        {
            List<Transaction> transactions = new List<Transaction> {new Transaction("", "", 0)};
            Console.WriteLine("Genesis block created at {0}", DateTime.Now);
            return new Block(DateTime.Now, transactions, "0");
        }

        public void PrintChain(BlockChain blockChain)
        {
            Console.WriteLine("\n----------------- Dumping Blockchain -----------------");
            foreach (Block block in blockChain.Chain)
            {
                Console.WriteLine("------ Start Block ------");
                Console.WriteLine("Hash: {0}", block.Hash);
                Console.WriteLine("Previous Hash: {0}", block.PreviousHash);            
                Console.WriteLine("--- Start Transactions (In This Block) ---");
                foreach (Transaction transaction in block.Transactions)
                {
                    Console.WriteLine("From: {0} To {1} Amount {2}", transaction.From, transaction.To, transaction.Amount);
                }
                Console.WriteLine("--- End Transactions (In This Block) ---");            
                Console.WriteLine("------ End Block ------");
            }
            Console.WriteLine("----------------- End Blockchain -----------------");
        }
    }   
}

    