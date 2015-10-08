using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Fall2015.Helpers;

namespace Fall2015.Models
{
    public class Student
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

        //public virtual int CompetencyId { get; set; }

        public ICollection<Competency> Competency { get; set; }

        public void SaveOrUpdateImage(HttpPostedFileBase image, String serverPath, String pathToFile)
        {
            if (image == null) return;
            RemoveOldImage(serverPath);
            //ImageModel
            Guid guid = Guid.NewGuid();
            ImageModel.ResizeAndSave(serverPath + pathToFile, guid.ToString(), image.InputStream, 200);

            ImageFilePath = pathToFile + guid.ToString() + ".jpg";
        }

        private void RemoveOldImage(String serverPath)
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