using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBitcoin;
using NBXplorer;

namespace BTCPayServer
{
    public partial class BTCPayNetworkProvider
    {
        public void InitVertcoin()
        {
            var nbxplorerNetwork = NBXplorerNetworkProvider.GetFromCryptoCode("VTC");
            Add(new BTCPayNetwork()
            {
                CryptoCode = nbxplorerNetwork.CryptoCode,
                DisplayName = "Vertcoin",
                BlockExplorerLink = NetworkType == NetworkType.Mainnet ? "https://insight.vertcoin.org/tx/{0}" : "https://insight.vertcoin.org/tx/{0}",
                NBitcoinNetwork = nbxplorerNetwork.NBitcoinNetwork,
                NBXplorerNetwork = nbxplorerNetwork,
                UriScheme = "vertcoin",
                DefaultRateRules = new[] 
                {
                                "VTC_X = VTC_BTC * BTC_X",
                                "VTC_BTC = bittrex(VTC_BTC)"
                },
                CryptoImagePath = "imlegacy/vertcoin.png",
                LightningImagePath = "imlegacy/vtc-lightning.svg",
                DefaultSettings = BTCPayDefaultSettings.GetDefaultSettings(NetworkType),
                CoinType = NetworkType == NetworkType.Mainnet ? new KeyPath("28") : new KeyPath("1'")
            });
        }
    }
}
