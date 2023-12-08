using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CVLookup_WebAPI.Services.FileService
{
	public class FileService : IFileService
	{
		public async Task DeleteFile(string filePath)
		{
			try
			{
				if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), filePath)))
				{
					File.Delete(Path.Combine(Directory.GetCurrentDirectory(), filePath));
				}
				
			} catch(ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<FileDownload> DownloadFile(string filePath)
		{
			try
			{
				var filepath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

				var provider = new FileExtensionContentTypeProvider();
				if (!provider.TryGetContentType(filepath, out var contentType))
				{
					contentType = "application/octet-stream";
				}

				var bytes = await File.ReadAllBytesAsync(filepath);
				return new FileDownload { 
					Bytes = bytes, 
					ContentType = contentType, 
					FilePath = filepath
				};
			} catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<string> UploadFile(IFormFile file, string uploadPath)
		{
			try
			{
				string filename = "";
				var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
				filename = DateTime.Now.Ticks.ToString() + extension;

				var filepath = Path.Combine(Directory.GetCurrentDirectory(), uploadPath);

				if (!Directory.Exists(filepath))
				{
					Directory.CreateDirectory(filepath);
				}

				var exactpath = Path.Combine(Directory.GetCurrentDirectory(), uploadPath, filename);
				using (var stream = new FileStream(exactpath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
				return exactpath;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}
	}
}
