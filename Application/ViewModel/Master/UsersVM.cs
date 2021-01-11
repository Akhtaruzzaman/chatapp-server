using Common.Library;
using Domain;
using Domain.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModel.Master
{
    public class UsersVM : Entity
    {

        #region Model property
        public string Code { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string LoginId { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string UserTypeDes { get; set; }
        public string ImageLink { get; set; }
        public List<int> UserTypeLoad { get; set; }
        public bool IsActive { get; set; }
        #endregion


        public Users ToEntity()
        {
            return new Users()
            {
                Id = this.Id,
                LoginId = this.LoginId,
                Address = this.Address,
                Mobile = this.Mobile,
                Name = this.Name,

                Password = this.Password,

                CreatedAt = this.CreatedAt,
                CreatedBy = this.CreatedBy,
                CreatedFrom = this.CreatedFrom,
                UpdatedAt = this.UpdatedAt,
                UpdatedBy = this.UpdatedBy,
                UpdatedFrom = this.UpdatedFrom,
                IsActive = this.IsActive,
                IsArchived = this.IsArchived
            };
        }
    }
    public class LoginVM
    {
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [StringLength(50)]
        [Required]
        public string Email { get; set; }
    }
    public class AuditVM
    {
        public string Creator { get; set; }
        public string Modarator { get; set; }
        public string AuthorizationType { get; set; }
        public int AuthorizationTypeId { get; set; }
    }
    public class ChangePassword
    {
        [Display(Name = "Old Password")]
        [Required(ErrorMessage = "Old Password is required")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
