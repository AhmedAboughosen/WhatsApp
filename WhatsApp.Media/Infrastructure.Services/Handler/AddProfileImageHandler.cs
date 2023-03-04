using System.Net;
using Core.Domain.Exceptions;
using Core.Domain.Model;
using Core.Domain.Model.Dto.RequestDto;
using Firebase.Auth;
using Firebase.Storage;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services.Handler
{
    public class AddProfileImageHandler : IRequestHandler<AddProfileImageRequestDto, string>
    {
        private readonly FirebaseStorageConfigModel _firebaseStorageConfigModel;
        private readonly string _path;


        public AddProfileImageHandler(IOptions<FirebaseStorageConfigModel> settings, IHostEnvironment hostEnvironment)
        {
            _path = hostEnvironment.ContentRootPath;
            _firebaseStorageConfigModel = settings.Value;
        }

        public async Task<string> Handle(AddProfileImageRequestDto dto,
            CancellationToken cancellationToken)
        {
            //create file ;

            MemoryStream fileStream = new MemoryStream(Convert.FromBase64String(dto.Base64Image));


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
                .Child($"{dto.UserId}.png")
                .PutAsync(fileStream, cancellation.Token);

            firebaseStorageTask.Progress.ProgressChanged +=
                (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");


            try
            {
                return (await firebaseStorageTask);
            }
            catch (Exception ex)
            {
                throw new APIException(
                    ex.Message, HttpStatusCode.Forbidden);
            }
        }
    }
}