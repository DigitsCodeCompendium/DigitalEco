using Eco.Core.Controller;
using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Serialization;
using Eco.Core.Systems;
using Eco.Core.Utils;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.src.EngineeringPlus.Systems
{
    [Serialized]
    public class PartNumberManager : AutoSingleton<PartNumberManager>
    {
        [Serialized] private readonly PNCacheData data;

        [Serialized]
        public class PNCacheData : IStorage
        {
            public IPersistent StorageHandle { get; set; }
            [Serialized] internal CacheData cacheData;
        }

        public PartNumberManager()
        {
            this.data = StorageManager.LoadOrCreate<PNCacheData>("PNCacheData");
        }

        public int GetNextPartNumber()
        {
            this.data.cacheData.PartNumber++;
            StorageManager.Obj.MarkDirty(this.data);
            return this.data.cacheData.PartNumber;
        }
    }
}

[Serialized]
struct CacheData
{
    [Serialized] public int PartNumber;

    public CacheData(int partNumber)
    {
        this.PartNumber = partNumber;
    }
}
