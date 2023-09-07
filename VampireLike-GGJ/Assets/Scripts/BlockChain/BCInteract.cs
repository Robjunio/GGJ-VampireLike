using System;
using UnityEngine;
using Web3Unity.Scripts.Library.ETHEREUEM.Connect;
using Web3Unity.Scripts.Library.Ethers.Contracts;
using Web3Unity.Scripts.Library.Ethers.Providers;
using Web3Unity.Scripts.Library.Web3Wallet;

public class BCInteract : MonoBehaviour
{
    private async void Start()
    {
        try
        {
            string chainId = "5";
            string abi =
                "[ 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"recordId\", 				\"type\": \"uint256\" 			} 		], 		\"name\": \"AcessInfo\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"anonymous\": false, 		\"inputs\": [ 			{ 				\"indexed\": false, 				\"internalType\": \"uint256\", 				\"name\": \"id\", 				\"type\": \"uint256\" 			}, 			{ 				\"indexed\": false, 				\"internalType\": \"string\", 				\"name\": \"name\", 				\"type\": \"string\" 			}, 			{ 				\"indexed\": false, 				\"internalType\": \"uint256\", 				\"name\": \"points\", 				\"type\": \"uint256\" 			} 		], 		\"name\": \"RecordRegistered\", 		\"type\": \"event\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"registerPlayer\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"string\", 				\"name\": \"name\", 				\"type\": \"string\" 			}, 			{ 				\"internalType\": \"uint256\", 				\"name\": \"points\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"string\", 				\"name\": \"timeSpend\", 				\"type\": \"string\" 			}, 			{ 				\"internalType\": \"uint256\", 				\"name\": \"enemysKilled\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"string\", 				\"name\": \"abilityPlayerHas\", 				\"type\": \"string\" 			}, 			{ 				\"internalType\": \"address[]\", 				\"name\": \"adresses\", 				\"type\": \"address[]\" 			} 		], 		\"name\": \"registerRecord\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"name\": \"Records\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"id\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"address\", 				\"name\": \"owner\", 				\"type\": \"address\" 			}, 			{ 				\"internalType\": \"string\", 				\"name\": \"ownerName\", 				\"type\": \"string\" 			}, 			{ 				\"internalType\": \"uint256\", 				\"name\": \"points\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"string\", 				\"name\": \"timeSpend\", 				\"type\": \"string\" 			}, 			{ 				\"internalType\": \"uint256\", 				\"name\": \"enemysKilled\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"string\", 				\"name\": \"habilityList\", 				\"type\": \"string\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"address\", 				\"name\": \"\", 				\"type\": \"address\" 			} 		], 		\"name\": \"registeredPlayers\", 		\"outputs\": [ 			{ 				\"internalType\": \"bool\", 				\"name\": \"\", 				\"type\": \"bool\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"totalRecords\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	} ]";
            // address of contract
            string contractAddress = "0x7A1c4322ecA7454A687324e51CC3657E989C873a";
            string method = "registerPlayer";
            // you can use this to create a provider for hardcoding and parse this instead of rpc get instance
            var provider = new JsonRpcProvider("https://rpc.ankr.com/eth_goerli");
            var contract = new Contract(abi, contractAddress, provider);
            
            Debug.Log("Contract: " + contract);

            var calldata = contract.Calldata(method, new object[] { });

            // send transaction
            string response = await Web3Wallet.SendTransaction(chainId, contractAddress, "0", calldata, "", "");
            // display response in game
            print("Please check the contract variable again in a few seconds once the chain has processed the request!");
        }
        catch (Exception e)
        {
            print(e);
        }
    }
}
