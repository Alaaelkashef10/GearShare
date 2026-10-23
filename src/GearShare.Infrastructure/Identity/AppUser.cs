using Microsoft.AspNetCore.Identity;
using GearShare.Application.Entities;

namespace GearShare.Infrastructure.Identity;

public class AppUser : IdentityUser<Guid>
{
    public override string? Email
    {
        get => base.Email;
        set => base.Email = value?.Trim();
    }

    public string DisplayName { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.Member;
    public UserStatus Status { get; set; } = UserStatus.Active;
    public string? SuspensionReason { get; set; }
}