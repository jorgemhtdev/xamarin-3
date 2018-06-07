namespace MediaDemo.ViewModel
{
    using Plugin.Permissions;
    using Plugin.Permissions.Abstractions;
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;
    using Plugin.MediaManager;
    using Plugin.MediaManager.Abstractions.Enums;
    using GalaSoft.MvvmLight.Command;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Plugin.GoToSettings;

    public class MediaViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        #region Attributes
        private ImageSource imageSource;
        private Stream stream = null;
        private string btn;
        private string btnPause;
        private string video;
        private bool isVisible;
        #endregion

        #region Properties
        public ImageSource ImageSource
        {
            set => SetProperty(ref imageSource, value);
            get => imageSource;
        }
        public string Btn
        {
            set => SetProperty(ref btn, value);
            get => btn;
        }
        public string BtnPause
        {
            set => SetProperty(ref btnPause, value);
            get => btnPause;
        }
        public string Video
        {
            set => SetProperty(ref video, value);
            get => video;
        }
        public bool IsVisible
        {
            set => SetProperty(ref isVisible, value);
            get => isVisible;
        }
        #endregion

        #region Constructor
        public MediaViewModel()
        {
            ImageSource = "Circle";
            Btn = AppResources.Play;
            BtnPause = AppResources.Stop;
            IsVisible = false;
        }
        #endregion

        #region Command
        public ICommand UploadPhotoCommand => new RelayCommand(UploadPhoto);
        public ICommand UploadVideoCommand => new RelayCommand(UploadVideo);
        public ICommand PlayVideoCommand => new RelayCommand(PlayVideo);
        public ICommand PauseVideoCommand => new RelayCommand(PauseVideo);

        private async void UploadPhoto()
        {
            if (!CrossMedia.Current.IsCameraAvailable && !CrossMedia.Current.IsTakePhotoSupported)
            {
                // Do Something when '!IsCameraAvailable' and '!IsTakePhotoSupported' is false
                return;
            }

            var action = string.Empty;

            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                action = await Application.Current.MainPage.DisplayActionSheet(AppResources.PhotoTitle, AppResources.Cancel, null, AppResources.Gallery, AppResources.Camera);
            }

            else if (CrossMedia.Current.IsCameraAvailable)
            {
                action = await Application.Current.MainPage.DisplayActionSheet(AppResources.PhotoTitle, AppResources.Cancel, null, AppResources.Camera);
            }

            else if (CrossMedia.Current.IsTakePhotoSupported)
            {
                action = await Application.Current.MainPage.DisplayActionSheet(AppResources.PhotoTitle, AppResources.Cancel, null, AppResources.Gallery);
            }

            if (action == string.Empty) return;

            if (action == AppResources.Gallery)
            {
                PickPhoto();
            }
            else if (action == AppResources.Camera)
            {
                TakePhoto();
            }
            else if (action == AppResources.Cancel)
            {
                // Do Something when 'Cancel' Button is pressed
            }
        }

        private async void UploadVideo()
        {
            if (!CrossMedia.Current.IsCameraAvailable && !CrossMedia.Current.IsTakePhotoSupported)
            {
                // Do Something when '!IsCameraAvailable' and '!IsTakePhotoSupported' is false
                return;
            }

            var action = string.Empty;

            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                action = await Application.Current.MainPage.DisplayActionSheet(AppResources.PhotoTitle, AppResources.Cancel, null, AppResources.Gallery, AppResources.Camera);
            }
            else if (CrossMedia.Current.IsCameraAvailable)
            {
                action = await Application.Current.MainPage.DisplayActionSheet(AppResources.PhotoTitle, AppResources.Cancel, null, AppResources.Camera);
            }
            else if (CrossMedia.Current.IsTakePhotoSupported)
            {
                action = await Application.Current.MainPage.DisplayActionSheet(AppResources.PhotoTitle, AppResources.Cancel, null, AppResources.Gallery);
            }

            if (action == string.Empty) return;

            if (action == AppResources.Gallery)
            {
                PickVideo();
            }
            else if (action == AppResources.Video)
            {
                TakeVideo();
            }
            else if (action == AppResources.Cancel)
            {
                // Do Something when 'Cancel' Button is pressed
            }
        }

        private async void PlayVideo()
        {
            if (Btn.Equals(AppResources.Play))
            {
                await CrossMediaManager.Current.Play("https://sec.ch9.ms/ch9/ba6d/042b1e69-7956-4aa2-8280-8214878dba6d/THR2415_high.mp4", MediaFileType.Video);

                Btn = AppResources.Pause;
                IsVisible = true;
            }
            else if (Btn.Equals(AppResources.Pause))
            {
                await CrossMediaManager.Current.Pause();

                Btn = AppResources.Play;
                IsVisible = false;
            }
        }

        private async void PauseVideo()
        {
            if (!BtnPause.Equals(AppResources.Stop)) return;

            await CrossMediaManager.Current.Stop();
            Btn = AppResources.Play;
            IsVisible = false;
        }
        #endregion

        #region CrossMedia methods

        private async void PickPhoto()
        {
            var photoStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);

            if (photoStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Photos });
                photoStatus = results[Permission.Photos];
            }

            if (photoStatus == PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file != null)
                {
                    UpdatePhoto(file);
                }
            }
            else
            {
                if (await Application.Current.MainPage.DisplayAlert(AppResources.Error_Permissions,
                    AppResources.Permissions_Label, AppResources.Yes, AppResources.No))
                {
                    GoToSettings.Go();
                }
            }
        }

        private async void PickVideo()
        {
            var photoStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);

            if (photoStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Photos });
                photoStatus = results[Permission.Photos];
            }

            if (photoStatus == PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.PickVideoAsync();

                if (file != null)
                {
                    UpdatePhoto(file);
                }
            }
            else
            {
                if (await Application.Current.MainPage.DisplayAlert(AppResources.Error_Permissions,
                    AppResources.Permissions_Label, AppResources.Yes, AppResources.No))
                {
                    GoToSettings.Go();
                }
            }
        }

        private async void TakePhoto()
        {
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            var photoStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted || photoStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage, Permission.Photos });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
                photoStatus = results[Permission.Photos];
            }

            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted && photoStatus == PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    SaveToAlbum = true,
                    CompressionQuality = 92,
                    DefaultCamera = CameraDevice.Rear
                });

                if (file != null)
                {
                    UpdatePhoto(file);
                }
            }
            else
            {
                //On iOS you may want to send your user to the settings screen.
                //CrossPermissions.Current.OpenAppSettings();

                if (await Application.Current.MainPage.DisplayAlert(AppResources.Error_Permissions,
                    AppResources.Permissions_Label, AppResources.Yes, AppResources.No))
                {
                    GoToSettings.Go();
                }


                /*
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        if (action)
                        {
                            Device.OpenUri(new Uri("app-settings:"));
                        }
                        break;
                    case Device.Android:
                        if (action)
                        {
                            GoToSettings.Go();
                        }
                        break;
                    default:
                        break;
                }*/
            }

        }

        private async void TakeVideo()
        {
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            var photoStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted || photoStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage, Permission.Photos });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
                photoStatus = results[Permission.Photos];
            }

            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted && photoStatus == PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.TakeVideoAsync(new StoreVideoOptions
                {
                    DefaultCamera = CameraDevice.Front,
                    Directory = "MediaDemo",
                    SaveToAlbum = true
                });

                if (file != null)
                {
                    UpdateVideo(file);
                }
            }
            else
            {
                if (await Application.Current.MainPage.DisplayAlert(AppResources.Error_Permissions,
                    AppResources.Permissions_Label, AppResources.Yes, AppResources.No))
                {
                    GoToSettings.Go();
                }
            }
        }
        #endregion

        #region Methods
        private void UpdatePhoto(MediaFile file)
        {
            if (file != null)
            {
                ImageSource = ImageSource.FromStream(() =>
                {
                    stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }
        }

        private void UpdateVideo(MediaFile file)
        {
            if (file == null) return;

            Video = file.Path;
        }
        
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
