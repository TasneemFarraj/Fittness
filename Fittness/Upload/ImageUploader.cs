using Fittness.Data.Enum;

namespace Fittness.Upload;
public class ImageUploader
{
    public static string Upload(IFormFile image, FileTypeEnum type, string domainName)
    {
        if (image == null || image.Length == 0)
            return "";

        var folderName = Path.Combine("file", type.ToString());
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        string extension = Path.GetExtension(image.FileName);

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        string nameToUse = type.ToString() + DateTime.Now.Ticks.ToString();
        nameToUse = nameToUse.Replace(" ", String.Empty);

        var uniqueFileName = $"{nameToUse}_{image.Name}{extension}";
        var dbPath = Path.Combine(folderName, uniqueFileName);

        using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
        {
            image.CopyTo(fileStream);
        }

        var url = $"{dbPath}";


        url = url.Replace(@"\", "/");

        return domainName + url;
    }

    internal static IFormFile Upload(string img, FileTypeEnum image, string v)
    {
        throw new NotImplementedException();
    }
}

