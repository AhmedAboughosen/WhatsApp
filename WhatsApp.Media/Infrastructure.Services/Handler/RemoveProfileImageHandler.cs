using CentralizedSetUpUserServices.Events.DataTypes;
using Core.Domain.Model;
using Core.Domain.Model.MessageBroker;
using Firebase.Auth;
using Firebase.Storage;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services.Handler
{
    public class RemoveProfileImageHandler : IRequestHandler<MessageBody<RemoveProfileImageData>, bool>
    {
        private readonly FirebaseStorageConfigModel _firebaseStorageConfigModel;
        private readonly string _path;


        public RemoveProfileImageHandler(IOptions<FirebaseStorageConfigModel> settings,
            IHostEnvironment hostEnvironment)
        {
            _path = hostEnvironment.ContentRootPath;
            _firebaseStorageConfigModel = settings.Value;
        }

        public async Task<bool> Handle(MessageBody<RemoveProfileImageData> messageBody,
            CancellationToken cancellationToken)
        {
            //create file ;

            var firebaseAuthConfig = new FirebaseAuthConfig
            {
                ApiKey = _firebaseStorageConfigModel.ApiKey
            };

            var firebaseAuthClient = new FirebaseAuthClient(firebaseAuthConfig);

            var userCredential =
                await firebaseAuthClient.SignInWithEmailAndPasswordAsync(_firebaseStorageConfigModel.AuthEmail,
                    _firebaseStorageConfigModel.AuthPassword);

            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var firebaseStorageTask = new FirebaseStorage(
                    _firebaseStorageConfigModel.Bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => userCredential.User.GetIdTokenAsync(),
                        ThrowOnCancel =
                            true // when you cancel the upload, exception is thrown. By default no exception is thrown
                    })
                .Child("Images")
                .Child("AccountProfile")
                .Child($"{messageBody.Data.UserId}.png");

            await firebaseStorageTask.DeleteAsync();

            return true;
        }
    }
}