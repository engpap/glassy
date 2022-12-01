using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using TMPro;
public class QRcodeScanner : MonoBehaviour
{
    [SerializeField]
    private RawImage rawImageBackground;

    [SerializeField]
    private AspectRatioFitter aspectRatioFitter;

    [SerializeField]
    private TextMeshProUGUI textOut;

    [SerializeField]
    private RectTransform scanzone;

    private bool isCamAvaiable;
    private WebCamTexture cameratexture;

    // Start is called before the first frame update
    void Start()
    {
        SetUpCamera();
    }

    // Update is called once per frame
    void Update()
    {
     UpdateCameraRender();   
    }
    private void UpdateCameraRender(){
        if(isCamAvaiable==false)
        {
               return;
        }
        float ratio= (float)cameratexture.width/(float) cameratexture.height;
        aspectRatioFitter.aspectRatio=ratio;

        int orientation=-cameratexture.videoRotationAngle;
        rawImageBackground.rectTransform.localEulerAngles=new Vector3(0,0,orientation);
    }

    private void SetUpCamera(){
        WebCamDevice [] devices=WebCamTexture.devices;

        if(devices.Length==0){
            isCamAvaiable=false;
            return;
        }
        for(int i=0;i <devices.Length;i++){
            if(devices[i].isFrontFacing==false){
                cameratexture=new WebCamTexture(devices[i].name,(int)scanzone.rect.width,(int)scanzone.rect.height);
            }
        }

        cameratexture.Play();
        rawImageBackground.texture=cameratexture;
        isCamAvaiable=true;
    }

    private void Scan(){
        try{
            IBarcodeReader barcodeReader=new BarcodeReader();
            Result result=barcodeReader.Decode(cameratexture.GetPixels32(),cameratexture.width,cameratexture.height);
            if(result!=null)
            {
                textOut.text=result.Text;
            }
            else{
                textOut.text="failed to read qrCode";
            }

        }catch{
            textOut.text="Failed in try";
        }
    }

   public void OnClickScan(){
        Scan();
   } 
}
