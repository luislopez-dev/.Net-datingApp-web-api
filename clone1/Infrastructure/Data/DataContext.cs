﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
using clone1.Core.Entities;
using clone1.Core.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace clone1.Infrastructure.Data;

public class DataContext : IdentityDbContext <AppUser, AppRole, int, 
    IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, 
    IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }
    public DbSet<Message> Messages { get; set; }
    public DbSet<UserLike> Likes{ get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>()
            .HasMany(users => users.UserRoles)
            .WithOne(userRoles => userRoles.User)
            .HasForeignKey(userRoles => userRoles.UserId)
            .IsRequired();

        builder.Entity<AppRole>()
            .HasMany(users => users.UserRoles)
            .WithOne(userRoles => userRoles.Role)
            .HasForeignKey(userRoles => userRoles.RoleId)
            .IsRequired();
        
        
        builder.Entity<Message>()
            .HasOne(messages => messages.Recipient)
            .WithMany(recipient => recipient.MessagesReceived)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Message>()
            .HasOne(messages => messages.Sender)
            .WithMany(sender => sender.MessagesSent)
            .OnDelete(DeleteBehavior.Restrict);

        
        builder.Entity<UserLike>()
            .HasKey(key => new { key.SourceUserId, key.TargetUserId });

        builder.Entity<UserLike>()
            .HasOne(like => like.SourceUser)
            .WithMany(sourceUser => sourceUser.LikedUsers)
            .HasForeignKey(source => source.SourceUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<UserLike>()
            .HasOne(like => like.TargetUser)
            .WithMany(targetUser => targetUser.LikedByUsers)
            .HasForeignKey(like => like.TargetUserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}