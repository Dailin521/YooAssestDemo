using System;
using System.IO;
using UnityEngine;
using YooAsset;

/// <summary>
/// 初始化资源包
public class YooassetDecryption : IDecryptionServices {
    public ulong LoadFromFileOffset(DecryptFileInfo file_info) {
        return 32;
    }

    public byte[] LoadFromMemory(DecryptFileInfo file_info) {
        throw new NotImplementedException();
    }

    public Stream LoadFromStream(DecryptFileInfo file_info) {
        return new YooAssetStream(file_info.BundleName, file_info.FileLoadPath, FileMode.Open, FileAccess.Read, FileShare.Read);
    }

    public uint GetManagedReadBufferSize() {
        return 1024;
    }

    public AssetBundle LoadAssetBundle(DecryptFileInfo fileInfo, out Stream managedStream) {
        managedStream = null;
        return AssetBundle.LoadFromStream(LoadFromStream(fileInfo), fileInfo.ConentCRC);
    }

    public AssetBundleCreateRequest LoadAssetBundleAsync(DecryptFileInfo fileInfo, out Stream managedStream) {
        managedStream = null;
        return AssetBundle.LoadFromStreamAsync(LoadFromStream(fileInfo), fileInfo.ConentCRC);
    }
}