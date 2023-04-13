using Microsoft.AspNetCore.Http;
using Profile.Domain.FileModels;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Profile.Service.Infrastructure
{
    public static class FormFileModel
    {
        public static async Task<FileModel> Form(IFormFile file, CancellationToken cancellationToken)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), file.FileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream, cancellationToken);
            }

            return new FileModel { Name = file.FileName, Path = path };
        }
    }
}
