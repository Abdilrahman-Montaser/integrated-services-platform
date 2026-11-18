using System;
using System.Collections.Generic;
using System.Text;

namespace TadweerHub.DAL.Entities
{
    public class RegistrationDocument
    {
        public int Document_Id { get; set; }
        public int Request_Id { get; set; }
        public string? Doc_Type { get; set; } 
        public string? File_Url { get; set; } 
        public DateTime Uploaded_At { get; set; }

        public RegistrationRequest? Request { get; set; } 
    }
}
