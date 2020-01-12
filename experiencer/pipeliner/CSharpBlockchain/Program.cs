﻿using System;
using System.Collections.Generic;

namespace Runblade.Experiencer.CSharpBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------\n");
            Console.WriteLine("Beginning blockchain run...\n");

            //Minor sanity check
            if (args.Length < 1) 
            {
                Console.WriteLine("Oops! Please provide PoW Difficulty as parameter!\n"); 
                return;
            }

            //Set up mining and user addresses (can be modified for non-"coin" uses)
            const string minerAddress = "miner1";
            const string user1Address = "A";
            const string user2Address = "B";       
            //Important "global" variables
            int _proofOfWorkDifficulty = Int32.Parse(args[0]);
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
            //Output entire blockchain - need to clean up function (why is it passing itself as parameter?)
            blockChain.PrintChain(blockChain);       
            
            //Test hack of blockchain
            Console.WriteLine("Hacking the blockchain...");
            blockChain.Chain[1].Transactions = new List<Transaction> { new Transaction(user1Address, minerAddress, 150)};
            Console.WriteLine("Is valid: {0}\n", blockChain.IsValidChain());        
        }
    }
}