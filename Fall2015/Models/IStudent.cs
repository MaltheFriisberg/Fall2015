using System;
using System.Web;

namespace Fall2015.Models
{
    public interface IStudent
    {
        int StudentId { get; set; }
        String Firstname { get; set; }
        String Lastname { get; set; }

        //[EmailAddress]
            String Email { get; set; }

        String MobilePhone { get; set; }
        String ImageFilePath { get; set; }
        void SaveOrUpdateImage(HttpPostedFileBase image, String serverPath, String pathToFile);
        void RemoveOldImage(String serverPath);
    }
}