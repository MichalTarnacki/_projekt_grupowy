﻿namespace ResearchCruiseApp_API.Application.ExternalServices.Persistence;


public interface IFileInspector
{
    bool IsFilePdf(string contentAsBase64Url);

    bool IsFileSizeValid(string contentAsBase64Url, int maxFileSize);
}