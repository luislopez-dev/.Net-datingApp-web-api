﻿using CloudinaryDotNet.Actions;

namespace clone1.Core.Interfaces;


/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public interface IPhotoService
{
    public Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    public Task<DeletionResult> DeletePhotoAsync(string publicUrl);
}