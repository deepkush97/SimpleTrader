using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        //!ApiKey : 93a0f0fa22a30a36bcdf78728bed4ff7
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            //using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            //{
            //    string uri = $"demo/{GetUriSuffix(indexType)}";
            //    MajorIndex majorIndex = await client.GetAsync<MajorIndex>(uri);
            //    majorIndex.Type = indexType;
            //    return majorIndex;
            //}

            return new MajorIndex
            {
                Changes = (DateTime.Now.Hour + DateTime.Now.Minute * 0.01),
                Price = (DateTime.Now.Hour + DateTime.Now.Minute * 0.02),
                Type = indexType
            };

        }

        private string GetUriSuffix(MajorIndexType indexType)
        {
            switch (indexType)
            {
                case MajorIndexType.DowJones:
                    return ".DJI";
                case MajorIndexType.Nasdaq:
                    return ".IXIC";
                case MajorIndexType.SP500:
                    return ".INX";
                default: throw new Exception("MajorIndexType does not have a suffix defined.");

            }
        }
    }
}
