using System;
using Photos;
using UIKit;
using Foundation;
using System.Threading.Tasks;
using AVFoundation;

namespace PhotoPicker09
{
    public partial class ViewController : UIViewController, IUIImagePickerControllerDelegate
    {

        #region Class Variables

        UITapGestureRecognizer profileTap;
        UITapGestureRecognizer coverTap;

        #endregion

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            InitializeComponents();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        #region User Interactions

        void ShowOptions (UITapGestureRecognizer gesture) {

            alert = UIAlertController.Create("Profile", "Choose an option.", UIAlertControllerStyle.ActionSheet);
            alert.AddAction(UIAlertAction.Create("Choose from gallery", UIAlertActionStyle.Default, action => ChooseFromGallery()));
            alert.AddAction(UIAlertAction.Create("Take a photo", UIAlertActionStyle.Default, action => TakePhoto()));
            alert.AddAction(UIAlertAction.Create("Cancelar", UIAlertActionStyle.Cancel, null));
            PresentViewController(alert, animated: true, completionHandler: null);

            }

        void ChooseFromGallery() {
            
            if (!UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.PhotoLibrary))
                {
                    return;
                }

                CheckLibraryAuthorizationStatus(PHPhotoLibrary.AuthorizationStatus);
        }

        void TakePhoto()
        {
            if (!UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
            {
                ShowMessage("Precaucion!", "Recurso no valido.", NavigationController);
                return;
            }

            CheckCameraAuthorizationStatus(AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video));
        }

        void CheckLibraryAuthorizationStatus(PHAuthorizationStatus authorizationStatus)
        {
            switch (authorizationStatus)
            {
                case PHAuthorizationStatus.NotDetermined:
                    //TODO: Vamos a pedir el permiso para acceder
                    PHPhotoLibrary.RequestAuthorization(CheckLibraryAuthorizationStatus);
                    break;
                case PHAuthorizationStatus.Restricted:
                    //TODO: Mostrar un mensaje diciendo que esta restringido
                    InvokeOnMainThread(() => ShowMessage("Error", "El permiso esta restringido.", NavigationController));
                    break;
                case PHAuthorizationStatus.Denied:
                    //TODO: El usuario denego el permiso.
                    InvokeOnMainThread(() => ShowMessage("Error", "El permiso fue denegado.", NavigationController));
                    break;
                case PHAuthorizationStatus.Authorized:
                    //TODO: Abrir la galeria
                    InvokeOnMainThread(() =>
                    {
                        var imagePickerController = new UIImagePickerController
                        {
                            SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                            Delegate = this
                        };
                        PresentViewController(imagePickerController, true, null);
                    });
                    break;
                default:
                    break;
            }
        }

        void CheckCameraAuthorizationStatus(AVAuthorizationStatus authorizationStatus)
        {
            switch (authorizationStatus)
            {
                case AVAuthorizationStatus.NotDetermined:
                    //TODO: Vamos a pedir el permiso para acceder
                    AVCaptureDevice.RequestAccessForMediaType(AVAuthorizationMediaType.Video, (accessGranted) => {
                        if(!accessGranted) {
                            CheckCameraAuthorizationStatus(authorizationStatus);
                        }
                    });
                    break;
                case AVAuthorizationStatus.Restricted:
                    //TODO: Mostrar un mensaje diciendo que esta restringido
                    InvokeOnMainThread(() => ShowMessage("Error", "El permiso esta restringido.", NavigationController));
                    break;
                case AVAuthorizationStatus.Denied:
                    //TODO: El usuario denego el permiso.
                    InvokeOnMainThread(() => ShowMessage("Error", "El permiso fue denegado.", NavigationController));
                    break;
                case AVAuthorizationStatus.Authorized:
                    //TODO: Abrir la galeria
                    InvokeOnMainThread(() =>
                    {
                        var imagePickerController = new UIImagePickerController
                        {
                            SourceType = UIImagePickerControllerSourceType.Camera,
                            Delegate = this
                        };
                        PresentViewController(imagePickerController, true, null);
                    });
                    break;
                default:
                    break;
            }
        }


        #endregion

        #region UIImage Picker Controller Delegate

        [Export("imagePickerController:didFinishPickingMediaWithInfo:")]
        public void FinishedPickingMedia(UIImagePickerController picker, NSDictionary info)
        {
            var image = info[UIImagePickerController.OriginalImage] as UIImage;

            ImgProfile.Image = image;

            picker.DismissViewController(true, null);
        }

        [Export("imagePickerControllerDidCancel:")]
        public void Canceled(UIImagePickerController picker)
        {
            picker.DismissViewController(true, null);
        }

        #endregion

        #region Internal Functionality

        void InitializeComponents() {

            lblEdit.Hidden = lblCover.Hidden = true;

            profileTap = new UITapGestureRecognizer(ShowOptions) { Enabled = true };
            ProfileView.AddGestureRecognizer(profileTap);


            coverTap = new UITapGestureRecognizer(ShowOptions) { Enabled = true };
            CoverView.AddGestureRecognizer(coverTap);
        }
       
        void ShowMessage(string title, string mensaje, UIViewController fromViewController) {
            var alert = UIAlertController.Create(title, mensaje, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));

            fromViewController.PresentViewController(alert, true, null);
        }
        #endregion
            
    }
}
