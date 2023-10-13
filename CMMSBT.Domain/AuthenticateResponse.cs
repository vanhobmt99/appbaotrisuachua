using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CMMSBT.Domain
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; } = null!;       
        public int MANV { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(UserAdmin user, string token)
        {
            Id = user.Id;
            Deleted = user.Deleted;
            Active = user.Active;
            CreateDate = user.CreateDate;
            CreateBy = user.CreateBy;
            UpdateDate = user.UpdateDate;
            UpdateBy = user.UpdateBy;
            MANV = user.Manv;
            Token = token;
        }

    }

}
