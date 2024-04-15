using System.IO;

public class YooAssetStream : FileStream {
    public byte key;
    public YooAssetStream(string bundle_name, string path, FileMode mode, FileAccess access, FileShare share) : base(path, mode, access, share) {
        key = GetABKey(bundle_name);
    }
    public YooAssetStream(string path, FileMode mode) : base(path, mode) {
    }

    public override int Read(byte[] array, int offset, int count) {
        var index = base.Read(array, offset, count);
        for (int i = 0; i < array.Length; i++) {
            array[i] ^= key;
        }
        return index;
    }
    public static byte GetABKey(string name) {
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(name);
        return bytes[bytes.Length / 2];
    }
}