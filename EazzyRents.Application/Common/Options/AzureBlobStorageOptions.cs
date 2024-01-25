using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Common.Options
{
    public class AzureBlobStorageOptions
    {
        public const string AzureBlobStorageSettings = "AzureBlobStorageSettings";
        public string ContainerName { get; set; }
        public string PhotosFolderName { get; set; }
        public string AdditionalDocumentsFolderName { get; set; }
        public string UserProfilePhotosFolderName { get; set; }
    }
}
