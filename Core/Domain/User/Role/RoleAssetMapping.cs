using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.User.Role
{
    public class RoleAssetMapping
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string AssetType { get; set; }
        public string ScreenName { get; set; }
        public string AssetFileFullPath { get; set; }
        public string AssetFileName { get; set; }
        public bool IsActive { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
    }
}