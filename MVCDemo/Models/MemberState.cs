using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCDemo.Models
{
    public class MemberState
    {
        [DisplayName("會員編號")]
        public int Id { get; set; }

        [DisplayName("暱稱")]
        [Required(ErrorMessage = "暱稱不可空白")]
        [StringLength(10, ErrorMessage = "暱稱必須是7-10字元", MinimumLength = 7)]
        public string nickName { get; set; } // 暱稱

        [DisplayName("帳號")]
        [Required(ErrorMessage = "帳號不可空白")]
        [StringLength(10, ErrorMessage = "帳號必須是7-10字元", MinimumLength = 7)]
        public string UserId { get; set; } //帳號

        public string CardLevel { get; set; } // 卡別

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼不可空白")]
        [StringLength(10, ErrorMessage = "密碼必須是7-10字元", MinimumLength = 7)]
        // [Compare("Password", "RePassword", ErrorMessage = "兩組密碼必須相同")]
        public string Password { get; set; } // 密碼
        public string RePassword { get; set; } // 密碼

        private string realName; // 真實姓名

        [DisplayName("電話")]
        [Phone]
        public string phoneNumber { get; set; } // 電話號碼

        [DisplayName("信箱")]
        [EmailAddress(ErrorMessage = "信箱格式錯誤")]
        public string eMail { get; set; } // 信箱

        private string Address; // 地址
    }
}