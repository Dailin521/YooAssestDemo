using Cysharp.Threading.Tasks;
using UnityEngine;
using YooAsset;

public class InitScene : MonoBehaviour {
    private void Awake() {
        DontDestroyOnLoad(gameObject);
        InitConfig().Forget();
    }
    private async UniTaskVoid InitConfig() {
        YooAssets.Initialize();
        ResourcePackage resource_package = YooAssets.CreatePackage("DefaultPackage");
        YooAssets.SetDefaultPackage(resource_package);
#if UNITY_EDITOR
        //EditorSimulateModeParameters init_parameters = new();
        //init_parameters.SimulateManifestFilePath = EditorSimulateModeHelper.SimulateBuild(EDefaultBuildPipeline.BuiltinBuildPipeline, resource_package.PackageName);
        //await resource_package.InitializeAsync(init_parameters);
        var init_parameters = new OfflinePlayModeParameters();
        init_parameters.DecryptionServices = new YooassetDecryption();
        await resource_package.InitializeAsync(init_parameters);
#else
            var init_parameters = new OfflinePlayModeParameters();
            init_parameters.DecryptionServices = new YooassetDecryption();
            await resource_package.InitializeAsync(init_parameters);
#endif

        await YooAssets.LoadSceneAsync("Game1").Task;
    }
}
public static class YooAssetTool {
    public static T LoadAsset<T>(string name) where T : UnityEngine.Object {
        return YooAssets.LoadAssetSync<T>(name).AssetObject as T;
    }

    public static async UniTask LoadScene(string name) {
        var handler = YooAssets.LoadSceneAsync(name);
        await handler.Task;
    }
}
