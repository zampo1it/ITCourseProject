using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ITProjectTryThree.Interfaces;
using Microsoft.Extensions.Options;

namespace ITProjectTryThree.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly CloudinaryDotNet.Cloudinary _cloudinary;

		public PhotoService(IOptions<CloudinarySettings> config)
		{
			var acc = new Account(
				config.Value.CloudName,
				config.Value.ApiKey,
				config.Value.ApiSecret
				);
			_cloudinary = new CloudinaryDotNet.Cloudinary(acc);
		}

		public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
			var uploadResult = new ImageUploadResult();

			if (file.Length > 0)
			{
				await using var stream = file.OpenReadStream();
				var uploadParams = new ImageUploadParams
				{
					File = new FileDescription(file.FileName, stream)
				};

				uploadResult = await _cloudinary.UploadAsync(uploadParams);
			}
			return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicUrl)
        {
            var publicId = publicUrl.Split('/').Last().Split('.')[0];
            var deleteParams = new DeletionParams(publicId);
            return await _cloudinary.DestroyAsync(deleteParams);
        }
    }
}
