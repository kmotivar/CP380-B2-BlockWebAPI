using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;

namespace CP380_B2_BlockWebAPI.Services
{
    public class BlockListService
    {
        private BlockList _blockList;
        private PendingPayloadsList _payloads;
        private readonly IConfiguration _configure;
        private readonly JsonSerializerOptions _config = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        public BlockListService(IConfiguration configuration, BlockList blockList, PendingPayloadsList pendingPayloads)
        {
            _blockList = blockList;
            _payloads = pendingPayloads;
            _configure = configuration;
        }
        public Block SubmitNewBlock(string hash, int nonce, DateTime timestamp)
        {

            Block block = new Block(timestamp, _blockList.Chain[_blockList.Chain.Count - 1].Hash, _payloads.payloads);
            block.CalculateHash();  
            if (block.Hash == hash)
            {
                _blockList.Chain.Add(block);   
                _payloads.removePPs(); 
                return block;
            }
            return null;
        }
    }
}