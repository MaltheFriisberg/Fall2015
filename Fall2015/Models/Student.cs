using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Fall2015.Helpers;

namespace Fall2015.Models
{
    public class Student : IStudent
    {
        //[Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Wrong, stupid user. You must have a firstname.")]
        public String Firstname { get; set; }

        [Required]
        public String Lastname { get; set; }

        [Required]
        //[EmailAddress]
        public String Email { get; set; }

        public String MobilePhone { get; set; }

        public String ImageFilePath { get; set; }
        //for the joined table
        public virtual ICollection<Competency> Competencies { get; set; }
        //weak reference to the login table
        public string ApplicationUserId { get; set; }

        public void SaveOrUpdateImage(HttpPostedFileBase image, String serverPath, String pathToFile)
        {
            if (image == null) return;
            RemoveOldImage(serverPath);
            //ImageModel
            Guid guid = Guid.NewGuid();
            ImageModel.ResizeAndSave(serverPath + pathToFile, guid.ToString(), image.InputStream, 200);

            ImageFilePath = pathToFile + guid.ToString() + ".jpg";
        }

        public void RemoveOldImage(String serverPath)
        {
            if (ImageFilePath != null)
            {
                System.IO.File.Delete(serverPath + ImageFilePath);
                //set to null needed??
            }
            this.ImageFilePath = null;

        }

    }
}