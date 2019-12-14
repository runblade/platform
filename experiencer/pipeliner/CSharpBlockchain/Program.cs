﻿using System;
using System.Collections.Generic;

namespace CSharpBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------\n");
            Console.WriteLine("Beginning blockchain run...\n");

            //Set up mining and user addresses (can be modified for non-"coin" uses)            
            const string minerAddress = "miner1";
            const string user1Address = "A";
            const string user2Address = "B";       
            //Important "global" variables
            const int    _proofOfWorkDifficulty = 6;
            const double _miningReward = 0.5;

            //Create the blockchain (genesis)
            Console.WriteLine("Creating genesis block, PoW: {0}, Reward: {1}", _proofOfWorkDifficulty, _miningReward);
            BlockChain blockChain = new BlockChain(proofOfWorkDifficulty: _proofOfWorkDifficulty, miningReward: _miningReward);
            blockChain.CreateTransaction(new Transaction(user1Address, user2Address, 200));
            blockChain.CreateTransaction(new Transaction(user2Address, user1Address, 10));
            Console.WriteLine("[Genesis block] Is valid: {0}\n", blockChain.IsValidChain());
            
            //Mining test 1
            Console.WriteLine("--------- Start mining ---------");
            blockChain.MineBlock(minerAddress);        
            Console.WriteLine("BALANCE of the miner: {0}\n", blockChain.GetBalance(minerAddress));

            //Mining test 2
            blockChain.CreateTransaction(new Transaction(user1Address, user2Address, 5));        
            Console.WriteLine("--------- Start mining ---------");
            blockChain.MineBlock(minerAddress);        
            Console.WriteLine("BALANCE of the miner: {0}\n", blockChain.GetBalance(minerAddress));        
            
            //Output entire blockchain
            PrintChain(blockChain);       
            
            //Test hack of blockchain
            Console.WriteLine("Hacking the blockchain...");
            blockChain.Chain[1].Transactions = new List<Transaction> { new Transaction(user1Address, minerAddress, 150)};
            Console.WriteLine("Is valid: {0}\n", blockChain.IsValidChain());        
        }

         private static void PrintChain(BlockChain blockChain)
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