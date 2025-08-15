using LocumApp.Domain.Models;
using LocumApp.Domain.Models.Profiles;
using LocumGQLGateway.Data;
using LocumGQLGateway.Dtos;
using LocumGQLGateway.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LocumGQLGateway.Services.Implementations;

public class UserService : IUserService
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public UserService(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        await using var context = _factory.CreateDbContext();
        return await context.Users
            .Include(u => u.Profile)
            .Include(p => p.Profile!.Preference!.FacilityTypes)
            .Include(p => p.Profile!.Preference!.JobTypes)
            .Include(p => p.Profile!.Preference!.ShiftTypes)
            .Include(p => p.Profile!.Preference!.LocationTypes)
            .Include(p => p.Profile!.Preference!.States)
            .Include(p => p.Profile!.ProfileNotificationSettings)
            .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return (await GetAllAsync())
            .FirstOrDefault(u => u.Id == id);
    }

    public async Task<User> AddAsync(AddUserDto input)
    {
        await using var ctx = _factory.CreateDbContext();
        var createdBy = 0; // TODO: Get his from token
        var UpdatedBy = 0; // TODO: Get his from token
        var user = new User
        {
            Username = input.Username,
            Email = input.Email,
            PasswordHash = GetHashedPassword(input.Password!),
            Role = input.Role,
            CreatedById = createdBy,
            UpdatedById = UpdatedBy,
            Profile = new Profile
            {
                CreatedById = createdBy,
                UpdatedById = UpdatedBy,

                Address = new Address
                {
                    CreatedById = createdBy,
                    UpdatedById = UpdatedBy
                },
                Preference = new Preference
                {
                    CreatedById = createdBy,
                    UpdatedById = UpdatedBy
                },
                ProfileNotificationSettings = new ProfileNotificationSettings
                {
                    CreatedById = createdBy,
                    UpdatedById = UpdatedBy
                }
            }
        };
        ctx.Users.Add(user);

        await ctx.SaveChangesAsync();
        return user;
    }

    public async Task UpdatePasswordAsync(UpdatePasswordDto input)
    {
        await using var ctx = _factory.CreateDbContext();

        // 1. Find existing user by ID
        var user = await ctx.Users.FindAsync(input.UserId);
        if (user == null) throw new Exception($"User with Id {input.UserId} not found.");
        if (!VerifyHashedPassword(user.PasswordHash!, input.OldPassword))
            throw new Exception("Old password does not match our records. Please verify and try again.");
        var usernewPasswordHash = GetHashedPassword(input.NewPassword);
        user.PasswordHash = usernewPasswordHash;
        // 3. Mark entity as updated (optional, FindAsync tracks it automatically)
        ctx.Users.Update(user);
        await ctx.SaveChangesAsync();
    }

    private string? GetHashedPassword(string inputPassword)
    {
        var passwordHasher = new PasswordHasher<object>();
        var hashedPassword = passwordHasher.HashPassword(null!, inputPassword);
        return hashedPassword;
    }

    private bool VerifyHashedPassword(string hashedPassword, string inputPassword)
    {
        // To verify later:
        var passwordHasher = new PasswordHasher<object>();
        var verificationResult = passwordHasher.VerifyHashedPassword(null!, hashedPassword, inputPassword);
        if (verificationResult == PasswordVerificationResult.Success) return true;

        return false;
    }
}