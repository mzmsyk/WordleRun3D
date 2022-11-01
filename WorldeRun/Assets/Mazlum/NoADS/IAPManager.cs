using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : IStoreListener
{
    private string prefix = "wordlerun_remove_ads";

    private IStoreController controller;
    private IExtensionProvider extensions;

    public IAPManager()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(prefix, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
        Debug.Log("Satın alma entegresi başlatıldı...");
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
        this.extensions = extensions;

        Debug.Log(controller.products.all);
        Debug.Log("Satın alma entegresi başladı");
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Satın alma entegresi başlatılamadı");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        PlayerPrefs.SetInt("ads_blocked", 1);
        Ads.instance.NoAdsButtonAktifligi();
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product i, PurchaseFailureReason p) {}

    public void OnPurchaseClicked()
    {
        // REKLAM SATIN ALMA YERİ BUTONUN OLDUĞU FONKSİYONUN İÇİNDE ÇAĞRILIR.
        Product product = controller.products.WithID(prefix);

        if (product != null && product.availableToPurchase)
        {
            Debug.Log("Sat�n aln�yor");
            controller.InitiatePurchase(product);
        }
    }

    public void RestorePurchases()
    {
        Debug.Log("Geri yükleme işlemi başlıyor");
        //if (controller != null && extensions != null) return;

        var apple = extensions.GetExtension<IAppleExtensions>();
        apple.RestoreTransactions((result) => {
            if (result)
            {
                Debug.Log("Tekrar geri yüklendi");
            }
            else Debug.Log("Geri yükleme yok");
        });
    }

    public bool ReklamEngellendimi()
    {
        return PlayerPrefs.GetInt("ads_blocked" , 0) == 1; // REKLAM ENGELLEME 
    }
}
