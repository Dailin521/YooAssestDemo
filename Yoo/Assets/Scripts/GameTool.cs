public class GameTool {

    public static byte GetABKey(string name) {
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(name);
        return bytes[bytes.Length / 2];
    }
}
