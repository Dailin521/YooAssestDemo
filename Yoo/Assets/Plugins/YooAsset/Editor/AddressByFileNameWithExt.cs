using System.IO;
using YooAsset.Editor;

public class AddressByFileNameWithExt : IAddressRule {
    string IAddressRule.GetAssetAddress(AddressRuleData data) {
        return Path.GetFileName(data.AssetPath);
    }
}
