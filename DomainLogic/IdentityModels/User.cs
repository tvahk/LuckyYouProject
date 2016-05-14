using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.Configuration;
using Domain;
using Microsoft.AspNet.Identity.EntityFramework;


namespace DomainLogic.IdentityModels
{

    /// <summary>
    ///     Default EntityFramework IUser implementation
    /// </summary>
    public class User : User<string, UserLogin, UserRole, UserClaim>, IUser
    {
        /// <summary>
        ///     Constructor which creates a new Guid for the Id
        /// </summary>
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        ///     Constructor that takes a userName
        /// </summary>
        /// <param name="userName"></param>
        public User(string userName)
            : this()
        {
            UserName = userName;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authType);
            // Add custom user claims here
            return userIdentity;
        }

    }

    public class User<TKey, TUserLogin, TUserRole, TUserClaim> : IUser<TKey>
        where TUserLogin : UserLogin<TKey>
        where TUserRole : UserRole<TKey>
        where TUserClaim : UserClaim<TKey>
    {
        public User()
        {
            //SecurityStamp = Guid.NewGuid().ToString();
            this.Claims = new List<TUserClaim>();
            this.Logins = new List<TUserLogin>();
            this.Roles = new List<TUserRole>();
            this.ConnectionsMinuteRate = Config.DefaultConnectionMinuteRate;
            this.ConnectionsWeekRate = Config.DefaultConnectionWeekRate;
        }

        public TKey Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Score { get; set; }
        public string FirstLastName => FirstName + " " + LastName;
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public  DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public int ConnectionsMinuteRate { get; set; }
        public int ConnectionsWeekRate { get; set; }
        [DisplayName("User name")]
        [Required]
        [MaxLength(128)]
        public string UserName { get; set; }
        public virtual ICollection<TUserClaim> Claims { get; set; }
        public virtual ICollection<TUserLogin> Logins { get; set; }
        public virtual ICollection<TUserRole> Roles { get; set; }
        public virtual ICollection<UserInDraw> UserInDraws { get; set; }
        public virtual ICollection<Draw> Draws { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
