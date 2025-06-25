using HealPoint.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HealPoint.BusinessLogic.Services;
internal class FileStorageService : IFileStorageService
{
	private readonly IWebHostEnvironment _webHostEnvirontment;

	public FileStorageService(IWebHostEnvironment webHostEnvirontment)
	{
		_webHostEnvirontment = webHostEnvirontment;
	}

	public void DeleteFile(string? filePath)
	{
		if (!string.IsNullOrEmpty(filePath))
		{
			var fullPath = Path.Combine(_webHostEnvirontment.WebRootPath, filePath.TrimStart('/'));

			if (File.Exists(fullPath))
			{
				File.Delete(fullPath);
			}
		}


	}

	public async Task<string?> UploadFileAsync(IFormFile file, string folderName)
	{
		if (file == null || file.Length == 0)
		{
			return null;
		}

		var uploadsFolder = Path.Combine(_webHostEnvirontment.WebRootPath, "images", folderName);

		// Ensure the directory exists
		if (!Directory.Exists(uploadsFolder))
		{
			Directory.CreateDirectory(uploadsFolder);
		}

		// Generate a unique file name
		var uniqueFileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";
		var filePath = Path.Combine(uploadsFolder, uniqueFileName);

		// Save the file to the physical path
		using (var fileStream = new FileStream(filePath, FileMode.Create))
		{
			await file.CopyToAsync(fileStream);
		}

		return Path.Combine("/images", folderName, uniqueFileName).Replace("\\", "/");
	}
}
