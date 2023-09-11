using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Web3Unity.Scripts.Library.ETHEREUEM.Connect;
using Web3Unity.Scripts.Library.Ethers.Contracts;
using Web3Unity.Scripts.Library.Ethers.Providers;
using Web3Unity.Scripts.Library.Web3Wallet;

public class BCInteract : MonoBehaviour
{
    public static BCInteract Instance;
    private static Contract contract;
    private JsonRpcProvider provider;
    private static string contractAddress;
    private string abi;
    private static string chainId;
    
    private void Awake()
    {
        if (FindObjectsOfType<BCInteract>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
                
            Instance = this;
        }
    }
    private async void Start()
    {
        try
        {
            chainId = "5";
            abi =
                "[ 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"recordId\", 				\"type\": \"uint256\" 			} 		], 		\"name\": \"AcessInfo\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"anonymous\": false, 		\"inputs\": [ 			{ 				\"indexed\": false, 				\"internalType\": \"uint256\", 				\"name\": \"id\", 				\"type\": \"uint256\" 			}, 			{ 				\"indexed\": false, 				\"internalType\": \"string\", 				\"name\": \"name\", 				\"type\": \"string\" 			}, 			{ 				\"indexed\": false, 				\"internalType\": \"uint256\", 				\"name\": \"points\", 				\"type\": \"uint256\" 			} 		], 		\"name\": \"RecordRegistered\", 		\"type\": \"event\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"registerPlayer\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"string\", 				\"name\": \"name\", 				\"type\": \"string\" 			}, 			{ 				\"internalType\": \"uint256\", 				\"name\": \"points\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"string\", 				\"name\": \"timeSpend\", 				\"type\": \"string\" 			}, 			{ 				\"internalType\": \"uint256\", 				\"name\": \"enemysKilled\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"string\", 				\"name\": \"abilityPlayerHas\", 				\"type\": \"string\" 			}, 			{ 				\"internalType\": \"address[]\", 				\"name\": \"adresses\", 				\"type\": \"address[]\" 			} 		], 		\"name\": \"registerRecord\", 		\"outputs\": [], 		\"stateMutability\": \"nonpayable\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"name\": \"Records\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"id\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"address\", 				\"name\": \"owner\", 				\"type\": \"address\" 			}, 			{ 				\"internalType\": \"string\", 				\"name\": \"ownerName\", 				\"type\": \"string\" 			}, 			{ 				\"internalType\": \"uint256\", 				\"name\": \"points\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"string\", 				\"name\": \"timeSpend\", 				\"type\": \"string\" 			}, 			{ 				\"internalType\": \"uint256\", 				\"name\": \"enemysKilled\", 				\"type\": \"uint256\" 			}, 			{ 				\"internalType\": \"string\", 				\"name\": \"habilityList\", 				\"type\": \"string\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [ 			{ 				\"internalType\": \"address\", 				\"name\": \"\", 				\"type\": \"address\" 			} 		], 		\"name\": \"registeredPlayers\", 		\"outputs\": [ 			{ 				\"internalType\": \"bool\", 				\"name\": \"\", 				\"type\": \"bool\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	}, 	{ 		\"inputs\": [], 		\"name\": \"totalRecords\", 		\"outputs\": [ 			{ 				\"internalType\": \"uint256\", 				\"name\": \"\", 				\"type\": \"uint256\" 			} 		], 		\"stateMutability\": \"view\", 		\"type\": \"function\" 	} ]";
            
            // address of contract
            contractAddress = "0x6822f7D79756CbC20E236865C5484F1130489300";
            
            // you can use this to create a provider for hardcoding and parse this instead of rpc get instance
            provider = new JsonRpcProvider("https://rpc.ankr.com/eth_goerli");
            
            contract = new Contract(abi, contractAddress, provider);
            
            string method = "registerPlayer";
            
            Debug.Log("Contract: " + contract);

            var calldata = contract.Calldata(method, new object[] { });

            bool playerRegister = await GetPlayerRegister();

            if (!playerRegister)
            {
                // send transaction
                string response = await Web3Wallet.SendTransaction(chainId, contractAddress, "0", calldata, "", "");
            
                // display response in game
                print("Please check the contract variable again in a few seconds once the chain has processed the request!");
            }
        }
        catch (Exception e)
        {
            print(e);
        }
    }

    public async void RegisterPlayerSkills(string playerName, int points, string playerSkills, string timeSpent , int enemiesKilled)
    {
        string method = "registerRecord";

        try
        {
            var data = contract.Calldata(method, new object[]
            {
                playerName,
                points,
                timeSpent,
                enemiesKilled,
                playerSkills,
                new List<String>()
            });
            
            Debug.Log("Data: " + data);

            string response = await Web3Wallet.SendTransaction(chainId, contractAddress, "0", data, "", "");

            Debug.Log("Resposta do RegisterPlayerSkills:\n\n" + response);
        }
        
        catch (Exception e)
        {
            print(e);
        }
    }

    public async Task<bool> GetPlayerRegister()
    {
        string method = "registeredPlayers";
        try
        {
            var response = await contract.Call(method, new object[]
            {
                PlayerPrefs.GetString("Account")
            });

            return response[0].ToString() == "True";
        }
        catch (Exception e)
        {
            print(e);
        }

        return false;
    }

    public async Task<int> GetTotalRecord()
    {
        string method = "totalRecords";
        try
        {
            var response = await contract.Call(method, new object[]
            {
                
            });

            return int.Parse(response[0].ToString());
        }
        catch (Exception e)
        {
            print(e);
        }

        return 0;
    }

    public async Task<object[]> GetRecord(int id)
    {
        string method = "Records";
        try
        {
            var response = await contract.Call(method, new object[]
            {
                id
            });

            return response;
        }
        catch (Exception e)
        {
            print(e);
        }

        return null;
    }
    
    public async Task GetAcess(int id)
    {
        string method = "AcessInfo";
        try
        {
            var data = contract.Calldata(method, new object[]
            {
                id
            });

            string response = await Web3Wallet.SendTransaction(chainId, contractAddress, "0", data, "", "");
        }
        catch (Exception e)
        {
            print(e);
        }
    }

    public Contract GetContract()
    {
        return contract;
    }
}
