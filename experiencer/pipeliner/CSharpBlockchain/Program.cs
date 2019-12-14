﻿using System;
using System.Collections.Generic;

namespace CSharpBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Beginning blockchain run...");

            //Set up mining and user addresses (can be modified for non-"coin" uses)            
            const string minerAddress = "miner1";
            const string user1Address = "A";
            const string user2Address = "B";       

            //Create the blockchain (genesis)
            BlockChain blockChain = new BlockChain(proofOfWorkDifficulty: 5, miningReward: 10);
            blockChain.CreateTransaction(new Transaction(user1Address, user2Address, 200));
            blockChain.CreateTransaction(new Transaction(user2Address, user1Address, 10));
            Console.WriteLine("Is valid: {0}", blockChain.IsValidChain());
            
            //Mining test 1
            Console.WriteLine("--------- Start mining ---------");
            blockChain.MineBlock(minerAddress);        
            Console.WriteLine("BALANCE of the miner: {0}", blockChain.GetBalance(minerAddress));

            //Mining test 2
            blockChain.CreateTransaction(new Transaction(user1Address, user2Address, 5));        
            Console.WriteLine("--------- Start mining ---------");
            blockChain.MineBlock(minerAddress);        
            Console.WriteLine("BALANCE of the miner: {0}", blockChain.GetBalance(minerAddress));        
            
            //Output entire blockchain
            PrintChain(blockChain);       
            
            //Test hack of blockchain
            Console.WriteLine("Hacking the blockchain...");
            blockChain.Chain[1].Transactions = new List<Transaction> { new Transaction(user1Address, minerAddress, 150)};
            Console.WriteLine("Is valid: {0}", blockChain.IsValidChain());        
        }

         private static void PrintChain(BlockChain blockChain)
        {
            Console.WriteLine("----------------- Start Blockchain -----------------");
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