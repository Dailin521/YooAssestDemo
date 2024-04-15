using System.IO;
using YooAsset;

public class FileStreamEncryption : IEncryptionServices {
    public EncryptResult Encrypt(EncryptFileInfo file_info) {
        if (!file_info.BundleName.EndsWith(".rawfile")) {
            byte key = GetABKey(file_info.BundleName);
            var file_data = File.ReadAllBytes(file_info.FilePath);
            for (int i = 0; i < file_data.Length; i++) {
                file_data[i] ^= key;
            }
            EncryptResult result = new();
            result.Encrypted = true;
            result.EncryptedData = file_data;
            return result;
        }
        EncryptResult result_normal = new();
        result_normal.Encrypted = false;
        return result_normal;
    }
    public static byte GetABKey(string name) {
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(name);
        return bytes[bytes.Length / 2];
    }

}