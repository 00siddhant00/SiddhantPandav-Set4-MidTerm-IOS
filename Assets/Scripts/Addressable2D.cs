using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Addressable2D : MonoBehaviour
{
    // Assign the prefab via the Inspector
    public AssetReference animatedSquareReference;

    void Start()
    {
        // Load the prefab using the AssetReference
        animatedSquareReference.InstantiateAsync().Completed += Handle_Completed;
    }

    private void Handle_Completed(AsyncOperationHandle<GameObject> operation)
    {
        if (operation.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject animatedSquare = operation.Result;
            Debug.Log("Animated square successfully loaded and instantiated!");
        }
        else
        {
            Debug.LogError($"Failed to load and instantiate animated square. Key: {animatedSquareReference.RuntimeKey}");
        }
    }

    private void OnDestroy()
    {
        // Release the loaded asset when no longer needed
        animatedSquareReference.ReleaseAsset();
    }
}